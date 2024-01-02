using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onmViz.DAL.Model.Entity
{
    public class JustificationLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JustificationLogId { get; set; }
        public string User { get; set; }
        public string JustificationMessage { get; set; }
        public string LicensePlate { get; set; }
        public string ScaleBridge { get; set; }
        public DateTime JustificarionDateTime { get; set; }
        public virtual IntegrationLog IntegrationLog { get; set; }
    }
}
