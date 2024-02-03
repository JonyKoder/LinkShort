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
        private readonly ILinkRepository _linkRepository;

        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task Create(LinkDto link)
        {
            var linkEntity = new Link(link.Code, link.Url);
            await _linkRepository.Create(linkEntity);
        }

        public async Task Delete(Guid id)
        {
            await _linkRepository.Delete(id);
        }

        public async Task<IEnumerable<LinkDto>> GetAll()
        {
            var links = await _linkRepository.GetAll();
            return links.Select(link => new LinkDto
            {
                Id = link.Id,
                Code = link.Code,
                Url = link.Url
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
                Url = link.Url
            };
        }

        public async Task Update(LinkDto link)
        {
            var linkEntity = await _linkRepository.GetById(link.Id);
            if (linkEntity == null)
                return;

            linkEntity.AddUrlAndCode(link.Code, link.Url);

            await _linkRepository.Update(linkEntity);
        }
    }

}
