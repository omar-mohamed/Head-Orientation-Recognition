using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Head_Orientation_Recognition
{
    class RadialBasisNet
    {
       #region members
       private double[,] weights;
       private double[,] g;
       private double[,] errors;
       private double[,] spreads;
       private double[,] centers;
       private double[,] output;
       #endregion

       #region activation and feedforward
       private void gaussianFunction(double[,] sample, int numhidden)
        {
            g = new double[numhidden, 1];
            for (int i = 0; i < numhidden; i++)
            {
                double sum = 0;
                for (int j = 0; j < ReadData.trainingSet[0].GetLength(0); j++)
                {
                    sum += (sample[j, 0] - centers[j, 0]) * (sample[j, 0] - centers[j, 0]);
                }
                g[i, 0]=Math.Exp(-(sum/spreads[i,0]));
            }
            g = Utilities.addBias(g);
        }

       private void feedforward()
        {
            output = Utilities.multiply(weights, g);
        }
        #endregion

       #region update weights
       private void updateWeights(double learningRate)
        {
            weights=Utilities.sum_ele_wise(weights,Utilities.multiply_scalar(Utilities.multiply(errors,Utilities.transpose(g)),learningRate));
        }
       #endregion

       #region train data set
       public Tuple<double,double[,]> train(int numHiddenNeurons, int numIterations, double learningRate)
        {
            K_meansPP kMeans=new K_meansPP();
            double[,] confusionMatrix = new double[3, 3];
            weights=Utilities.getRandomWeights(3,numHiddenNeurons+1);
            Tuple<double[,], double[,]> t = kMeans.cluster(numHiddenNeurons);
            spreads = Utilities.multiply_scalar(Utilities.squareElementWise(t.Item1),2);
            centers =Utilities.transpose(t.Item2);
            for(int l=0;l<numIterations;l++)
            {
                for(int i=0;i<ReadData.trainingSet.Count;i++)
                 {
                     gaussianFunction(ReadData.trainingSet[i], numHiddenNeurons);
                     feedforward();
                     output = Utilities.sigmoid(output, false);
                     errors = Utilities.calculateErrors(3, i, output, ReadData.trainingLabels[i]);
                     updateWeights(learningRate);
                 }
            }

            int testErrors = 0;
            double accuracy = 0;
            for (int i = 0; i < ReadData.testSet.Count; i++)
            {
                gaussianFunction(ReadData.testSet[i],numHiddenNeurons);
                feedforward();
                output = Utilities.sigmoid(output, false);
                confusionMatrix[Utilities.LabelToNum(ReadData.testLabels[i]), Utilities.getMaxIndex(3, output)]++;
                testErrors += Utilities.countErrors(3, i, output, ReadData.testLabels[i]);
            }
            accuracy = (((double)ReadData.testSet.Count - (double)testErrors) / (double)ReadData.testSet.Count) * 100.0f;
            accuracy = Math.Round(accuracy, 2);
            return Tuple.Create(accuracy, confusionMatrix);
        }
      #endregion
    }
}
