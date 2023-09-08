// See https://aka.ms/new-console-template for more information
using onmViz.DAL.Model;
using onmViz.DAL.Model.Entity;

Console.WriteLine("Hello, World!");
List<Device> device;
PBox pBox;
using (var db = new onmVizDBContext())
{
    device = db.Devices.ToList();
    pBox = db.PictureBoxes.Where(d => d.PictureBoxId == 1).FirstOrDefault();
    //device = db.Devices.Where(d => d.DeviceId == 1).FirstOrDefault();
    Console.WriteLine(pBox.Device.IPAddress);
}
