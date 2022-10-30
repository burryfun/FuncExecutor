using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuncExecutor.Models
{
    public class ValueModel
    {
        public int Id { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedAt { get; set; }
        [MaxLength(20)]
        public string? FormName { get; set; }
        public int IndicatorId { get; set; }
        public float? Value { get; set; }
    }
}
