using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlossaryApp.Data;
using GlossaryApp.Models;

namespace GlossaryApp
{
    public class DeleteModel : PageModel
    {
        private readonly GlossaryApp.Data.GlossaryAppContext _context;

        public DeleteModel(GlossaryApp.Data.GlossaryAppContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Glossary = await _context.Glossary.FindAsync(id);

            if (Glossary != null)
            {
                _context.Glossary.Remove(Glossary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
