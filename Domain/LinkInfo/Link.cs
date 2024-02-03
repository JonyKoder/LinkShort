using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.LinkInfo
{
    public class Link
    {

        public Guid Id { get; set; }
        public string Code { get; protected set; }
        public string LongUrl { get; protected set; }
        public string ShortUrl { get; protected set; }

        public void AddCode(string code)
        {
            Code = code;
        }

        public void SetLongUrl(string longUrl)
        {
            LongUrl = longUrl;
        }

        public void SetShortUrl(string shortUrl)
        {
            ShortUrl = shortUrl;
        }
    }
}
