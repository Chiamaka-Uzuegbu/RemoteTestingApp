using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Core.DTOs.Response
{
    public class RegisteredUserResponseDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public Guid   UserUniqueID { get; set; }
    }
}
