using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuncExecutor.Models
{
    public class IndicatorModel
    {
        public int Id { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedAt { get; set; }
        [MaxLength(256)]
        public string Code { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        [MaxLength(10)]
        public string TypeDescr { get; set; }
        [MaxLength(1024)]
        public string? Func { get; set; }
    }
}
