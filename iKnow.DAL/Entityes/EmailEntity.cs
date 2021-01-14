using System;
using System.Collections.Generic;

namespace iKnow.DAL.Entityes
{
    public class EmailEntity
    {
        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public string FromAdressTitle { get; set; }
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string BodyContent { get; set; }
        public DateTime SendingTime { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
