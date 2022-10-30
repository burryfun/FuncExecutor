namespace FuncExecutor.Models.ViewModels
{
    public class RowDataViewModel
    {
        public int IndicatorId { get; set; }
        public string IndicatorCode { get; set; }
        public string IndicatorDescription { get; set; }
        public string IndicatorTypeDescr { get; set; }
        public string? IndicatorFunc { get; set; }
        public string FormName { get; set; }
        public int ValueId { get; set; }
        public float? Value { get; set; }
    }
}
