using System.ComponentModel.DataAnnotations;

namespace onmViz.DAL.Model.Entity
{
    public class PBox
    {
        [Key]
        public int PictureBoxId { get; set; }
        public int Position { get; set; }
        public virtual Device Device { get; set; }
    }
}
