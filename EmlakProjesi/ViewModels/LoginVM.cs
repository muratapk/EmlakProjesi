using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EmlakProjesi.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Email {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword  { get; set; }
        [Required]
        public string Name { get; set; }

        public bool RememberMe { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? RedirectUrl { get; set; }

        public string? Role { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
