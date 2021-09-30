using System;

namespace Models
{
    public class Person : Entity
    {
	public string FirstName {get; set;}
	public string LastName {get; set;}
        public string PhoneNumber { get; set; }

        public int AddressId { get; set; }
    }
}
