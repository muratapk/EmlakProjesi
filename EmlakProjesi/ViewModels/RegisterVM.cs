using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmlakProjesi.ViewModels
{
    public class RegisterVM
    {
        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
