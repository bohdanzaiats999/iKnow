using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace iKnow.DAL.Entityes
{
    public class ExcerciseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }

        [NotMapped]
        public string[] _textArray
        {
            get => TextArray.Split(';');
            set => TextArray = string.Join(";", value);
        }
        private string TextArray { get; set; }

        [NotMapped]
        public int[] _numberArray
        {
            get => Array.ConvertAll(NumberArray.Split(';'), Int32.Parse);
            set => NumberArray = string.Join(";", value);
        }
        private string NumberArray { get; set; }
    }
}
