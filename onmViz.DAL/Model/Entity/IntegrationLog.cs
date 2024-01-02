using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onmViz.DAL.Model.Entity
{
    public class IntegrationLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntregrationId { get; set; }
        public string Tipo { get; set; }
        public string Info { get; set; }
        public string Message { get; set; }
        public DateTime IntegrationDateTime { get; set; }
        public int JustificationLogId { get; set; }
        public virtual JustificationLog JustificationLog { get; set; }
    }
}
