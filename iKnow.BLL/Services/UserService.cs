using AutoMapper;
using iKnow.BLL.Interfaces;
using iKnow.BLL.Models;
using iKnow.BLL.Security;
using iKnow.DAL.Entityes;
using iKnow.DAL.Interfaces;
using iKnow.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iKnow.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        private static int RoleId { get; set; }

        public UserService() => Database = new UnitOfWork();

        // Get user role
        public int GetIdRole() => RoleId;

        // Register a new user
        public void Registration(UserModel userModel)
        {
            UserEntity user = Database.Repository<UserEntity>().GetByLogin(userModel.Login);

            if (user != null)
            {
                throw new Exception("User already exist");
            }
            try
            {
                Database.Repository<UserEntity>().Insert(new UserEntity
                {
                    Login = userModel.Login,
                    Password = new AesCrypt().GetEncryptedPassword(userModel.Password),
                    Email = new EmailEntity { EmailAdress = userModel.Email },
                    RoleId = userModel.RoleId
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                Database.SaveChanges();
        }

        public void Login(UserModel userModel)
        {
            UserEntity user = Database.Repository<UserEntity>().GetByLogin(userModel.Login);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            string encryptedPassword = new AesCrypt().GetEncryptedPassword(userModel.Password);

            // Compare password in database and user password
            if (user.Password != encryptedPassword)
            {
                throw new Exception("Password is wrong");
            }
            RoleId = user.RoleId;
        }

        public int GetRoleId()
        {
            throw new System.NotImplementedException();
        }

        // Get all users
        public IList<UserModel> GetAllUsers()
        {
            IList<UserEntity> userEntities = Database.Repository<UserEntity>().Include(e=>e.Email).ToList();

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<UserEntity, UserModel>()
            .ForMember("Email", f => f.MapFrom(x => x.Email.EmailAdress)));
            return new Mapper(config).Map<IList<UserModel>>(userEntities);


        }
    }
}
