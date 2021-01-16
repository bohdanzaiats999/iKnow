using iKnow.BLL.Models;
using System.Collections.Generic;


namespace iKnow.BLL.Interfaces
{
   public interface IUserService
    {
        void Registration(UserModel userModel);
        void Login(UserModel userModel);
        int GetRoleId();
        IList<UserModel> GetAllUsers();
    }
}
