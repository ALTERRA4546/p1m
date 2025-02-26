﻿using System.ComponentModel.DataAnnotations;

namespace WarehouseAccounting.Model
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
