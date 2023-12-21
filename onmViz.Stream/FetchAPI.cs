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

namespace onmViz.Stream
{
    public partial class FetchAPI : Form
    {
        private VideoCapture _videoCapture1;

        public FetchAPI()
        {
            InitializeComponent();
        }
        private void FetchAPI_Load(object sender, EventArgs e)
        {
            InitComboBox();
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
            _videoCapture1.ImageGrabbed -= _videoCapture1_ImageGrabbed;
            _videoCapture1.Stop();
            _videoCapture1.Dispose();
            _videoCapture1 = null;
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show($"Digite placa do veiculo");
                return;
            }
            if (comboBox1.SelectedIndex != -1)
            {
                PBox pBox;
                using (var db = new onmVizDBContext())
                {
                    pBox = db.PictureBoxes.Where(d => d.PictureBoxName == comboBox1.Text).FirstOrDefault();
                }
                string IDRecurso = pBox.IDRecurso.ToString();
                string placaAuto = textBox1.Text;

                await CallAPI(IDRecurso, placaAuto);
                return;
            }
            MessageBox.Show($"Combobox vazia");
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
                    ResponseAPI resultado = JsonConvert.DeserializeObject<ResponseAPI>(response.Content);
                    MessageBox.Show($"Tipo: {resultado.tipo}\n" +
                                    $"Informação: {resultado.informacao}\n" +
                                    $"Mensagem: {resultado.mensagem}");
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
    }
}
