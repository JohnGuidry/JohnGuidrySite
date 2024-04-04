using Microsoft.AspNetCore.Mvc.RazorPages;
using JohnGuidry.Data;
using System.Globalization;
using System.Collections.Frozen;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using JohnGuidry.Models;


namespace JohnGuidry.Pages_DevNotes
{
    public class DevNotesModel : PageModel
    {
        private readonly JohnGuidry.Data.JohnGuidryContext _context;

        public DevNotesModel(JohnGuidry.Data.JohnGuidryContext context)
        {
            _context = context;
        }

        public DevNotes DevNotes { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var StartDate = await _context.DevNotes.FirstOrDefaultAsync(m => m.Id == 1);
                var LastUpdate = await _context.DevNotes.OrderBy(c => c.CreateDate).LastOrDefaultAsync(m => m.CreateDate <= System.DateTime.Now);

                // Check if we recieved data from DB.
                // TODO: Add logging
                if (StartDate == null || LastUpdate == null)
                {
                    return NotFound();
                }

                ViewData["StartDate"] = StartDate.CreateDate.ToString();
                ViewData["LastUpdate"] = LastUpdate.CreateDate.ToString();


                return Page();
            } catch (Exception)
            {
                //Exception if the DB is down. I dont really like how this is handled but I'm doing this to not pay AWS costs for a DB. In other words, no DB, load the page anyways.
                return Page();
            }
        }
    }
}
