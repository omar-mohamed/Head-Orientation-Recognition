using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace Head_Orientation_Recognition
{
   static class ReadData
    {
        #region data members
        public static List<double[,]> trainingSet;
        public static List<double[,]> testSet;
        public static string[] trainingLabels;
        public static string[] testLabels;
        private static double[] min;
        private static double[] max;
        private static double[] mean;
        private static PCA pca;
        #endregion

        #region read compressed data
        public static void readCompressedData()
        {
            trainingSet = new List<double[,]>();
            testSet = new List<double[,]>();
            trainingLabels = new string[6000];
            testLabels = new string[6000];

            string[] lines = System.IO.File.ReadAllLines(@"Compressed training images.txt");
            char[] delimiterChars = { ' ' };
            int index = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(delimiterChars);
                double[,] temp = new double[257, 1];
                for (int i = 0; i < words.Length-1; i++)
                {
                    temp[i, 0] =Convert.ToDouble( words[i]);
                }
                trainingSet.Add(temp);
                if (index < 2000)
                    trainingLabels[index++] = "Front";
                else if (index < 4000)
                    trainingLabels[index++] = "Left";
                else
                    trainingLabels[index++] = "Right";
            }
            lines = System.IO.File.ReadAllLines(@"Compressed test images.txt");
            index = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(delimiterChars);
                double[,] temp = new double[257, 1];
                for (int i = 0; i < words.Length - 1; i++)
                {
                    temp[i, 0] = Convert.ToDouble(words[i]);
                }
                testSet.Add(temp);
                if (index < 2000)
                    testLabels[index++] = "Front";
                else if (index < 4000)
                    testLabels[index++] = "Left";
                else
                    testLabels[index++] = "Right";
            }
        }

        public static void readSmallCompressedData()
        {
            trainingSet = new List<double[,]>();
            testSet = new List<double[,]>();
            trainingLabels = new string[150];
            testLabels = new string[90];

            string[] lines = System.IO.File.ReadAllLines(@"Compressed small training images.txt");
            char[] delimiterChars = { ' ' };
            int index = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(delimiterChars);
                double[,] temp = new double[257, 1];
                for (int i = 0; i < words.Length - 1; i++)
                {
                    temp[i, 0] = Convert.ToDouble(words[i]);
                }
                trainingSet.Add(temp);
                if (index < 50)
                    trainingLabels[index++] = "Front";
                else if (index < 100)
                    trainingLabels[index++] = "Left";
                else
                    trainingLabels[index++] = "Right";
            }
            lines = System.IO.File.ReadAllLines(@"Compressed small test images.txt");
            index = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(delimiterChars);
                double[,] temp = new double[257, 1];
                for (int i = 0; i < words.Length - 1; i++)
                {
                    temp[i, 0] = Convert.ToDouble(words[i]);
                }
                testSet.Add(temp);
                if (index < 30)
                    testLabels[index++] = "Front";
                else if (index < 60)
                    testLabels[index++] = "Left";
                else
                    testLabels[index++] = "Right";
            }
        }

        #endregion

        #region read user data
        public static void readUserData(string path,int outputFeatures,double learningRate)
        {
            testSet = new List<double[,]>();
            trainingSet = new List<double[,]>();
            List<string> fileNames=new List<string>();
            fileNames.AddRange(Directory.GetFiles(path,"*.jpg"));
            fileNames.AddRange(Directory.GetFiles(path, "*.png"));
            fileNames.AddRange(Directory.GetFiles(path, "*.gif"));
            fileNames.AddRange(Directory.GetFiles(path, "*.bmp"));
            foreach (string name in fileNames)
            {
                trainingSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
            }
            if (trainingSet.Count > 0)
            {
                min = new double[trainingSet[0].GetLength(0)];
                max = new double[trainingSet[0].GetLength(0)];
                mean = new double[trainingSet[0].GetLength(0)];
                normalizeData();
                pca = new PCA();
                pca.train(outputFeatures, learningRate);
                compressData();
                saveCompressData();
            }
        }
        #endregion
        //public static void readData()
      //  {
      //      min = new double[2500];
      //      max = new double[2500];
      //      mean = new double[2500];
      //      trainingSet = new List<double[,]>();
      //      testSet = new List<double[,]>();
      //      trainingLabels = new string[6000];
      //      testLabels = new string[6000];
      //      int index = 0;
      //      string[] fileNames= Directory.GetFiles("DataSet\\Training\\Data_Front", "*.png*");
      //      foreach (string name in fileNames)
      //      {
      //          trainingSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
      //          trainingLabels[index] = "Front";
      //          index++;
      //      }
      //      fileNames = Directory.GetFiles("DataSet\\Training\\Data_Left", "*.png*");
      //      foreach (string name in fileNames)
      //      {
      //          trainingSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
      //          trainingLabels[index] = "Left";
      //          index++;
      //      }
      //      fileNames = Directory.GetFiles("DataSet\\Training\\Data_Right", "*.png*");
      //      foreach (string name in fileNames)
      //      {
      //          trainingSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
      //          trainingLabels[index] = "Right";
      //          index++;
      //      }
      //      index = 0;
      //      fileNames = Directory.GetFiles("DataSet\\Testing\\Test_Front", "*.png*");
      //      foreach (string name in fileNames)
      //      {
      //          testSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
      //          testLabels[index] = "Front";
      //          index++;
      //      }
      //      fileNames = Directory.GetFiles("DataSet\\Testing\\Test_Left", "*.png*");
      //      foreach (string name in fileNames)
      //      {
      //          testSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
      //          testLabels[index] = "Left";
      //          index++;
      //      }
      //      fileNames = Directory.GetFiles("DataSet\\Testing\\Test_Right", "*.png*");
      //      foreach (string name in fileNames)
      //      {
      //          testSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
      //          testLabels[index] = "Right";
      //          index++;
      //      }
      //      normalizeData();
      //      pca = new PCA();
      //      pca.train(256, 0.0001);
      //      compressData();
      //      saveCompressData();
      //  }


        //public static void readSmallData()
        //{
        //    min = new double[2500];
        //    max = new double[2500];
        //    mean = new double[2500];
        //    trainingSet = new List<double[,]>();
        //    testSet = new List<double[,]>();
        //    trainingLabels = new string[150];
        //    testLabels = new string[90];
        //    int index = 0;
        //    string[] fileNames = Directory.GetFiles("small Data set\\Training\\Data_Front", "*.png*");
        //    foreach (string name in fileNames)
        //    {
        //        trainingSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
        //        trainingLabels[index] = "Front";
        //        index++;
        //    }
        //    fileNames = Directory.GetFiles("small Data set\\Training\\Data_Left", "*.png*");
        //    foreach (string name in fileNames)
        //    {
        //        trainingSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
        //        trainingLabels[index] = "Left";
        //        index++;
        //    }
        //    fileNames = Directory.GetFiles("small Data set\\Training\\Data_Right", "*.png*");
        //    foreach (string name in fileNames)
        //    {
        //        trainingSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
        //        trainingLabels[index] = "Right";
        //        index++;
        //    }
        //    index = 0;
        //    fileNames = Directory.GetFiles("small Data set\\Testing\\Test_Front", "*.png*");
        //    foreach (string name in fileNames)
        //    {
        //        testSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
        //        testLabels[index] = "Front";
        //        index++;
        //    }
        //    fileNames = Directory.GetFiles("small Data set\\Testing\\Test_Left", "*.png*");
        //    foreach (string name in fileNames)
        //    {
        //        testSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
        //        testLabels[index] = "Left";
        //        index++;
        //    }
        //    fileNames = Directory.GetFiles("small Data set\\Testing\\Test_Right", "*.png*");
        //    foreach (string name in fileNames)
        //    {
        //        testSet.Add(ImageProcessing.imageToGrayscale(new Bitmap(name)));
        //        testLabels[index] = "Right";
        //        index++;
        //    }
        //   // normalizeData();
        //  //  pca = new PCA();
        //   // pca.train(256, 0.0001);
        //   // compressData();
        //    saveCompressData();
        //}
        #region save compressed data
        private static void saveCompressData()
      {
          string s="";
          using (StreamWriter sr = new StreamWriter("Compressed user images.txt"))
          {
              for (int i = 0; i < trainingSet.Count; i++)
              {
                  s="";
                  for (int j = 0;j< trainingSet[0].GetLength(0); j++)
                  {
                      s += trainingSet[i][j, 0].ToString();
                      s += ' ';
                  }
                  sr.WriteLine(s);
              }
          }
          //using (StreamWriter sr = new StreamWriter("Compressed small test images.txt"))
          //{
          //    for (int i = 0; i < testSet.Count; i++)
          //    {
          //        normalizeImage(testSet[i]);
          //        testSet[i] = pca.compress(testSet[i]);
          //        s = "";
          //        for (int j = 0; j < testSet[0].GetLength(0); j++)
          //        {
          //            s += testSet[i][j, 0].ToString();
          //            s += ' ';
          //        }
          //        sr.WriteLine(s);
          //    }
          //}
      }
        #endregion

        #region compress data
        private static void compressData()
      {
          for (int k = 0; k < trainingSet.Count; k++)
          {
              trainingSet[k] = pca.compress(trainingSet[k]);
          }

          for (int k = 0; k < testSet.Count; k++)
          {
              testSet[k] = pca.compress(testSet[k]);
          }
      }
        #endregion

       #region pre-processing 
      private static void normalizeData()
      {
          for (int i = 0; i < trainingSet[0].GetLength(0); i++)
          {
              max[i] = 0;
              min[i] = 1000000;
              mean[i] = 0;
          }
          for (int k = 0; k < trainingSet.Count; k++)
          {
              for (int i = 0; i < trainingSet[k].GetLength(0); i++)
              {
                  max[i] = Math.Max(trainingSet[k][i, 0], max[i]);
                  min[i] = Math.Min(trainingSet[k][i, 0], min[i]);
                  mean[i] += trainingSet[k][i, 0];
              }
          }

          for (int k = 0; k < testSet.Count; k++)
          {
              for (int i = 0; i < testSet[k].GetLength(0); i++)
              {
                  max[i] = Math.Max(testSet[k][i, 0], max[i]);
                  min[i] = Math.Min(testSet[k][i, 0], min[i]);
                  mean[i] += testSet[k][i, 0];
              }
          }

          for (int k = 0; k < trainingSet.Count; k++)
          {
              for (int i = 0; i < trainingSet[k].GetLength(0); i++)
              {
                  if (max[i] == min[i])
                      min[i] = 0;
                  if (max[i] == 0)
                      max[i] = 1;
                  trainingSet[k][i, 0] = (trainingSet[k][i, 0] - (mean[i] / (trainingSet.Count + testSet.Count))) / (max[i] -min[i]);
                  if(k<testSet.Count)
                   testSet[k][i, 0] = (testSet[k][i, 0] - (mean[i] / (trainingSet.Count + testSet.Count))) / (max[i] - min[i]);
              }
          }
          //string s="";
          //using (StreamWriter sr = new StreamWriter("normalizationData.txt"))
          //{
          //    for (int i = 0; i < 2500; i++)
          //    {
          //        s+= min[i].ToString();
          //        if (i < 2500 - 1)
          //            s += ' ';
          //    }
          //    sr.WriteLine(s);
          //    s = "";
          //    for (int i = 0; i < 2500; i++)
          //    {
          //        s += max[i].ToString();
          //        if (i < 2500 - 1)
          //            s += ' ';
          //    }
          //    sr.WriteLine(s);
          //    s = "";
          //    for (int i = 0; i < 2500; i++)
          //    {
          //        s += mean[i].ToString();
          //        if (i < 2500 - 1)
          //            s += ' ';
          //    }
          //    sr.WriteLine(s);
          //}

      }

     private static void readNormalizationData()
      {
          min = new double[2500];
          max = new double[2500];
          mean = new double[2500];

          string[] lines = System.IO.File.ReadAllLines(@"normalizationData.txt");
          char[] delimiterChars = { ' ' };
          int index = 0;
          foreach (string line in lines)
          {
              string[] words = line.Split(delimiterChars);
              if (index == 0)
              {
                  for (int i = 0; i < words.Length; i++)
                  {
                      min[i] = Convert.ToDouble(words[i]);
                  }
              }
              if (index == 1)
              {
                  for (int i = 0; i < words.Length; i++)
                  {
                      max[i] = Convert.ToDouble(words[i]);
                  }
              }
              if (index == 2)
              {
                  for (int i = 0; i < words.Length; i++)
                  {
                      mean[i] = Convert.ToDouble(words[i]);
                  }
              }
              index++;
          }
      }

     public static void normalizeImage(ref double[,] image)
      {
          readNormalizationData();
          for (int i = 0; i < image.GetLength(0); i++)
          {
              image[i, 0] = (image[i, 0] - mean[i] / 12000) / (max[i] - min[i]);
          }
      }
      #endregion
    }
}
