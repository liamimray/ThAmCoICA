using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Pages.EventsList
{
    public class DeleteModel : PageModel
    {
        private readonly ThAmCo.Events.Models.EventsDbContext _context;

        public DeleteModel(ThAmCo.Events.Models.EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evnt = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (evnt == null)
            {
                return NotFound();
            }
            else
            {
                Event = evnt;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evnt = await _context.Events.FindAsync(id);
            if (evnt != null)
            {
                Event = evnt;
                _context.Events.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
