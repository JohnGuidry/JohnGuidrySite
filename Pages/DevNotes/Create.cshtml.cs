using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JohnGuidry.Data;
using JohnGuidry.Models;

namespace JohnGuidry.Pages_DevNotes
{
    public class CreateModel : PageModel
    {
        private readonly JohnGuidry.Data.JohnGuidryContext _context;

        public CreateModel(JohnGuidry.Data.JohnGuidryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DevNotes DevNotes { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DevNotes.Add(DevNotes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
