using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GetStream
{
    public partial class Form1 : Form
    {
        //static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        VideoCapture capture;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    MessageBox.Show("A camera ja está iniciada");
                    return;
                }
                //string rtspUrl = "rtsp://192.168.18.10:30000/";

                capture = new VideoCapture(0);
                capture.ImageGrabbed += Capture_ImageGrabbed;
                capture.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deu Problema: {ex}");
            
            }
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                capture.Retrieve(mat);
                ProcessarImagem(mat.ToBitmap());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pararGravaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                MessageBox.Show("Camera já esta parada");
                return;
            }

            capture.ImageGrabbed -= Capture_ImageGrabbed;
            capture.Stop();
            capture = null;
            Cam1.Image = null;
        }

        private void ProcessarImagem(Bitmap bitmap)
        {
            //Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap);
            //Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
            //foreach(var rectangle in rectangles)
            //{
            //    using (Graphics graphics = Graphics.FromImage(bitmap))
            //    {
            //        using (Pen pen = new Pen(Color.Blue, 4))
            //        {
            //            graphics.DrawRectangle(pen, rectangle);
            //        }
            //    }
            //}
            Cam1.Image = bitmap; // grayImage.ToBitmap();
        }

        private void Cam1_Click(object sender, EventArgs e)
        {

        }
    }
}
