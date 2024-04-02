using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JohnGuidry.Data;
using JohnGuidry.Models;

namespace JohnGuidry.Pages_DevNotes
{
    public class EditModel : PageModel
    {
        private readonly JohnGuidry.Data.JohnGuidryContext _context;

        public EditModel(JohnGuidry.Data.JohnGuidryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DevNotes DevNotes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devnotes =  await _context.DevNotes.FirstOrDefaultAsync(m => m.Id == id);
            if (devnotes == null)
            {
                return NotFound();
            }
            DevNotes = devnotes;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DevNotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevNotesExists(DevNotes.Id))
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

        private bool DevNotesExists(int id)
        {
            return _context.DevNotes.Any(e => e.Id == id);
        }
    }
}
