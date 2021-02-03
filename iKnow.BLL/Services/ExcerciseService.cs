using iKnow.BLL.Interfaces;
using iKnow.DAL.Entityes;
using iKnow.DAL.Interfaces;
using iKnow.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace iKnow.BLL.Services
{
    public class ExcerciseService : IExcerciseService
    {
        IUnitOfWork Database;
        public ExcerciseService() => Database = new UnitOfWork();

        public void AddNumberArray(int[] arr)
        {
        }

        public int Excercise1_FindIt(int[] seq)
        {
            //Given an array of integers, find the one that appears an odd number of times.
            //There will always be only one integer that appears an odd number of times.

            //For examle
            //new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 };

            for (int i = 0; i < seq.Length; i++)
            {
                for (int j = 0; j < seq.Length - 1; j++)
                {
                    if (seq[j] > seq[j + 1])
                    {
                        int temp = seq[j + 1];
                        seq[j + 1] = seq[j];
                        seq[j] = temp;
                    }
                }
            }
            return -1;
        }
    }
}
