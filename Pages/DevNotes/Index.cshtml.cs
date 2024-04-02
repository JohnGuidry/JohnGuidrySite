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
    public class IndexModel : PageModel
    {
        private readonly JohnGuidry.Data.JohnGuidryContext _context;

        public IndexModel(JohnGuidry.Data.JohnGuidryContext context)
        {
            _context = context;
        }

        public IList<DevNotes> DevNotes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DevNotes = await _context.DevNotes.ToListAsync();
        }
    }
}
