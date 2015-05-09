using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Head_Orientation_Recognition
{
    public partial class ClassifyInput : Form
    {
       private Bitmap image;
        public ClassifyInput()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialog = new OpenFileDialog();
            objFileDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png"; 
            string ChosenPicture = ""; 

            if (objFileDialog.ShowDialog() == DialogResult.OK)
            {
                ChosenPicture = objFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(ChosenPicture);
                image = new Bitmap(ChosenPicture);
            }
            pictureBox1.Refresh();
        }

        private void buttonClassify_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Neural_Network pretrainedNN = new Neural_Network();
                image = new Bitmap(image, 50, 50);
                double[,] input = ImageProcessing.imageToGrayscale(image);
                ReadData.normalizeImage(ref input);
                PCA pca = new PCA();
                pca.readPretrainedWeights();
                input=Utilities.addBias(pca.compress(input));
                textBoxClassification.Text = pretrainedNN.classify(input);

            }           
            else 
                MessageBox.Show("Enter picture first");
        }




    }
}
