using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using onmViz.DAL.Model;
using onmViz.DAL.Model.Entity;
using static Azure.Core.HttpHeader;

namespace onmViz.Stream
{
    public partial class Form1 : Form
    {
        //Threads Globais
        private Thread _ThreadCamera1;
        private Thread _ThreadCamera2;
        private Thread _ThreadCamera3;
        private Thread _ThreadCamera4;
        private Thread _ThreadCamera5;
        private Thread _ThreadCamera6;
        private Thread _ThreadCamera7;
        private Thread _ThreadCamera8;
        private Thread _ThreadCamera9;
        private Thread _ThreadCamera10;
        private Thread _ThreadCamera11;
        private Thread _ThreadCamera12;
        private Thread _ThreadCamera13;
        private Thread _ThreadCamera14;
        private Thread _ThreadCamera15;
        private Thread _ThreadCamera16;

        //VideoCapture global
        private VideoCapture _Cam1;
        private VideoCapture _Cam2;
        private VideoCapture _Cam3;
        private VideoCapture _Cam4;
        private VideoCapture _Cam5;
        private VideoCapture _Cam6;
        private VideoCapture _Cam7;
        private VideoCapture _Cam8;
        private VideoCapture _Cam9;
        private VideoCapture _Cam10;
        private VideoCapture _Cam11;
        private VideoCapture _Cam12;
        private VideoCapture _Cam13;
        private VideoCapture _Cam14;
        private VideoCapture _Cam15;
        private VideoCapture _Cam16;

        public Form1()
        {
            InitializeComponent();
        }

        //TODO:Criar tabela de logs
        //TODO:Implementar layer com o nome de cada local

