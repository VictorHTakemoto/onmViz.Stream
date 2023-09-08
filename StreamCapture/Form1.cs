using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using onmViz.DAL.Model;
using onmViz.DAL.Model.Entity;
using Microsoft.EntityFrameworkCore.SqlServer;
using onmViz.DAL;
using Device = onmViz.DAL.Model.Entity.Device;

namespace StreamCapture
{
    public partial class Form1 : Form
    {
        //private string _rtsp = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c3/s0/live";
        //private string _rtsp1;
        private VideoCapture _SmallCap1F;
        private VideoCapture _SmallCap2R;

        private VideoCapture _SmallCap3F;
        private VideoCapture _SmallCap4R;

        private VideoCapture _SmallCap5F;
        private VideoCapture _SmallCap6R;

        private VideoCapture _SmallCap7F;
        private VideoCapture _SmallCap8R;

        private int _WideCap1F;
        private int _WideCap1R;

        private int _WideCap2F;
        private int _WideCap2R;

        private int _WideCap3F;
        private int _WideCap3R;

        private int _WideCap4F;
        private int _WideCap4R;


        private VideoCapture _capture3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Show(object sender, EventArgs e)
        {
            InitPic1();
            //InitPic2();
            //InitPic3();
            //InitPic4();
            //InitPic5();
            //InitPic6();
            //InitPic7();
            //InitPic8();
        }

        //Cancela 1
        #region
        //PictureBox 1
        private void InitPic1()
        {
            try
            {
                string rtspUrl1 = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c1/s0/live";
                _SmallCap1F = new VideoCapture(0);
                _SmallCap1F.ImageGrabbed += _capture1_ImageGrabbed;
                _SmallCap1F.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Deu Problema: {ex}");
            }
        }

        private void _capture1_ImageGrabbed(object? sender, EventArgs e)
        {
            Mat mat = new Mat();
            _SmallCap1F.Retrieve(mat);
            Image<Bgr, byte> scaleFrameSmall = ScaleStreaming(mat.ToImage<Bgr, byte>(), pictureBox1);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = scaleFrameSmall.ToBitmap();
            if (_WideCap1F == 1)
            {
                Image<Bgr, byte> scaleFrameWide = ScaleStreaming(mat.ToImage<Bgr, byte>(), WideBox1);
                WideBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                WideBox1.Image = scaleFrameWide.ToBitmap();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_SmallCap1F != null)
            {
                _WideCap1F = 1;
                if (_WideCap1R == 1)
                {
                    _WideCap1R = 0;
                }
            }
        }

