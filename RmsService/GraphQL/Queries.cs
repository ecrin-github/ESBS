using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate.Data;
using HotChocolate.Types;
using RmsService.DTO;
using RmsService.Interfaces;

namespace RmsService.GraphQL
{
    public class Queries
    {
        private readonly IDtpRepository _dtpRepository;
        private readonly IDupRepository _dupRepository;
        
        public Queries(IDtpRepository dtpRepository, 
            IDupRepository dupRepository
            )
        {
            // RMS related
            _dtpRepository = dtpRepository;
            _dupRepository = dupRepository;
        }
        
        // DTP
        [UsePaging(ConnectionName = "DtpList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DtpDto>> GetDtpList() => await _dtpRepository.GetAllDtp();

        [UseFiltering]
        [UseSorting]
        public async Task<DtpDto> GetDtpById(int id) => await _dtpRepository.GetDtp(id);

        [UsePaging(ConnectionName = "DtaList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DtaDto>> GetDtaList(int dtpId) => await _dtpRepository.GetAllDta(dtpId);

        [UseFiltering]
        [UseSorting]
        public async Task<DtaDto> GetDtaById(int dtaId) => await _dtpRepository.GetDta(dtaId);

        [UsePaging(ConnectionName = "DtpDatasetList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DtpDatasetDto>> GetDtpDatasetList() => await _dtpRepository.GetAllDtpDatasets();

        [UseFiltering]
        [UseSorting]
        public async Task<DtpDatasetDto> GetDtpDatasetById(int id) => await _dtpRepository.GetDtpDataset(id);

        [UsePaging(ConnectionName = "DtpObjectList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DtpObjectDto>> GetDtpObjectList(int dtpId) =>
            await _dtpRepository.GetAllDtpObjects(dtpId);

        [UseFiltering]
        [UseSorting]
        public async Task<DtpObjectDto> GetDtpObjectById(int id) => await _dtpRepository.GetDtpObject(id);

        [UsePaging(ConnectionName = "DtpStudyList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DtpStudyDto>> GetDtpStudyList(int dtpId) =>
            await _dtpRepository.GetAllDtpStudies(dtpId);

        [UseFiltering]
        [UseSorting]
        public async Task<DtpStudyDto> GetDtpStudyById(int id) => await _dtpRepository.GetDtpStudy(id);



        // DUP
        [UsePaging(ConnectionName = "DupList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DupDto>> GetDupList() => await _dupRepository.GetAllDup();

        [UsePaging(ConnectionName = "DupObjectList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DupObjectDto>> GetDupObjectList(int dupId) => await _dupRepository.GetDupObjects(dupId);

        [UseFiltering]
        [UseSorting]
        public async Task<DupObjectDto> GetDupObjectById(int id) => await _dupRepository.GetDupObject(id);

        [UsePaging(ConnectionName = "DupPrereqList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DupPrereqDto>> GetDupPrereqList(int dupId) =>
            await _dupRepository.GetDupPrereqs(dupId);

        [UseFiltering]
        [UseSorting]
        public async Task<DupPrereqDto> GetDupPrereqById(int id) => await _dupRepository.GetDupPrereq(id);

        [UsePaging(ConnectionName = "SecondaryUseList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<SecondaryUseDto>> GetSecondaryUseList(int dupId) =>
            await _dupRepository.GetSecondaryUses(dupId);

        [UseFiltering]
        [UseSorting]
        public async Task<SecondaryUseDto> GetSecondaryUseById(int id) => await _dupRepository.GetSecondaryUse(id);

        [UsePaging(ConnectionName = "DuaList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DuaDto>> GetDuaList(int dupId) => await _dupRepository.GetAllDua(dupId);

        [UseFiltering]
        [UseSorting]
        public async Task<DuaDto> GetDuaById(int id) => await _dupRepository.GetDua(id);
        
    }
}