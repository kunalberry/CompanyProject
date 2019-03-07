using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HtmlHelper1.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Enter Your Name"),
        MaxLength(12, ErrorMessage = "Not More Than 12 Character"),
        MinLength(5, ErrorMessage = "Should be greator than 5 character")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Enter Your DateOfBirth")]
        public string Dateofbirth { get; set; }


        [Required(ErrorMessage = "Enter Your Phone"),
         RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Phone is Invalid")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Enter Your Email"),
         RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Email is not valid")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Your Department")]
        public string Department { get; set; }


        [Required(ErrorMessage = "Enter Your Address"),
         MinLength(6, ErrorMessage = "Address Should Be More than 6"),
         MaxLength(30, ErrorMessage = "Address Should not be more than 30 character")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Enter Your States")]
        public string States { get; set; }


        [Required(ErrorMessage = "Enter Your City")]
        public string City { get; set; }


        [Required(ErrorMessage = "Enter Your ZipCode"),
         RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Zipcode")]
        public string Zip { get; set; }


        [Required(ErrorMessage = "Enter Your DateOfJoining")]
        public string Dateofjoin { get; set; }

        public int EmpId { get; set; }


    }
}
