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
    public partial class ConfusionMatrix : Form
    {
        public ConfusionMatrix()
        {
            InitializeComponent();
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Front";
            dataGridView1.Columns[1].Name = "Left";
            dataGridView1.Columns[2].Name = "Right";
            dataGridView1.RowCount = 3;
            dataGridView1.Rows[0].HeaderCell.Value = "Front";
            dataGridView1.Rows[1].HeaderCell.Value = "Left";
            dataGridView1.Rows[2].HeaderCell.Value = "Right";
        }

        public void fillMatrix(double[,] arr)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    dataGridView1.Rows[i].Cells[j].Value = arr[i, j];
        }
    }
}
