using Domain.LinkInfo;
using DTO.LinkInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILinkRepository
    {
        Task<Link> GetById(Guid id);
        Task<IEnumerable<Link>> GetAll();
        Task Create(Link link);
        Task Update(Link link);
        Task Delete(Guid id);
    }
}
