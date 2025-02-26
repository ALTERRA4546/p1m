﻿using System.ComponentModel.DataAnnotations;

namespace WarehouseAccounting.Model
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
