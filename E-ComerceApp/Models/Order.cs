namespace E_CommerceApp.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public string ApplicationUserId { get; set; }
        public string PhoneNumber {  get; set; }
        public string Address { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
