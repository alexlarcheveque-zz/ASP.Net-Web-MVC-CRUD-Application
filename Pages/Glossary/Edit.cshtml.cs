using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlossaryApp.Data;
using GlossaryApp.Models;

namespace GlossaryApp
{
    public class EditModel : PageModel
    {
        private readonly GlossaryApp.Data.GlossaryAppContext _context;

        public EditModel(GlossaryApp.Data.GlossaryAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Glossary Glossary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Glossary = await _context.Glossary.FirstOrDefaultAsync(m => m.ID == id);

            if (Glossary == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Glossary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlossaryExists(Glossary.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GlossaryExists(int id)
        {
            return _context.Glossary.Any(e => e.ID == id);
        }
    }
}
