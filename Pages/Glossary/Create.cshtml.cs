using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlossaryApp.Data;
using GlossaryApp.Models;

namespace GlossaryApp
{
    public class CreateModel : PageModel
    {
        private readonly GlossaryApp.Data.GlossaryAppContext _context;

        public CreateModel(GlossaryApp.Data.GlossaryAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Glossary Glossary { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Glossary.Add(Glossary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
