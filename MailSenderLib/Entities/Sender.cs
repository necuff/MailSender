﻿using MailSenderLib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Entities
{
    public class Sender : PersonEntity
    {       
        public override string ToString() => $"{Name}:{Address}";
    }
}
