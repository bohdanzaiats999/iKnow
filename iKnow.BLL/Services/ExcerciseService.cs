using iKnow.BLL.Interfaces;
using iKnow.BLL.Models;
using iKnow.DAL.Entityes;
using iKnow.DAL.Interfaces;
using iKnow.DAL.Repositories;
using System;
using System.Linq;

namespace iKnow.BLL.Services
{
    public class ExcerciseService : IExcerciseService
    {
        IUnitOfWork Database;
        public ExcerciseService() => Database = new UnitOfWork();

        public void AddArray(ExcerciseModel excerciseModel)
        {
            ExcerciseEntity excerciseEntity = Database?.ExcerciseRepository<ExcerciseEntity>()?.GetByName(excerciseModel.Name);

            if (excerciseEntity != null)
            {
                throw new Exception("This Name already exist");
            }
            try
            {
                Database.UserRepository<ExcerciseEntity>().Insert(new ExcerciseEntity
                {
                    Name = excerciseModel.Name,
                    Number = excerciseModel.Number,
                    Text = excerciseModel.Text,
                    _numberArray = excerciseModel.NumberArray,
                    _textArray = excerciseModel.TextArray
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Database.SaveChanges();


        }
        public int Excercise1_FindOdd(int[] seq)
        {
            // Given an array of integers, find the one that appears an odd number of times.
            // There will always be only one integer that appears an odd number of times.

            // For examle
            // new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 };
            int found = 0;

            foreach (var item in seq)
            {
                found ^= item;
            }
            return found;
        }
        public string Excercise2_RepeatString(int times, string value)
        {
            return String.Concat(Enumerable.Repeat(value, times));
        }
    }
}
