using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LinkInfo
{
    public class LinkDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Введите ссылку")]
        [RegularExpression(@"https?:\/\/[a-zA-Z0-9.\/]+.[a-z]*[a-zA-Z0-9.\/_?=%\-\&]*", ErrorMessage = "Введите корректный Url")]
        public  string Url { get; set; }
    }
}
