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
                string paramsJson = AppContext.BaseDirectory + "\\params.json";
                JObject globalParams = JObject.Parse(File.ReadAllText(paramsJson));
                var options = new RestClientOptions($"{globalParams["Http"]}{globalParams["Porta"]}")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest($"/api/Operacao/ProcessarManual?IDRecurso={id}&placa={placa}", Method.Post);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deu Erro {ex.Message}");
            }
        }

    }
}
