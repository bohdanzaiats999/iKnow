using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace iKnow.DAL.Entityes
{
    public class ExcerciseEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int NumericResult { get; set; }
        public string TextResult { get; set; }

        [NotMapped]
        public string[] _arrayTextResult
        {
            get => ArrayTextResult.Split(';');
            set => ArrayTextResult = string.Join(";", value);
        }
        public string ArrayTextResult { get; set; }

        [NotMapped]
        public int[] _arrayNumericResult
        {
            get => Array.ConvertAll(ArrayNumericResult.Split(';'), Int32.Parse);
            set => ArrayNumericResult = string.Join(";", value);
        }
        public string ArrayNumericResult { get; set; }
    }
}
