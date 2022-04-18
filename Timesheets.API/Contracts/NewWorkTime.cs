﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.API.Contracts
{
    public class NewWorkTime
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        [Range(1, 24)]
        public int Hours { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}