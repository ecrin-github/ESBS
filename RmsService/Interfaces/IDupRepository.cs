using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RmsService.Contracts.Requests.Filtering;
using RmsService.Contracts.Responses;
using RmsService.DTO;
using RmsService.Models;

namespace RmsService.Interfaces
{
    public interface IDupRepository
    {
        IQueryable<Dup> GetQueryableDup();
        Task<ICollection<DupDto>> GetAllDup();
        Task<DupDto> GetDup(int id);
        Task<ICollection<DupDto>> GetRecentDup(int limit);
        Task<DupDto> CreateDup(DupDto dupDto);
        Task<DupDto> UpdateDup(DupDto dupDto);
        Task<int> DeleteDup(int id);

        IQueryable<DupObject> GetQueryableDupObjects();
        Task<ICollection<DupObjectDto>> GetDupObjects(int dupId);
        Task<DupObjectDto> GetDupObject(int id);
        Task<DupObjectDto> CreateDupObject(int dupId, DupObjectDto dupObjectDto);
        Task<DupObjectDto> UpdateDupObject(DupObjectDto dupObjectDto);
        Task<int> DeleteDupObject(int id);
        Task<int> DeleteAllDupObjects(int dupId);
        
        IQueryable<DupPrereq> GetQueryableDupPrereqs();
        Task<ICollection<DupPrereqDto>> GetDupPrereqs(int dupId);
        Task<DupPrereqDto> GetDupPrereq(int id);
        Task<DupPrereqDto> CreateDupPrereq(int dupId, DupPrereqDto dupPrereqDto);
        Task<DupPrereqDto> UpdateDupPrereq(DupPrereqDto dupPrereqDto);
        Task<int> DeleteDupPrereq(int id);
        Task<int> DeleteAllDupPrereqs(int dupId);
        
        IQueryable<SecondaryUse> GetQueryableSecondaryUses();
        Task<ICollection<SecondaryUseDto>> GetSecondaryUses(int dupId);
        Task<SecondaryUseDto> GetSecondaryUse(int id);
        Task<SecondaryUseDto> CreateSecondaryUse(int dupId, SecondaryUseDto secondaryUseDto);
        Task<SecondaryUseDto> UpdateSecondaryUse(SecondaryUseDto secondaryUseDto);
        Task<int> DeleteSecondaryUse(int id);
        Task<int> DeleteAllSecondaryUses(int dupId);
        
        IQueryable<Dua> GetQueryableDua();
        Task<ICollection<DuaDto>> GetAllDua(int dupId);
        Task<DuaDto> GetDua(int id);
        Task<DuaDto> CreateDua(int dupId, DuaDto duaDto);
        Task<DuaDto> UpdateDua(DuaDto duaDto);
        Task<int> DeleteDua(int id);
        Task<int> DeleteAllDua(int dupId);


        // Statistics
        Task<PaginationResponse<DupDto>> PaginateDup(PaginationRequest paginationRequest);
        Task<PaginationResponse<DupDto>> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest);
        Task<int> GetTotalDup();
        Task<int> GetUncompletedDup();
    }
}