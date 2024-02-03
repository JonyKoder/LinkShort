using Application.Interfaces;
using DTO.LinkInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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

        public List<LinkDto> Links { get;  set; }
        [BindProperty] public LinkVM LinkVM { get;  set; }

        public async Task OnGet()
        {
            LinkVM = new LinkVM();
            var allShortLinks = await _linkService.GetAll();
            Links = allShortLinks.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(LinkVM.Url))
            {
                var code = _linkService.GenerateUniqueCode();
                var linkDto = new LinkDto { LongUrl = LinkVM.Url, Code = code, ShortUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/{code}" };

            
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
    public class LinkVM
    {
        [Required(ErrorMessage = "¬ведите ссылку")]
        [RegularExpression(@"https?:\/\/[a-zA-Z0-9.\/]+.[a-z]*[a-zA-Z0-9.\/_?=%\-\&]*", ErrorMessage = "¬ведите корректный Url")]
        public string Url { get; set; }
    }
}
