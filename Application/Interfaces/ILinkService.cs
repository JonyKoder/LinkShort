using DTO.LinkInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILinkService
    {
        Task CreateAsync(LinkDto link);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<LinkDto>> GetAllAsync();
        Task UpdateAsync(LinkDto link);
        Task<LinkDto> GetByIdAsync(Guid id);
        Task<LinkDto> GetByCodeAsync(string code);
        string GenerateUniqueCode();
    }
}
