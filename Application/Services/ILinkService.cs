using Application.Interfaces;
using DTO.LinkInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ILinkService
    {
        Task Create(LinkDto link);
        Task Delete(Guid id);
        Task<IEnumerable<LinkDto>> GetAll();
        Task Update(LinkDto link);
        Task<LinkDto> GetById(Guid id);
    }
}
