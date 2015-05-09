using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Head_Orientation_Recognition
{
    class PCA
    {
       #region data members
        private double[,] weights;
       private double[,] y;
        #endregion

       #region feedforward
       private void feedForward(int n)
        {
            y = Utilities.multiply(weights, ReadData.trainingSet[n]);
        }
       #endregion

       #region read or save weights
       private void saveWeights()
        {
            using (StreamWriter sr = new StreamWriter("PCA User weights.txt"))
            {
                string s;
                for (int i = 0; i < weights.GetLength(0); i++)
                {
                    s = "";
                    for (int j = 0; j < weights.GetLength(1); j++)
                    {
                        s += weights[i,j].ToString();
                        if (j < weights.GetLength(1) - 1)
                           s += ' ';
                    }
                    sr.WriteLine(s);
                }
            }
        }
      
       public void readPretrainedWeights()
        {
            string[] lines = System.IO.File.ReadAllLines(@"PCA weights.txt");
            char[] delimiterChars = { ' ' };
            List<double> all = new List<double>();
            foreach (string line in lines)
            {
                string[] words = line.Split(delimiterChars);
                for (int i = 0; i < words.Length; i++)
                {
                    if(words[i].Length>0)
                      all.Add(Convert.ToDouble(words[i]));
                }
            }
            int index=0;
            weights = new double[256, 2500];
            for (int i = 0; i < weights.GetLength(0); i++)
                for (int j = 0; j < weights.GetLength(1); j++)
                    weights[i, j] = all[index++];

        }
       #endregion

       #region compress
       public double[,] compress(double[,] input)
        {
            return Utilities.multiply(weights, input);
        }
       #endregion

       #region train generalized hebbian PCA

       private double summation(int i,int j)
        {
            double sum = 0;
            for (int k = 0; k <= j; k++)
            {
                sum += weights[k, i] * y[k,0];
            }
            return sum;
        }

        public void train(int outputSize,double learningRate)
        {
            weights = Utilities.getRandomWeights(outputSize, ReadData.trainingSet[0].GetLength(0));//new double[outputSize, ReadData.trainingSet[0].Length - 1];
            for (int n = 0; n < ReadData.trainingSet.Count; n++)
            {
              //  input=Utilities.removeBias(ReadData.trainingSet[n]);
                feedForward(n);
                for (int j = 0; j < outputSize; j++)
                {
                    for (int i = 0; i < ReadData.trainingSet[n].GetLength(0); i++)
                    {
                        weights[j, i] += learningRate * y[j, 0] * (ReadData.trainingSet[n][i, 0] - summation(i, j));
                    }
                }
            }

            saveWeights();
        }
       #endregion
    }
}
