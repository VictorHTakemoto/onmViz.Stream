using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using onmViz.DAL.Model;
using onmViz.DAL.Model.Entity;
using RestSharp;
using System.Data;
using File = System.IO.File;
using System;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;

namespace onmViz.Stream
{
    public partial class FetchAPI : Form
    {
        public ResponseAPI responseAPI = new();

        private VideoCapture _videoCapture1;

        public FetchAPI()
        {
            InitializeComponent();
        }
        private void FetchAPI_Load(object sender, EventArgs e)
        {
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            _videoCapture1.ImageGrabbed -= _videoCapture1_ImageGrabbed;
            _videoCapture1.Stop();
            _videoCapture1.Dispose();
            _videoCapture1 = null;
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var message = "Teste";
            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(TxtBoxJustificativa.Text))
                {
                    button1.Enabled = false;
                    button1.Text = "Processando...";
                    PBox pBox;
                    using (var db = new onmVizDBContext())
                    {
                        pBox = db.PictureBoxes.Where(d => d.PictureBoxName == textBox2.Text).FirstOrDefault();
                    }
                    string IDRecurso = pBox.IDRecurso.ToString();
                    string placaAuto = textBox1.Text;
                    await Task.Run(() => CallAPI(IDRecurso, placaAuto));
                    await SaveLog(currentIdentity.Name, TxtBoxJustificativa.Text, placaAuto, textBox2.Text);

                    button1.Enabled = true;
                    button1.Text = "Confirmar";
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Preencha os campos placa e Justificativa");
                return;
            }
        }


        public async Task CallAPI(string id, string placa)
        {
            try
            {
                string paramsJson = AppContext.BaseDirectory + "\\paramsUrl.json";
                JObject globalParams = JObject.Parse(File.ReadAllText(paramsJson));
                var options = new RestClientOptions($"{globalParams["Http"]}{globalParams["Porta"]}")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest($"/api/Operacao/PlacaManual?IDRecurso={id}&placa={placa}", Method.Post);

                RestResponse response = await client.ExecuteAsync(request);
                //MessageBox.Show($"Teste: {response.Content}");
                if (response.IsSuccessful)
                {
                    responseAPI = JsonConvert.DeserializeObject<ResponseAPI>(response.Content);
                    MessageBox.Show($"Tipo: {responseAPI.tipo}\n" +
                                          $"Informação: {responseAPI.informacao}\n" +
                                          $"Mensagem: {responseAPI.mensagem}");
                    return;
                }
                else
                {
                    MessageBox.Show("Deu erro");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deu Erro {ex.Message}");
            }
        }

        public void StartImageOne(string rtsp)
        {
            try
            {
                if (rtsp != null)
                {
                    _videoCapture1 = new VideoCapture(rtsp);
                    if (!_videoCapture1.IsOpened)
                    {
                        MessageBox.Show($"Nao foi possivel conectar");
                        return;
                    }
                    _videoCapture1.ImageGrabbed += _videoCapture1_ImageGrabbed;
                    _videoCapture1.Start();
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

        private void _videoCapture1_ImageGrabbed(object? sender, EventArgs e)
        {
            Mat mat = new Mat();
            _videoCapture1.Retrieve(mat);
            Image<Bgr, byte> scale = ScaleImage(mat.ToImage<Bgr, byte>(), pictureBox1);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = scale.ToBitmap();
        }
        private Image<Bgr, byte> ScaleImage(Image<Bgr, byte> image, PictureBox pic)
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

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();

            if (currentIdentity != null)
            {
                MessageBox.Show($"Nome de Usuário: {currentIdentity.Name}\n" +
                                $"Tipo: {responseAPI.tipo}\n" +
                                $"Informação: {responseAPI.informacao}\n" +
                                $"Mensagem: {responseAPI.mensagem}");
                currentIdentity.Dispose();
            }
        }

        public async Task SaveLog(string user, string message, string plate, string bridge)
        {
            using (var db = new onmVizDBContext())
            {
                var justificationLog = new JustificationLog
                {
                    User = user,
                    JustificationMessage = message,
                    LicensePlate = plate,
                    ScaleBridge = bridge,
                    JustificarionDateTime = DateTime.Now,
                };
                var integrationLog = new IntegrationLog
                {
                    Tipo = responseAPI.tipo,
                    Info = responseAPI.informacao,
                    Message = responseAPI.mensagem,
                    IntegrationDateTime = DateTime.Now,
                };
                justificationLog.IntegrationLog = integrationLog;
                integrationLog.JustificationLog = justificationLog;

                db.JustificationLogs.Add(justificationLog);
                db.SaveChanges();
            }
        }
    }
}
