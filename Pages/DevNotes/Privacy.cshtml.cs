using Microsoft.AspNetCore.Mvc.RazorPages;
using JohnGuidry.Models;
using System.Globalization;
using System.Collections.Frozen;

namespace JohnGuidry.Pages_DevNotes
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public IList<DevNotes> DevNotes { get; set; } = default!;

        public void OnGet()
        {
            string? dateTime = DevNotes.LastOrDefault()?.ToString();
           // string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;
        }
    }

}
