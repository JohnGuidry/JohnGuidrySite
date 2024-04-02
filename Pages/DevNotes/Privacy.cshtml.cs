using Microsoft.AspNetCore.Mvc.RazorPages;
using JohnGuidry.Data;
using JohnGuidry.Models;
using System.Globalization;
using System.Collections.Frozen;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;


namespace JohnGuidry.Pages_DevNotes
{
    public class PrivacyModel : PageModel
    {
        private readonly JohnGuidry.Data.JohnGuidryContext _context;

        public PrivacyModel(JohnGuidry.Data.JohnGuidryContext context)
        {
            _context = context;
        }

        public DevNotes DevNotes { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            var devnotes = await _context.DevNotes.FirstOrDefaultAsync(m => m.Id == 1);
            if (devnotes == null)
            {
                return NotFound();
            }
            ViewData["TimeStamp"] = devnotes.CreateDate.ToString();
            return Page();
        }
    }

}
