﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string CarName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
       
    }
}
