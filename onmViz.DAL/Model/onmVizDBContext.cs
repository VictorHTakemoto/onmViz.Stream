using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using onmViz.DAL.Model.Entity;

namespace onmViz.DAL.Model
{
    public partial class onmVizDBContext : DbContext
    {
        public onmVizDBContext() { }

        public onmVizDBContext(DbContextOptions<onmVizDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string paramsJson = AppContext.BaseDirectory + "\\params.json";
            JObject globalParams = JObject.Parse(File.ReadAllText(paramsJson));
            try
            {
                if (globalParams["NomeAppSettings"] != null && globalParams["DBConnection"] != null)
                {
                    IConfigurationRoot config = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile(globalParams["NomeAppSettings"].ToString())
                        .Build();
                    optionsBuilder.UseSqlServer(
                        config.GetConnectionString(globalParams["DBConnection"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
        public DbSet<PBox> PictureBoxes { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
