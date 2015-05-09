using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
namespace Head_Orientation_Recognition
{
    class Neural_Network
    {
        #region members
        private List<double[,]> weights;
        private List<double[,]> v;
        private List<double[,]> y;
        private List<double[,]> sigma;
        private double[,] errors;
        #endregion

        #region feedforward
        private void feedForward(double[,] sampleInput)
        {
            v = new List<double[,]>();
            y = new List<double[,]>();
            double[,] arr = Utilities.multiply(weights[0], sampleInput);
            arr = Utilities.addBias(arr);
            v.Add(arr);
            bool neglect = true;
            if (weights.Count == 1)
                neglect = false;
            y.Add(Utilities.sigmoid(arr, neglect));
            for (int i = 1; i < weights.Count; i++)
            {
                double[,] arr2 = Utilities.multiply(weights[i], y[i - 1]);
                if (i < weights.Count - 1)
                    arr2 = Utilities.addBias(arr2);
                else
                    neglect = false;
                v.Add(arr2);
                y.Add(Utilities.sigmoid(arr2, neglect));
            }
        }
        #endregion

        #region back propagation
        private void backPropagation()
        {
            sigma = new List<double[,]>();
            sigma.AddRange(v);
            sigma[sigma.Count - 1] = Utilities.multiply_ele_wise(Utilities.sigmoid_der(v[v.Count - 1]), errors);

            for (int i = v.Count - 2; i >= 0; i--)
            {
                sigma[i] = Utilities.multiply_ele_wise(Utilities.multiply(Utilities.transpose(weights[i + 1]), sigma[i + 1]), Utilities.sigmoid_der(v[i]));
                sigma[i] = Utilities.removeBias(sigma[i]);
            }
        }
        #endregion

        #region update weights
        private void updateWeights(double learningRate, double[,] Input)
        {
            List<double[,]> deltas = new List<double[,]>();
            for (int i = 0; i < weights.Count; i++)
            {
                if (i == 0)
                {
                    deltas.Add(Utilities.multiply(sigma[0], Utilities.transpose(Input)));
                }
                else
                    deltas.Add(Utilities.multiply(sigma[i], Utilities.transpose(y[i - 1])));
            }

            for (int i = 0; i < weights.Count; i++)
            {
                weights[i] = Utilities.sum_ele_wise(weights[i], Utilities.multiply_scalar(deltas[i], learningRate));
            }
        }
        #endregion

        #region read pre trained weights
        void readPreTrainedWeights()
        {
            string[] lines = System.IO.File.ReadAllLines(@"bp pretrained weights.txt");
            char[] delimiterChars = { ' ' };
            List<double> all = new List<double>();
            foreach (string line in lines)
            {
                string[] words = line.Split(delimiterChars);
                for (int i = 0; i < words.Length; i++)
                {
                    all.Add(Convert.ToDouble(words[i]));
                }
            }
            weights = new List<double[,]>();
            double[,] temp = new double[17, 257];
            int index = 0;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = all[index++];
                }
            }
            double[,] temp2 = new double[3, 18];
            for (int i = 0; i < temp2.GetLength(0); i++)
            {
                for (int j = 0; j < temp2.GetLength(1); j++)
                {
                    temp2[i, j] = all[index++];
                }
            }
            weights.Add(temp);
            weights.Add(temp2);
        }
        #endregion

        #region classify input

        public string classify(double[,] sampleInput)
        {
            readPreTrainedWeights();
            feedForward(sampleInput);
            return Utilities.identifyPrediction(v[v.Count - 1].Length, y[v.Count - 1]);
        }
        #endregion

        #region save weights
        void saveWeights()
        {
            using (StreamWriter sr = new StreamWriter("bp pretrained weights.txt"))
            {
                string s;
                for (int i = 0; i < weights[0].GetLength(0); i++)
                {
                    s = "";
                    for (int j = 0; j < weights[0].GetLength(1); j++)
                    {
                        s += weights[0][i, j].ToString();
                        if (j < weights[0].GetLength(1) - 1)
                            s += ' ';
                    }
                    sr.WriteLine(s);
                }
                for (int i = 0; i < weights[1].GetLength(0); i++)
                {
                    s = "";
                    for (int j = 0; j < weights[1].GetLength(1); j++)
                    {
                        s += weights[1][i, j].ToString();
                        if (j < weights[1].GetLength(1) - 1)
                            s += ' ';
                    }
                    sr.WriteLine(s);
                }
            }
        }
        #endregion

        #region train dataset
        public Tuple<double, double[,]> train(int[] layers, int num_iteraions, double eta)
        {
            double[,] confusionMatrix = new double[3, 3];
            weights = new List<double[,]>();
            for (int i = 1; i < layers.Length; i++)
            {
                weights.Add(Utilities.getRandomWeights(layers[i], layers[i - 1] + 1));
            }
            for (int k = 0; k < num_iteraions; k++)
            {
                for (int i = 0; i < ReadData.trainingSet.Count; i++)
                {
                    feedForward(ReadData.trainingSet[i]);
                    errors = Utilities.calculateErrors(v[v.Count - 1].Length, i, y[v.Count - 1], ReadData.trainingLabels[i]);
                    backPropagation();
                    updateWeights(eta, ReadData.trainingSet[i]);
                }
            }
            int testErrors = 0;
            double accuracy = 0;
            for (int i = 0; i < ReadData.testSet.Count; i++)
            {
                feedForward(ReadData.testSet[i]);
                confusionMatrix[Utilities.LabelToNum(ReadData.testLabels[i]), Utilities.getMaxIndex(v[v.Count - 1].Length, y[v.Count - 1])]++;
                testErrors += Utilities.countErrors(v[v.Count - 1].Length, i, y[v.Count - 1], ReadData.testLabels[i]);
            }
            accuracy = (((double)ReadData.testSet.Count - (double)testErrors) / (double)ReadData.testSet.Count) * 100.0f;
            accuracy = Math.Round(accuracy, 2);
           // saveWeights();
            return Tuple.Create(accuracy, confusionMatrix);
        }
        #endregion
    }
}