        //PictureBox 2
        private void InitPic2()
        {
            try
            {
                string rtspUrl2 = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c2/s0/live";
                _SmallCap2R = new VideoCapture(rtspUrl2);
                _SmallCap2R.ImageGrabbed += _capture2_ImageGrabbed;
                _SmallCap2R.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _capture2_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _SmallCap2R.Retrieve(mat);
                Image<Bgr, byte> scaleFrameSmall = ScaleStreaming(mat.ToImage<Bgr, byte>(), pictureBox2);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = scaleFrameSmall.ToBitmap();
                if (_WideCap1R == 1)
                {
                    Image<Bgr, byte> scaleFrameWide = ScaleStreaming(mat.ToImage<Bgr, byte>(), WideBox1);
                    WideBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    WideBox1.Image = scaleFrameSmall.ToBitmap();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (_SmallCap2R != null)
            {
                _WideCap1R = 1;
                if (_WideCap1F == 1)
                {
                    _WideCap1F = 2;
                }
            }
        }
        #endregion

        //Cancela 2
        #region
        //PictureBox 3
        private void InitPic3()
        {
            try
            {
                string rtsp3 = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c3/s0/live";
                _SmallCap3F = new VideoCapture(rtsp3);
                _SmallCap3F.ImageGrabbed += _SmallCap3F_ImageGrabbed;
                _SmallCap3F.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void _SmallCap3F_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _SmallCap3F.Retrieve(mat);
                Image<Bgr, byte> scaleFrameSmall = ScaleStreaming(mat.ToImage<Bgr, byte>(), pictureBox3);
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox3.Image = scaleFrameSmall.ToBitmap();
                if (_WideCap2F == 1)
                {
                    WideBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image<Bgr, byte> scaleFrameWide = ScaleStreaming(mat.ToImage<Bgr, byte>(), WideBox2);
                    WideBox2.Image = scaleFrameWide.ToBitmap();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (_SmallCap3F != null)
            {
                _WideCap2F = 1;
                if (_WideCap2R == 1)
                {
                    _WideCap2R = 0;
                }
            }
        }
        private void InitPic4()
        {
            try
            {
                string rtsp4 = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c4/s0/live";
                _SmallCap4R = new VideoCapture(rtsp4);
                _SmallCap4R.ImageGrabbed += _SmallCap4R_ImageGrabbed;
                _SmallCap4R.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        private void _SmallCap4R_ImageGrabbed(object? sender, EventArgs e)
        {
            Mat mat = new Mat();
            _SmallCap4R.Retrieve(mat);
            Image<Bgr, byte> scaleFrameSmall = ScaleStreaming(mat.ToImage<Bgr, byte>(), pictureBox4);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = scaleFrameSmall.ToBitmap();
            if (_WideCap2R == 1)
            {
                WideBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                Image<Bgr, byte> scaleFW = ScaleStreaming(mat.ToImage<Bgr, byte>(), WideBox2);
                WideBox2.Image = scaleFW.ToBitmap();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (_SmallCap4R != null)
            {
                _WideCap2R = 1;
                if (_WideCap2F == 1)
                {
                    _WideCap2F = 0;
                }
            }
        }

        #endregion

        //Cancela 3
        #region
        private void InitPic5()
        {
            try
            {
                string rtspUrl5 = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c5/s0/live";
                _SmallCap5F = new VideoCapture(rtspUrl5);
                _SmallCap5F.ImageGrabbed += _SmallCap5F_ImageGrabbed;
                _SmallCap5F.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        private void _SmallCap5F_ImageGrabbed(object? sender, EventArgs e)
        {
            Mat mat = new Mat();
            _SmallCap5F.Retrieve(mat);
            Image<Bgr, byte> scaleFS = ScaleStreaming(mat.ToImage<Bgr, byte>(), pictureBox5);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.Image = scaleFS.ToBitmap();
            if (_WideCap3F == 1)
            {
                WideBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                Image<Bgr, byte> scaleFW = ScaleStreaming(mat.ToImage<Bgr, byte>(), WideBox3);
                WideBox3.Image = scaleFW.ToBitmap();
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (_SmallCap5F != null)
            {
                _WideCap3F = 1;
                if (_WideCap3R == 1)
                {
                    _WideCap3R = 0;
                }
            }
        }

        private void InitPic6()
        {
            try
            {
                string rtspUrl5 = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c6/s0/live";
                _SmallCap6R = new VideoCapture(rtspUrl5);
                _SmallCap6R.ImageGrabbed += _SmallCap6R_ImageGrabbed; ;
                _SmallCap6R.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        private void _SmallCap6R_ImageGrabbed(object? sender, EventArgs e)
        {
            Mat mat = new Mat();
            _SmallCap6R.Retrieve(mat);
            Image<Bgr, byte> scaleFrameSmall = ScaleStreaming(mat.ToImage<Bgr, byte>(), pictureBox6);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.Image = scaleFrameSmall.ToBitmap();
            if (_WideCap3R == 1)
            {
                WideBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                Image<Bgr, byte> scaleFrameWide = ScaleStreaming(mat.ToImage<Bgr, byte>(), WideBox3);
                WideBox3.Image = scaleFrameWide.ToBitmap();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (_SmallCap6R != null)
            {
                _WideCap3R = 1;
                if (_WideCap3F == 1)
                {
                    _WideCap3F = 0;
                }
            }
        }
        #endregion

        //Cancela 4
        #region
        private void InitPic7()
        {
            try
            {
                string rtspUrl1 = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c7/s0/live";
                _SmallCap7F = new VideoCapture(rtspUrl1);
                _SmallCap7F.ImageGrabbed += _SmallCap7F_ImageGrabbed;
                _SmallCap7F.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deu Problema: {ex}");
            }
        }

        private void _SmallCap7F_ImageGrabbed(object? sender, EventArgs e)
        {
            Mat mat = new Mat();
            _SmallCap7F.Retrieve(mat);
            Image<Bgr, byte> scaleFrameSmall = ScaleStreaming(mat.ToImage<Bgr, byte>(), pictureBox7);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.Image = scaleFrameSmall.ToBitmap();
            if (_WideCap4F == 1)
            {
                WideBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                Image<Bgr, byte> scaleFrameWide = ScaleStreaming(mat.ToImage<Bgr, byte>(), WideBox4);
                WideBox4.Image = scaleFrameWide.ToBitmap();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (_SmallCap7F != null)
            {
                _WideCap4F = 1;
                if (_WideCap4R == 1)
                {
                    _WideCap4R = 0;
                }
            }
        }

        private void InitPic8()
        {
            try
            {
                string rtspUrl8 = "rtsp://admin:OniumNVRDev08-@192.168.18.10:554/unicast/c8/s0/live";
                _SmallCap8R = new VideoCapture(rtspUrl8);
                _SmallCap8R.ImageGrabbed += _SmallCap8R_ImageGrabbed; ;
                _SmallCap8R.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deu Problema: {ex}");
            }
        }

        private void _SmallCap8R_ImageGrabbed(object? sender, EventArgs e)
        {
            Mat mat = new Mat();
            _SmallCap8R.Retrieve(mat);
            Image<Bgr, byte> scaleFrameSmall = ScaleStreaming(mat.ToImage<Bgr, byte>(), pictureBox8);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.Image = scaleFrameSmall.ToBitmap();
            if (_WideCap4R == 1)
            {
                WideBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                Image<Bgr, byte> scaleFrameWide = ScaleStreaming(mat.ToImage<Bgr, byte>(), WideBox4);
                WideBox4.Image = scaleFrameWide.ToBitmap();
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (_SmallCap8R != null)
            {
                _WideCap4R = 1;
                if (_WideCap4F == 1)
                {
                    _WideCap4F = 0;
                }
            }
        }
        #endregion

        private Image<Bgr, byte> ScaleStreaming(Image<Bgr, byte> image, PictureBox pic)
        {
            float aspectRatio = image.Width / image.Height;
            int newWidth, newHeight;

            if (aspectRatio > 1)
            {
                newWidth = pic.Width;
                newHeight = (int)(pic.Width / aspectRatio);
            }
            else
            {
                newHeight = pic.Height;
                newWidth = (int)(pic.Height * aspectRatio);
            }
            return image.Resize(newWidth, newHeight, Inter.Linear);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}