﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces;

namespace UrlShortener.Core.Models
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
    }
}