using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPetsWeb.ModelViews;
using MyPetsWeb.WebServices;

namespace MyPetsWeb.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public PersonView Person { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
                return NotFound();
            Person =  new PersonMapper().ToView(await new PersonWebService().GetPersonByIdAsync((int)id));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            await new PersonWebService().UpdatePersonAsync(Person.PersonId, new PersonMapper().ToDto(Person));
            return RedirectToPage("Index");
        }
    }
}
