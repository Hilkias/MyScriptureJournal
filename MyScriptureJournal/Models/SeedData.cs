using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Moroni",
                        Chapter = "1",
                        Verse = "2",
                        Note = "Love",
                        Date = new DateTime(2019, 5, 11)
                    },

                     new Scripture
                     {
                         Book = "1 Nephi",
                         Chapter = "5",
                         Verse = "11",
                         Note = "Christ",
                         Date = new DateTime(2018, 3, 14)
                     },

                    new Scripture
                    {
                        Book = "2 Nephi",
                        Chapter = "3",
                        Verse = "21",
                        Note = "Faith",
                        Date = new DateTime(2018, 5, 24)
                    },

                    new Scripture
                    {
                        Book = "Mosiah",
                        Chapter = "4",
                        Verse = "19",
                        Note = "We are all begger",
                        Date = new DateTime(2019, 12, 31)
                    }
                ); ;
                context.SaveChanges();
            }
        }
    }
}