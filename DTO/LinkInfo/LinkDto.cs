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
        public string Code { get;  set; }
        public string LongUrl { get;  set; }
        public string ShortUrl { get;  set; }
    }
}
