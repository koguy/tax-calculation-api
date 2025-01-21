using System.ComponentModel.DataAnnotations;

namespace TaxCalculatorApi.Repository.Entity
{
    public class TaxBand
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int LowerLimit { get; set; }
        public int? UpperLimit { get; set; }
        public int Rate { get; set; }
    }
}
