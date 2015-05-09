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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trainButtonBp_Click(object sender, EventArgs e)
        {
            TrainBackPropagation BP = new TrainBackPropagation();
            BP.Show();
        }

        private void trainButtonRB_Click(object sender, EventArgs e)
        {
            TrainRadialBasis RB = new TrainRadialBasis();
            RB.Show();
        }

        private void classifyInputButton_Click(object sender, EventArgs e)
        {
            ClassifyInput CI = new ClassifyInput();
            CI.Show();
        }

        private void compressImages_Click(object sender, EventArgs e)
        {
            CompressPCAForm Pca = new CompressPCAForm();
            Pca.Show();
        }

    }
}
