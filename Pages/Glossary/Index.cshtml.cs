using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlossaryApp.Models;
using System.Linq;

namespace GlossaryApp
{
    public class IndexModel : PageModel
    {
        private readonly GlossaryApp.Data.GlossaryAppContext _context;

        public IndexModel(GlossaryApp.Data.GlossaryAppContext context)
        {
            _context = context;
        }

        //Declare getters and setterss
        public string SearchString { get; set; }
        public string TermSort { get; set; }
        public string DefinitionSort { get; set; }
        public IList<Glossary> Glossary { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {

            TermSort = string.IsNullOrEmpty(sortOrder) ? "term_desc" : "";
            DefinitionSort = sortOrder == "Definition" ? "def_desc" : "Definition";
            SearchString = searchString;

            IQueryable<Glossary> termIQ = from t in _context.Glossary
                                          select t;

            if(!string.IsNullOrEmpty(searchString))
            {
                termIQ = termIQ.Where(t => t.Term.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "term_desc":
                    termIQ = termIQ.OrderByDescending(t => t.Term);
                    break;
                case "Definition":
                    termIQ = termIQ.OrderBy(t => t.Definition);
                    break;
                case "def_desc":
                    termIQ = termIQ.OrderByDescending(t => t.Definition);
                    break;
                default:
                    termIQ = termIQ.OrderBy(t => t.Term);
                    break;
            }

            Glossary = await termIQ.AsNoTracking().ToListAsync();
        }
    }
}


        /*
            var terms = from t in _context.Glossary
                        select t;

            if (!string.IsNullOrEmpty(SearchString))
            {
               terms = terms.Where(t => t.Term.Contains(SearchString));
            }
               Glossary = await terms.ToListAsync();
            }   
        }
         */