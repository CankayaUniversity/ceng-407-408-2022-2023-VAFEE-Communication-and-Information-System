﻿using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

