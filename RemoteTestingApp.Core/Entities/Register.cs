using System;
using System.ComponentModel.DataAnnotations;

namespace RemoteTestingApp.Core.Entities
{
    public class Register
    {
        public int id { get; set; }

        public string Email { get; set; }

        public byte[] passwordHash { get; set; } 
        
        public byte[] passwordSalt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid UserUniqueIdentifier { get; set; }

    }
}
