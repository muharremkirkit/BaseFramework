﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.ProjectBaseEntity
{
   public class Log
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public Nullable<System.DateTime> LoggedDate { get; set; }
        public Nullable<int> LogLevel { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}
