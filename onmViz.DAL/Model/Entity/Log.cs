using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace onmViz.DAL.Model.Entity
{
    public class Log
    {
        [Key]
        public Guid LogId { get; set; }
        public string User {  get; set; }
        public string JustificationMessage {  get; set; }
        public string LicensePlate {  get; set; }
        public string WeighBridge { get; set; }
        public DateTime DateTimeLogs { get; set; }

        public Log() 
        {
            LogId = Guid.NewGuid();
        }
    }
}
