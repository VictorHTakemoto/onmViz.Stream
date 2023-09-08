using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace onmViz.DAL.Model.Entity
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public IPAddress IPAddress { get; set; }
        public string RTSPPort { get; set; }
        public string RTSPPath { get; set; }
        public bool Active { get; set; }
    }
}
