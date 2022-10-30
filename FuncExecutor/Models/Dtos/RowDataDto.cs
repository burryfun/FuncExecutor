using Newtonsoft.Json;

namespace FuncExecutor.Models.Dtos
{
    public class RowDataDto
    {
        [JsonProperty("indicatorId")]
        public int IndicatorId { get; set; }
        [JsonProperty("value")]
        public float? Value { get; set; }
    }
}
