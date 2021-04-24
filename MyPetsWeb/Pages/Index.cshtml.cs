using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPetsCore.DTOs;
using MyPetsWeb.WebServices;

namespace MyPetsWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<PersonDto> Persons { get; set; }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            if (id == 0)
                return NotFound();
            await new PersonWebService().DeleteAsync(id);
            Persons = await new PersonWebService().GetAllAsync();
            return Page();
        }
        public async Task OnGetAsync()
        {
            Persons = await new PersonWebService().GetAllAsync();
        }
    }
}