        //Camera1
        #region
        public void InitPicture1()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 1).FirstOrDefault();
                }
                if (pBox != null)
                {
                    string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam1 = new VideoCapture(rtsp);
                    if (!_Cam1.IsOpened)
                    {
                        MessageBox.Show($"Nao foi possivel conectar: {pBox.Device.IPAddress}");
                        return;
                    }
                    _Cam1.ImageGrabbed += _Cam1_ImageGrabbed;
                    _Cam1.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conexao");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deu Problema: {ex.Message}");
            }
        }
        private void _Cam1_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam1.Retrieve(mat);
                Image<Bgr, byte> scalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera1);
                Camera1.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera1.Image = scalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }
        private void Camera1_Click(object sender, EventArgs e)
        {
            if (_Cam1 != null)
            {
                try
                {
                    FetchAPI fetchAPI = new FetchAPI();
                    fetchAPI.Show();
                    List<Device> devices;
                    PBox pBox;
                    using (var db = new onmVizDBContext())
                    {
                        devices = db.Devices.ToList();
                        pBox = db.PictureBoxes.Where(d => d.Position == 1).FirstOrDefault();
                    }
                    string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    fetchAPI.StartImageOne(rtsp);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Deu Problema: {ex.Message}");
                }
            }
        }
        #endregion
        //Camera2
        #region
        public void InitPicture2()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 2).FirstOrDefault();
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam2 = new VideoCapture(rtsp);
                    if (!_Cam2.IsOpened)
                    {
                        MessageBox.Show($"N�o foi poss�vel conectar: {pBox.Device.IPAddress}");
                        return;
                    }
                    _Cam2.ImageGrabbed += _Cam2_ImageGrabbed;
                    _Cam2.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam2_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam2.Retrieve(mat);
                Image<Bgr, byte> scalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera1);
                Camera2.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera2.Image = scalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            if (_Cam1 != null && _Cam2 != null)
            {
                button1.Text = "Iniciar Cameras";
                _Cam1.ImageGrabbed -= _Cam1_ImageGrabbed;
                _Cam1.Stop();
                _Cam1.Dispose();
                _Cam1 = null;
                Camera1.Image = null;
                _Cam2.ImageGrabbed -= _Cam2_ImageGrabbed;
                _Cam2.Stop();
                _Cam2.Dispose();
                _Cam2 = null;
                Camera2.Image = null;
                return;
            }
            button1.Text = "Parar Cameras";
            _ThreadCamera1 = new Thread(InitPicture1);
            _ThreadCamera1.Start();
            _ThreadCamera2 = new Thread(InitPicture2);
            _ThreadCamera2.Start();
        }
        //Camera3
        #region
        public void InitPicture3()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 3).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 3");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam3 = new VideoCapture(rtsp);
                    if (!_Cam3.IsOpened)
                    {
                        MessageBox.Show($"N�o foi poss�vel conectar: {pBox.Device.IPAddress}");
                        return;
                    }
                    _Cam3.ImageGrabbed += _Cam3_ImageGrabbed; ;
                    _Cam3.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam3_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam3.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera3);
                Camera3.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera3.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Camera3_Click(object sender, EventArgs e)
        {
            if (_Cam3 != null)
            {
                try
                {
                    FetchAPI fetchAPI = new FetchAPI();
                    fetchAPI.Show();
                    List<Device> devices;
                    PBox pBox;
                    using (var db = new onmVizDBContext())
                    {
                        devices = db.Devices.ToList();
                        pBox = db.PictureBoxes.Where(d => d.Position == 3).FirstOrDefault();
                    }
                    string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    fetchAPI.StartImageOne(rtsp);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Deu Problema: {ex.Message}");
                }
            }
        }
        #endregion
        //Camera4
        #region
        public void InitPicture4()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 4).FirstOrDefault();
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam4 = new VideoCapture(rtsp);
                    if (!_Cam4.IsOpened)
                    {
                        MessageBox.Show($"N�o foi poss�vel conectar: {pBox.Device.IPAddress}");
                        return;
                    }
                    _Cam4.ImageGrabbed += _Cam4_ImageGrabbed;
                    _Cam4.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam4_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam4.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera4);
                Camera4.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera4.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            if (_Cam3 != null && _Cam4 != null)
            {
                button2.Text = "Iniciar Cameras";
                _Cam3.ImageGrabbed -= _Cam3_ImageGrabbed;
                _Cam3.Stop();
                _Cam3.Dispose();
                _Cam3 = null;
                Camera3.Image = null;
                _Cam4.ImageGrabbed -= _Cam4_ImageGrabbed;
                _Cam4.Stop();
                _Cam4.Dispose();
                _Cam4 = null;
                Camera4.Image = null;
                return;
            }
            button2.Text = "Parar Cameras";
            _ThreadCamera3 = new Thread(InitPicture3);
            _ThreadCamera4 = new Thread(InitPicture4);
            _ThreadCamera3.Start();
            _ThreadCamera4.Start();
        }
        //Camera5
        #region
        public void InitPicture5()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 5).FirstOrDefault();
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam5 = new VideoCapture(rtsp);
                    _Cam5.ImageGrabbed += _Cam5_ImageGrabbed;
                    _Cam5.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam5_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam5.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera5);
                Camera5.SizeMode = PictureBoxSizeMode.Zoom;
                Camera5.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Camera5_Click(object sender, EventArgs e)
        {
            if (_Cam5 != null)
            {
                FetchAPI fetchAPI = new FetchAPI();
                fetchAPI.Show();
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 5).FirstOrDefault();
                }
                string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                fetchAPI.StartImageOne(rtsp);
            }
        }
        #endregion
        //Camera6
        #region
        public void InitPicture6()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 6).FirstOrDefault();
                }
                if (pBox != null)
                {
                    string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam6 = new VideoCapture(rtsp);
                    _Cam6.ImageGrabbed += _Cam6_ImageGrabbed;
                    _Cam6.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void _Cam6_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam6.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera6);
                Camera6.SizeMode = PictureBoxSizeMode.Zoom;
                Camera6.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        private void button3_Click(object sender, EventArgs e)
        {
            if (_Cam5 != null && _Cam6 != null)
            {
                button3.Text = "Iniciar Cameras";
                _Cam5.ImageGrabbed -= _Cam5_ImageGrabbed;
                _Cam5.Stop();
                _Cam5.Dispose();
                _Cam5 = null;
                Camera5.Image = null;
                _Cam6.ImageGrabbed -= _Cam6_ImageGrabbed;
                _Cam6.Stop();
                _Cam6.Dispose();
                _Cam6 = null;
                Camera6.Image = null;
                return;
            }
            button3.Text = "Parar Cameras";
            _ThreadCamera5 = new Thread(InitPicture5);
            _ThreadCamera6 = new Thread(InitPicture6);
            _ThreadCamera5.Start();
            _ThreadCamera6.Start();
        }
        //Camera7
        #region
        public void InitPicture7()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 7).FirstOrDefault();
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam7 = new VideoCapture(rtsp);
                    _Cam7.ImageGrabbed += _Cam7_ImageGrabbed;
                    _Cam7.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conexao");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void _Cam7_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam7.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera7);
                Camera7.SizeMode = PictureBoxSizeMode.Zoom;
                Camera7.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Camera7_Click(object sender, EventArgs e)
        {
            FetchAPI fetchAPI = new FetchAPI();
            fetchAPI.Show();
            List<Device> devices;
            PBox pBox;
            using (var db = new onmVizDBContext())
            {
                devices = db.Devices.ToList();
                pBox = db.PictureBoxes.Where(d => d.Position == 7).FirstOrDefault();
            }
            string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
            fetchAPI.StartImageOne(rtsp);
        }
        #endregion
        //Camera8
        #region
        public void InitPicture8()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 8).FirstOrDefault();
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam8 = new VideoCapture(rtsp);
                    _Cam8.ImageGrabbed += _Cam8_ImageGrabbed;
                    _Cam8.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam8_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam8.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera8);
                Camera8.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera8.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        private void button4_Click(object sender, EventArgs e)
        {
            if (_Cam7 != null && _Cam8 != null)
            {
                button4.Text = "Iniciar Cameras";
                _Cam7.ImageGrabbed -= _Cam7_ImageGrabbed;
                _Cam7.Stop();
                _Cam7.Dispose();
                _Cam7 = null;
                Camera7.Image = null;
                _Cam8.ImageGrabbed -= _Cam8_ImageGrabbed;
                _Cam8.Stop();
                _Cam8.Dispose();
                _Cam8 = null;
                Camera8.Image = null;
                return;
            }
            button4.Text = "Parar Cameras";
            _ThreadCamera7 = new Thread(InitPicture7);
            _ThreadCamera8 = new Thread(InitPicture8);
            _ThreadCamera7.Start();
            _ThreadCamera8.Start();
        }
        //Camera9
        #region
        public void InitPicture9()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 9).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 8");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam9 = new VideoCapture(rtsp);
                    _Cam9.ImageGrabbed += _Cam9_ImageGrabbed;
                    _Cam9.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam9_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam9.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera9);
                Camera9.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera9.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Camera9_Click(object sender, EventArgs e)
        {
            FetchAPI fetchAPI = new FetchAPI();
            fetchAPI.Show();
            List<Device> devices;
            PBox pBox;
            using (var db = new onmVizDBContext())
            {
                devices = db.Devices.ToList();
                pBox = db.PictureBoxes.Where(d => d.Position == 9).FirstOrDefault();
            }
            string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
            fetchAPI.StartImageOne(rtsp);
        }
        #endregion
        //Camera10
        #region
        public void InitPicture10()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 10).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 8");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam10 = new VideoCapture(rtsp);
                    _Cam10.ImageGrabbed += _Cam10_ImageGrabbed;
                    _Cam10.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void _Cam10_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam10.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera10);
                Camera10.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera10.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        private void button5_Click(object sender, EventArgs e)
        {
            if (_Cam9 != null && _Cam10 != null)
            {
                button5.Text = "Iniciar Cameras";
                _Cam9.ImageGrabbed -= _Cam9_ImageGrabbed;
                _Cam9.Stop();
                _Cam9.Dispose();
                _Cam9 = null;
                Camera9.Image = null;
                _Cam10.ImageGrabbed -= _Cam10_ImageGrabbed;
                _Cam10.Stop();
                _Cam10.Dispose();
                _Cam10 = null;
                Camera10.Image = null;
                return;
            }
            button5.Text = "Parar Cameras";
            _ThreadCamera9 = new Thread(InitPicture9);
            _ThreadCamera10 = new Thread(InitPicture10);
            _ThreadCamera9.Start();
            _ThreadCamera10.Start();
        }
        //Camera11
        #region
        public void InitPicture11()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 11).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 8");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam11 = new VideoCapture(rtsp);
                    _Cam11.ImageGrabbed += _Cam11_ImageGrabbed;
                    _Cam11.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam11_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam11.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera11);
                Camera11.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera11.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Camera11_Click(object sender, EventArgs e)
        {
            FetchAPI fetchAPI = new FetchAPI();
            fetchAPI.Show();
            List<Device> devices;
            PBox pBox;
            using (var db = new onmVizDBContext())
            {
                devices = db.Devices.ToList();
                pBox = db.PictureBoxes.Where(d => d.Position == 11).FirstOrDefault();
            }
            string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
            fetchAPI.StartImageOne(rtsp);
        }
        #endregion

        //Camera12
        #region
        public void InitPicture12()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 12).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 8");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam12 = new VideoCapture(rtsp);
                    _Cam12.ImageGrabbed += _Cam12_ImageGrabbed;
                    _Cam12.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam12_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam12.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera12);
                Camera12.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera12.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        private void button6_Click(object sender, EventArgs e)
        {
            if (_Cam11 != null && _Cam12 != null)
            {
                button6.Text = "Iniciar Cameras";
                _Cam11.ImageGrabbed -= _Cam11_ImageGrabbed;
                _Cam11.Stop();
                _Cam11.Dispose();
                _Cam11 = null;
                Camera11.Image = null;
                _Cam12.ImageGrabbed -= _Cam12_ImageGrabbed;
                _Cam12.Stop();
                _Cam12.Dispose();
                _Cam12 = null;
                Camera12.Image = null;
                return;
            }
            button6.Text = "Parar Cameras";
            _ThreadCamera11 = new Thread(InitPicture11);
            _ThreadCamera12 = new Thread(InitPicture12);
            _ThreadCamera11.Start();
            _ThreadCamera12.Start();
        }
        //Camera13
        #region
        public void InitPicture13()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 13).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 8");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam13 = new VideoCapture(rtsp);
                    _Cam13.ImageGrabbed += _Cam13_ImageGrabbed;
                    _Cam13.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam13_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam13.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera13);
                Camera13.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera13.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Camera13_Click(object sender, EventArgs e)
        {
            FetchAPI fetchAPI = new FetchAPI();
            fetchAPI.Show();
            List<Device> devices;
            PBox pBox;
            using (var db = new onmVizDBContext())
            {
                devices = db.Devices.ToList();
                pBox = db.PictureBoxes.Where(d => d.Position == 13).FirstOrDefault();
            }
            string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
            fetchAPI.StartImageOne(rtsp);
        }
        #endregion

        //Camera14
        #region
        public void InitPicture14()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 14).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 8");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam14 = new VideoCapture(rtsp);
                    _Cam14.ImageGrabbed += _Cam14_ImageGrabbed;
                    _Cam14.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam14_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam14.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera14);
                Camera14.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera14.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        private void button7_Click(object sender, EventArgs e)
        {
            if (_Cam13 != null && _Cam14 != null)
            {
                button7.Text = "Iniciar Cameras";
                _Cam13.ImageGrabbed -= _Cam13_ImageGrabbed;
                _Cam13.Stop();
                _Cam13.Dispose();
                _Cam13 = null;
                Camera13.Image = null;
                _Cam14.ImageGrabbed -= _Cam14_ImageGrabbed;
                _Cam14.Stop();
                _Cam14.Dispose();
                _Cam14 = null;
                Camera14.Image = null;
                return;
            }
            button7.Text = "Parar Cameras";
            _ThreadCamera13 = new Thread(InitPicture13);
            _ThreadCamera13.Start();
            _ThreadCamera14 = new Thread(InitPicture14);
            _ThreadCamera14.Start();
        }

        //Camera15
        #region
        public void InitPicture15()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 15).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 8");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam15 = new VideoCapture(rtsp);
                    _Cam15.ImageGrabbed += _Cam15_ImageGrabbed;
                    _Cam15.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam15_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam15.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera15);
                Camera15.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera15.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void Camera15_Click(object sender, EventArgs e)
        {
            FetchAPI fetchAPI = new FetchAPI();
            fetchAPI.Show();
            List<Device> devices;
            PBox pBox;
            using (var db = new onmVizDBContext())
            {
                devices = db.Devices.ToList();
                pBox = db.PictureBoxes.Where(d => d.Position == 15).FirstOrDefault();
            }
            string rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
            fetchAPI.StartImageOne(rtsp);
        }
        #endregion

        //Camera16
        #region
        public void InitPicture16()
        {
            try
            {
                List<Device> devices;
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    devices = db.Devices.ToList();
                    pBox = db.PictureBoxes.Where(d => d.Position == 16).FirstOrDefault();
                    if (pBox == null)
                    {
                        MessageBox.Show($"Erro ao estabelecer conex�o: Camera 8");
                    }
                }
                if (pBox != null)
                {
                    var rtsp = $"rtsp://{pBox.Device.UserName}:{pBox.Device.Password}@{pBox.Device.IPAddress}:{pBox.Device.RTSPPort}{pBox.Device.RTSPPath}";
                    _Cam16 = new VideoCapture(rtsp);
                    _Cam16.ImageGrabbed += _Cam16_ImageGrabbed;
                    _Cam16.Start();
                }
                else
                {
                    MessageBox.Show("Erro ao estabelecer conex�o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void _Cam16_ImageGrabbed(object? sender, EventArgs e)
        {
            try
            {
                Mat mat = new Mat();
                _Cam16.Retrieve(mat);
                Image<Bgr, byte> escalaPequena = ScaleStreaming(mat.ToImage<Bgr, byte>(), Camera16);
                Camera16.SizeMode = PictureBoxSizeMode.StretchImage;
                Camera16.Image = escalaPequena.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        private void button8_Click(object sender, EventArgs e)
        {
            if (_Cam15 != null && _Cam16 != null)
            {
                button8.Text = "Iniciar Cameras";
                _Cam15.ImageGrabbed -= _Cam15_ImageGrabbed;
                _Cam15.Stop();
                _Cam15.Dispose();
                _Cam15 = null;
                Camera15.Image = null;
                _Cam16.ImageGrabbed -= _Cam16_ImageGrabbed;
                _Cam16.Stop();
                _Cam16.Dispose();
                _Cam16 = null;
                Camera16.Image = null;
                return;
            }
            button8.Text = "Parar Cameras";
            _ThreadCamera15 = new Thread(InitPicture15);
            _ThreadCamera15.Start();
            _ThreadCamera16 = new Thread(InitPicture16);
            _ThreadCamera16.Start();
        }

        //Funcoes utilitarias
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
    }
}