﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Persistence
{
    public class DataException : Exception
    {
        public DataException() { }
        public DataException(string msg) : base(msg) { }
    }
}
