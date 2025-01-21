namespace TaxCalculatorApi.Config
{
    public class TaxBandCacheSettings
    {
        public int SlidingExpirationMinute { get; set; }
        public int AbsoluteExpirationMinute { get; set; }
    }
}
