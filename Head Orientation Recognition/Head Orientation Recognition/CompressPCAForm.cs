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
    public partial class CompressPCAForm : Form
    {
        public CompressPCAForm()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonClassify_Click(object sender, EventArgs e)
        {
            if(textBoxPath.Text!=null)
            {
                ReadData.readUserData(textBoxPath.Text, Convert.ToInt32(outputNumText.Text), Convert.ToDouble(textBoxLearningRate.Text));
                MessageBox.Show("Data has been compressed in 'Compressed User images.txt'\n PCA weights has also been stored in PCA User weights in release folder. ");
            }
        }

    }
}
