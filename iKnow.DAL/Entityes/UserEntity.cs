namespace iKnow.DAL.Entityes
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public EmailEntity Email { get; set; }
    }
}
