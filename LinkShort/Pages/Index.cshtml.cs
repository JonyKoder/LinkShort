using Application.Services;
using DTO.LinkInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace LinkShort.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILinkService _linkService;

        public IndexModel(ILogger<IndexModel> logger, ILinkService linkService)
        {
            _logger = logger;
            _linkService = linkService;
        }

        public List<LinkDto> Links { get; private set; }

        public async Task OnGet()
        {

            var allShortLinks = await _linkService.GetAll();
            Links = allShortLinks.ToList();
        }

        public async Task<IActionResult> OnPostAsync(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
          
                var linkDto = new LinkDto { Url = url, Code = GetShortCode(url) };

            
                await _linkService.Create(linkDto);
            }

            return RedirectToPage("/Index");
        }

        private string GetShortCode(string url)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(url));
                string hash = BitConverter.ToString(bytes).Replace("-", "").Substring(0, 8);
                return hash;
            }
        }

    }
}
