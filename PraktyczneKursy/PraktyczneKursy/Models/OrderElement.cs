namespace PraktyczneKursy.Models
{
    public class OrderElement
    {
        public int OrderElementIdMyProperty { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }
        public int Quatity { get; set; }
        public decimal PurchaseValue { get; set; }

        public virtual Course Course { get; set; }
        public virtual Order Order { get; set; }
    }   
}