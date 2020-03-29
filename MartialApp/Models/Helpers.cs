﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartialApp.Models
{
    public static class Helpers
    {
        public static object ToDBNullOrDefault(this object obj) {
            return obj ?? DBNull.Value;
        }
    }
}
