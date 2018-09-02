namespace IParserService.Models
{
    public class Expense
    {
        public decimal TotalInclGst { get; set; }

        public decimal TotalExclGst => TotalInclGst / 1.15M;

        public decimal Gst => TotalInclGst - TotalExclGst;

        public string CostCentre { get; set; }
    }
}
