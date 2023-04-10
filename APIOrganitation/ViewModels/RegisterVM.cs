using APIOrganitation.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIOrganitation.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Member Nim")]
        public string Nim { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Major")]
        public string Major { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Title")]
        public string TitleName { get; set; }
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Addres")]
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
