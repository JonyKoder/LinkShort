using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.LinkInfo
{
    public class Link
    {
        public Link(string code, string url)
        {
            Code = code;
            Url = url;
        }

        public Guid Id { get; set; }
        public virtual string Code { get; protected set; }
        public virtual string Url { get; protected set; }

        public void AddUrlAndCode(string code, string url)
        {
            Code = code;
            Url = url;
        }
    }
}
