using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPetsCore.DTOs;
using MyPetsWeb.ModelViews;
using MyPetsWeb.WebServices;

namespace MyPetsWeb.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public PersonView Person { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            await new PersonWebService().CreateAsync(new PersonMapper().ToDto(Person));
            return RedirectToPage("Index");
        }

    }
}
