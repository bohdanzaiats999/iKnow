using iKnow.BLL.Models;

namespace iKnow.BLL.Interfaces
{
    public interface IExcerciseService
    {
        void AddArray(ExcerciseModel excerciseModel);
        int Excercise1_FindIt(int[] seq);
    }
}
