﻿using System;
using System.Collections.Generic;

namespace iKnow.BLL.Models
{
    public class EmailModel
    {
        public string FromAdressTitle { get; set; }
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string BodyContent { get; set; }
        public DateTime SendingTime { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
