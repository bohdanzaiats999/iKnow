namespace iKnow.DAL.Entityes
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }

        public int PhoneId { get; set; }
        public PhoneEntity Phone { get; set; }
    }
}
