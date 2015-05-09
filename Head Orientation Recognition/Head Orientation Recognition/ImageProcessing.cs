using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Head_Orientation_Recognition
{
   static class ImageProcessing
    {
        public static double[,] imageToGrayscale(Bitmap im)
        {
            double[,] features = new double[im.Width*im.Height, 1];
          //  features[0, 0] = 1;
            int index=0;
            for (int i = 0; i < im.Width; i++)
            {
                for (int x = 0; x < im.Height; x++)
                {
                    Color oc = im.GetPixel(i, x);
                    double grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    features[index++,0]=grayScale;
                }
            }
            return features;
        }
    }
}
