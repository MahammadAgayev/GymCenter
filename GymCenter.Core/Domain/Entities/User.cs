﻿using System;

namespace GymCenter.Core.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; } 
    }
}
