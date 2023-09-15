using onmViz.DAL.Model;
using onmViz.DAL.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace onmViz.Stream
{
    public partial class FetchAPI : Form
    {
        public FetchAPI()
        {
            InitializeComponent();
        }
        private void FetchAPI_Load(object sender, EventArgs e)
        {
            InitComboBox();
        }

        public void EndPointAPI()
        {
            //var httpFetch = new 
        }

        public void InitComboBox()
        {
            try
            {
                List<PBox> pBox;
                using (var db = new onmVizDBContext())
                {
                    pBox = db.PictureBoxes.ToList();
                }
                if (pBox != null)
                {
                    foreach (var PB in pBox)
                    {
                        comboBox1.Items.Add(PB.PictureBoxName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deu erro: {ex.Message}");
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 == null)
            {
                MessageBox.Show($"Digite palca do veiculo");
                return;
            }
            if (comboBox1.SelectedIndex != -1)
            {
                PBox pBox;
                using(var db = new onmVizDBContext())
                {
                    pBox = db.PictureBoxes.Where(d => d.PictureBoxName == comboBox1.Text).FirstOrDefault();
                }
                int IDRecurso = pBox.IDRecurso;
                string placaAuto = textBox1.Text;
                MessageBox.Show($"Parametros: {IDRecurso}\n{placaAuto}");
                return;
            }
            MessageBox.Show($"Combobox vazia");
        }
    }
}
