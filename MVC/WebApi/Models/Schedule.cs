﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Schedule
    {
        public DateTime Date { get; set; }
        public int? RentId { get; set; }
        public int? ClassId { get; set; }
        public string ClassName { get; set; }

        public virtual Member Rent { get; set; }
    }
}