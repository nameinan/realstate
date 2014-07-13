using mongohome.ui.Models;

namespace mongohome.ui.Rental
{
    public class PriceAdjustment
    {
        public PriceAdjustment(AdjustPrice adjustPrice, decimal oldPrice)
        {
            NewPrice = adjustPrice.NewPrice;
            OldPrice = oldPrice;
            Reason = adjustPrice.Reason;
        }

        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string  Reason { get; set; }

        public string Describe()
        {
            var describe = string.Format("{0} -> {1} : {2}", OldPrice, NewPrice, Reason);
            return describe;
        }
    }
}