using System;


namespace RemoteTestingApp.Core.Entities
{
    public class PersonalDetails
    {
        public int id { get; set; }

        public Guid UserDetailsUniqueIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string HouseAddress { get; set; }

        public string NextOfKinFirstName { get; set; }

        public string NextOfKinLastName { get; set; }

        public string NextOfKinPhoneNumber{ get; set; }

        public string NextOfKinAddress{ get; set; }

        public string RelationshipWithNextOfKin { get; set; }

        public string PhoneNumber { get; set; }

        public string RelationShipStatus { get; set; }

        public string Religion { get; set; }

        public string GaurantorFirstName { get; set; }
        
        public string GaurantorLastName { get; set; }

        public string GaurantorPhone { get; set; }

    }
}
