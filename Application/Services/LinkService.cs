using Application.Interfaces;
using Domain.LinkInfo;
using DTO.LinkInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LinkService : ILinkService
    {
        private const int NumberOfChars = 7;
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\r\nabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly Random _random = new Random();
        private readonly ILinkRepository _linkRepository;

        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task Create(LinkDto link)
        {
            var linkEntity = new Link();
            linkEntity.AddCode(link.Code);
            linkEntity.SetLongUrl(link.LongUrl);
            linkEntity.SetShortUrl(link.ShortUrl);
            await _linkRepository.Create(linkEntity);
        }

        public async Task Delete(Guid id)
        {
            await _linkRepository.Delete(id);
        }

        public string GenerateUniqueCode()
        {
            var codeChars = new char[NumberOfChars];
            for (int i = 0; i < NumberOfChars; i++)
            {
                var randomIndex = _random.Next(Alphabet.Length - 1);
                codeChars[i] = Alphabet[randomIndex];
            }
            var code = new string(codeChars).Trim();
            return code;
        }

        public async Task<IEnumerable<LinkDto>> GetAll()
        {
            var links = await _linkRepository.GetAll();
            return links.Select(link => new LinkDto
            {
                Id = link.Id,
                Code = link.Code,
                ShortUrl = link.ShortUrl,
                LongUrl = link.LongUrl
            });
        }

        public async Task<LinkDto> GetById(Guid id)
        {
            var link = await _linkRepository.GetById(id);
            if (link == null)
                return null;

            return new LinkDto
            {
                Id = link.Id,
                Code = link.Code,
                ShortUrl = link.ShortUrl,
                LongUrl = link.LongUrl
            };
        }

        public async Task Update(LinkDto link)
        {
            var linkEntity = await _linkRepository.GetById(link.Id);
            if (linkEntity == null)
                return;

            linkEntity.AddCode(link.Code);
            linkEntity.SetLongUrl(link.LongUrl);
            linkEntity.SetShortUrl(link.ShortUrl);

            await _linkRepository.Update(linkEntity);
        }
    }

}
