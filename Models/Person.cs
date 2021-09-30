using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Person : Entity
    {

        //[StringLength(15)]
        public string FirstName {get; set;}

        //[Required(ErrorMessage = "Last name is required!")]
        //[StringLength(20)]
	    public string LastName {get; set;}

        //[Phone]
        public string PhoneNumber { get; set; }

        //[Range(0, 1000, ErrorMessage = "Length must be between {2} and {1}")]
        public int AddressId { get; set; }
    }
}
