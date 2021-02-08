using iKnow.BLL.Models;

namespace iKnow.BLL.Interfaces
{
    public interface IExcerciseService
    {
        void AddArray(ExcerciseModel excerciseModel);
        int Excercise1_FindOdd(int[] seq);
        string Excercise2_RepeatString(int times, string value);
    }
}
