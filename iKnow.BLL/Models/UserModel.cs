namespace iKnow.BLL.Models
{
    public class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool Checked { get; set; }
    }
}
