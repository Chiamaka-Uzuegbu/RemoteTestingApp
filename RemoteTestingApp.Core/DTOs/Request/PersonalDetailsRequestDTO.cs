using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Core.DTOs.Request
{
    public class PersonalDetailsRequestDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Firstname cannot be null or empty")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30,MinimumLength =2,ErrorMessage ="Lastname cannot be null or empty")]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Address cannot be null or empty")]
        public string HouseAddress { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "NextOfKin FirstName cannot be null or empty")]
        public string NextOfKinFirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "NextOfKin LastName cannot be null or empty")]
        public string NextOfKinLastName { get; set; }

        [Required]
        [Phone]
        public string NextOfKinPhoneNumber { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "NextOfKin Address cannot be null or empty")]
        public string NextOfKinAddress { get; set; }

        [Required]
        public string RelationshipWithNextOfKin { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string RelationShipStatus { get; set; }

        [Required]
        public string Religion { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Gaurantor FirstName cannot be null or empty")]
        public string GaurantorFirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Gaurantor LastName cannot be null or empty")]
        public string GaurantorLastName { get; set; }

        [Required]
        [Phone]
        public string GaurantorPhone { get; set; }
    }
}
