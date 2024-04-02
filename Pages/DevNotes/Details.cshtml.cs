using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JohnGuidry.Data;
using JohnGuidry.Models;

namespace JohnGuidry.Pages_DevNotes
{
    public class DetailsModel : PageModel
    {
        private readonly JohnGuidry.Data.JohnGuidryContext _context;

        public DetailsModel(JohnGuidry.Data.JohnGuidryContext context)
        {
            _context = context;
        }

        public DevNotes DevNotes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devnotes = await _context.DevNotes.FirstOrDefaultAsync(m => m.Id == id);
            if (devnotes == null)
            {
                return NotFound();
            }
            else
            {
                DevNotes = devnotes;
            }
            return Page();
        }
    }
}
