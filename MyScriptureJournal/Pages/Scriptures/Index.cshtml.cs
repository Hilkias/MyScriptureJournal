using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchNote { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchBook { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from s in _context.Scripture
                                            orderby s.Book
                                            select s.Book;

            var books = from s in _context.Scripture
                         select s;
            if (!string.IsNullOrEmpty(SearchNote))
            {
                books = books.Where(n => n.Note.Contains(SearchNote));
            }
            if (!string.IsNullOrEmpty(SearchBook))
            {
                books = books.Where(b => b.Book == SearchBook);
            }
            Books = new SelectList(await genreQuery.Distinct().ToListAsync());
            Scripture = await books
                                .OrderBy(b => b.Book)
                                .OrderBy(d => d.Date)
                                .ToListAsync();
        }
    }
}
