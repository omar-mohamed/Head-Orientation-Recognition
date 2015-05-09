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
    public partial class TrainRadialBasis : Form
    {
        public TrainRadialBasis()
        {
            InitializeComponent();
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked)
                ReadData.readCompressedData();
            else
                ReadData.readSmallCompressedData();
            RadialBasisNet RB = new RadialBasisNet();
            Tuple<double, double[,]> t= RB.train(Convert.ToInt32(textBoxLayers.Text), Convert.ToInt32(textBoxNum_Iteraions.Text), Convert.ToDouble(textBoxEta.Text));
            ConfusionMatrix CM = new ConfusionMatrix();
            CM.fillMatrix(t.Item2);
            textBoxAccuracy.Text = t.Item1.ToString() + '%';
            CM.Show();
        }
    }
}
