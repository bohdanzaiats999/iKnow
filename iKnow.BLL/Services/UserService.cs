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
                Database.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Login(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public int GetRoleId()
        {
            throw new System.NotImplementedException();
        }

        // Get all users
        public IList<UserModel> GetAllUsers()
        {
            IList<UserEntity> userEntities = Database.Repository<UserEntity>().GetAll().ToList();

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<UserEntity, UserModel>()
            .ForMember("Email", f => f.MapFrom(x => x.Email.EmailAdress)));
            var userModelList = new Mapper(config).Map<IList<UserModel>>(userEntities);

            return userModelList;
        }
    }
}
