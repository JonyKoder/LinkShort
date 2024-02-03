using Application.Interfaces;
using Domain.LinkInfo;
using DTO.LinkInfo;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LinkInfo
{
    //В крупном проекте я бы использовал AutoMapper тут мало полей, я решил вручную привести типы
    public class LinkRepository : ILinkRepository
    {
        private readonly AppDbContext _dbContext;

        public LinkRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Link> GetById(Guid id)
        {
            var linkEntity = await _dbContext.Links.FindAsync(id);
            if (linkEntity == null)
                return null;

            return linkEntity;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            var linkEntities = await _dbContext.Links.ToListAsync();

            return linkEntities;
        }

        public async Task Create(Link link)
        {
            var linkEntity = new Link();
            linkEntity.AddCode(link.Code);
            linkEntity.SetLongUrl(link.LongUrl);
            linkEntity.SetShortUrl(link.ShortUrl);
            await _dbContext.Links.AddAsync(linkEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Link link)
        {
            var linkEntity = await _dbContext.Links.FindAsync(link.Id);
            if (linkEntity == null)
                return;

            linkEntity.AddCode(link.Code);
            linkEntity.SetLongUrl(link.LongUrl);
            linkEntity.SetShortUrl(link.ShortUrl);

            _dbContext.Links.Update(linkEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var linkEntity = await _dbContext.Links.FindAsync(id);
            if (linkEntity == null)
                return;

            _dbContext.Links.Remove(linkEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
