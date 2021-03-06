﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Models.ViewModels
{
    public class PlaceViewModel
    {
        [Key]
        public int PlaceId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Photo_URI { get; set; }

        public string Country { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public bool IsAccepted { get; set; }

        public int Score { get; set; }
        public string ContentPT { get; set; }
        public string ContentPL { get; set; }

    }
}
