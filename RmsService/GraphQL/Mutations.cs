using System.Threading.Tasks;
using RmsService.DTO;
using RmsService.Interfaces;

namespace RmsService.GraphQL
{
    public class Mutations
    {
        private readonly IDtpRepository _dtpRepository;
        private readonly IDupRepository _dupRepository;
        
        public Mutations(IDtpRepository dtpRepository, 
            IDupRepository dupRepository
        )
        {
            // RMS related
            _dtpRepository = dtpRepository;
            _dupRepository = dupRepository;
        }
        
        // DTPs
        public async Task<DtpDto> CreateDtp(DtpDto dtp) => await _dtpRepository.CreateDtp(dtp);
        
        public async Task<DtpDto> UpdateDtp(DtpDto dtp) => await _dtpRepository.UpdateDtp(dtp);
        
        public void DeleteDtp(int id) => _dtpRepository.DeleteDtp(id);

        public async Task<DtaDto> CreateDta(int dtpId, DtaDto dtaDto) => await _dtpRepository.CreateDta(dtpId, dtaDto);

        public async Task<DtaDto> UpdateDta(DtaDto dtaDto) => await _dtpRepository.UpdateDta(dtaDto);

        public void DeleteDta(int id) => _dtpRepository.DeleteDta(id);

        public void DeleteAllDta(int dtpId) => _dtpRepository.DeleteAllDta(dtpId);

        public async Task<DtpDatasetDto> CreateDtpDataset(string objectId, DtpDatasetDto dtpDatasetDto) =>
            await _dtpRepository.CreateDtpDataset(objectId, dtpDatasetDto);

        public async Task<DtpDatasetDto> UpdateDtpDataset(DtpDatasetDto dtpDatasetDto) =>
            await _dtpRepository.UpdateDtpDataset(dtpDatasetDto);

        public void DeleteDtpDataset(int id) => _dtpRepository.DeleteDtpDataset(id);

        public async Task<DtpObjectDto> CreateDtpObject(int dtpId, string objectId, DtpObjectDto dtpObjectDto) =>
            await _dtpRepository.CreateDtpObject(dtpId, objectId, dtpObjectDto);

        public async Task<DtpObjectDto> UpdateDtpObject(DtpObjectDto dtpObjectDto) =>
            await _dtpRepository.UpdateDtpObject(dtpObjectDto);

        public void DeleteDtpObject(int id) => _dtpRepository.DeleteDtpObject(id);

        public void DeleteAllDtpObjects(int dtpId) => _dtpRepository.DeleteAllDtpObjects(dtpId);

        public async Task<DtpStudyDto> CreateDtpStudy(int dtpId, string studyId, DtpStudyDto dtpStudyDto) =>
            await _dtpRepository.CreateDtpStudy(dtpId, studyId, dtpStudyDto);

        public async Task<DtpStudyDto> UpdateDtpStudy(DtpStudyDto dtpStudyDto) =>
            await _dtpRepository.UpdateDtpStudy(dtpStudyDto);

        public void DeleteDtpStudy(int id) => _dtpRepository.DeleteDtpStudy(id);

        public void DeleteAllDtpStudies(int dtpId) => _dtpRepository.DeleteAllDtpStudies(dtpId);



        // DUPs
        public async Task<DupDto> CreateDup(DupDto dup) => await _dupRepository.CreateDup(dup);
        
        public async Task<DupDto> UpdateDup(DupDto dup) => await _dupRepository.UpdateDup(dup);
        
        public void DeleteDup(int id) => _dupRepository.DeleteDup(id);

        public async Task<DupObjectDto> CreateDupObject(int dupId, DupObjectDto dupObjectDto) =>
            await _dupRepository.CreateDupObject(dupId, dupObjectDto);

        public async Task<DupObjectDto> UpdateDupObject(DupObjectDto dupObjectDto) =>
            await _dupRepository.UpdateDupObject(dupObjectDto);

        public void DeleteDupObject(int id) => _dupRepository.DeleteDupObject(id);

        public void DeleteAllDupObjects(int dupId) => _dupRepository.DeleteAllDupObjects(dupId);

        public async Task<DupPrereqDto> CreateDupPrereq(int dupId, DupPrereqDto dupPrereqDto) =>
            await _dupRepository.CreateDupPrereq(dupId, dupPrereqDto);

        public async Task<DupPrereqDto> UpdateDupPrereq(DupPrereqDto dupPrereqDto) =>
            await _dupRepository.UpdateDupPrereq(dupPrereqDto);

        public void DeleteDupPrereq(int id) => _dupRepository.DeleteDupPrereq(id);

        public void DeleteAllDupPrereqs(int dupId) => _dupRepository.DeleteAllDupPrereqs(dupId);

        public async Task<SecondaryUseDto> CreateSecondaryUse(int dupId, SecondaryUseDto secondaryUseDto) =>
            await _dupRepository.CreateSecondaryUse(dupId, secondaryUseDto);

        public async Task<SecondaryUseDto> UpdateSecondaryUse(SecondaryUseDto secondaryUseDto) =>
            await _dupRepository.UpdateSecondaryUse(secondaryUseDto);

        public void DeleteSecondaryUse(int id) => _dupRepository.DeleteSecondaryUse(id);

        public void DeleteAllSecondaryUses(int dupId) => _dupRepository.DeleteAllSecondaryUses(dupId);

        public async Task<DuaDto> CreateDua(int dupId, DuaDto duaDto) => await _dupRepository.CreateDua(dupId, duaDto);

        public async Task<DuaDto> UpdateDua(DuaDto duaDto) => await _dupRepository.UpdateDua(duaDto);

        public void DeleteDua(int id) => _dupRepository.DeleteDua(id);

        public void DeleteAllDua(int dupId) => _dupRepository.DeleteAllDua(dupId);
    }
}