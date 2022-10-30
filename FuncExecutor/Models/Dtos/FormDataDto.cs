using Newtonsoft.Json;

namespace FuncExecutor.Models.Dtos
{
    public class FormDataDto
    {
        [JsonProperty("formName")]
        public string FormName { get; set; }
        [JsonProperty("rows")]
        public RowDataDto[] Rows { get; set; }
    }
}
