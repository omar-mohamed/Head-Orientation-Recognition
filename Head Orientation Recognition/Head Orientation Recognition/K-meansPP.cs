using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Head_Orientation_Recognition
{
    class K_meansPP
    {
        #region members
        private double[,] centers;
       private double[,] distance;
       private double[,] sum;
       private double[] count;
       private double[,] variance;
        #endregion

       #region calculate distance to centers
       private double euclideanDistance(int centerIndex, int featureIndex)
        {
            double dist = 0;
            for (int i = 0; i < centers.GetLength(1); i++)
            {
                dist += (centers[centerIndex, i] - ReadData.trainingSet[featureIndex][i, 0]) * (centers[centerIndex, i] - ReadData.trainingSet[featureIndex][i, 0]);
            }
            return Math.Sqrt(dist);
        }

       private void calculateDistance()
        {
            int minIndex = 0;
            double min;
            variance = new double[centers.GetLength(0), 1];
            for (int i = 0; i < ReadData.trainingSet.Count; i++)
            {
                min = 10000000;
                for (int j = 0; j < centers.GetLength(0); j++)
                {
                    distance[j, i] = euclideanDistance(j, i);
                    if (distance[j, i] < min)
                    {
                        minIndex = j;
                        min = distance[j, i];
                    }
                }
                variance[minIndex, 0] += min;
                for (int k = 0; k < centers.GetLength(1); k++)
                    sum[minIndex, k] += ReadData.trainingSet[i][k, 0];
                count[minIndex]++;
            }
        }
       #endregion

       #region move centroids
       private bool moveCentroids()
        {
            bool change = false;
            for (int i = 0; i < centers.GetLength(0); i++)
            {
                for (int j = 0; j < centers.GetLength(1); j++)
                {
                    if (count[i] > 0)
                    {
                        double temp = sum[i, j] / count[i];
                        if (temp != centers[i, j])
                        {
                            change = true;
                        }
                        centers[i, j] = temp;
                    }
                }
                if (count[i] > 0)
                    variance[i, 0] /= count[i];
                else
                    variance[i, 0] = 1;
            }

            sum = new double[centers.GetLength(0), ReadData.trainingSet[0].GetLength(0)];
            count = new double[centers.GetLength(0)];
            return change;
        }

       #endregion

       #region initialize centers - k means++
       private double minDistanceToAnyCenter(int sampleIndex, int centerNumber)
        {
            double min = 1000000000;
            double dist;
            for (int i = 0; i < centerNumber; i++)
            {
                dist = 0;
                for (int j = 0; j < ReadData.trainingSet[0].GetLength(0); j++)
                {
                    dist += (ReadData.trainingSet[sampleIndex][j, 0] - centers[i, j]) * (ReadData.trainingSet[sampleIndex][j, 0] - centers[i, j]);
                }
                if (dist < min)
                {
                    min = dist;
                }
            }
            return min;
        }

       private void addMaxProbabiltyCenter(double[] minDistance, int centerIndex, double cumulative)
        {
            double max = 0;
            int index = 0;
            double prop = 0;
            for (int i = 0; i < ReadData.trainingSet.Count; i++)
            {
                prop = minDistance[i] / cumulative;
                if (prop > max)
                {
                    max = prop;
                    index = i;
                }
            }
            for (int j = 0; j < ReadData.trainingSet[0].GetLength(0); j++)
            {
                centers[centerIndex, j] = ReadData.trainingSet[index][j, 0];
            }
        }

       private void initializeCenters(int centerNum)
        {
            if (centerNum > ReadData.trainingSet.Count)
                centerNum = ReadData.trainingSet.Count;
            int rand = Utilities.getRandomInteger(0, ReadData.trainingSet.Count - 1);
            for (int j = 0; j < ReadData.trainingSet[0].GetLength(0); j++)
            {
                centers[0, j] = ReadData.trainingSet[rand][j, 0];
            }
            double[] minDistance = new double[ReadData.trainingSet.Count];
            double cumulative;
            for (int k = 1; k < centerNum; k++)
            {
                cumulative = 0;
                for (int i = 0; i < ReadData.trainingSet.Count; i++)
                {
                    minDistance[i] = minDistanceToAnyCenter(i, k);
                    cumulative += minDistance[i];
                }
                addMaxProbabiltyCenter(minDistance, k, cumulative);
            }

        }  
        #endregion

       #region cluster data
       //Dictionary<double, int> counter;
        //List<double[,]> allCenters;
        public Tuple<double[,], double[,]> cluster(int centersNum)
        {
            //counter = new Dictionary<double, int>();
            //allCenters = new List<double[,]>();

            centers = new double[centersNum, ReadData.trainingSet[0].GetLength(0)];
            distance = new double[centersNum, ReadData.trainingSet.Count];
            sum = new double[centersNum, ReadData.trainingSet[0].GetLength(0)];
            count = new double[centersNum];
            initializeCenters(centersNum);
            int maxiterations = 10000;
            int iteration = 0;
            while (iteration < maxiterations)
            {
                calculateDistance();
                if (!moveCentroids())
                    break;
                iteration++;
            }

            return Tuple.Create(variance, centers);
        }
      #endregion
    }
}
