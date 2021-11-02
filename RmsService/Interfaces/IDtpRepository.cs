using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RmsService.DTO;
using RmsService.Models;

namespace RmsService.Interfaces
{
    public interface IDtpRepository
    {
        IQueryable<Dtp> GetQueryableDtp();
        Task<ICollection<DtpDto>> GetAllDtp();
        Task<DtpDto> GetDtp(int id);
        Task<ICollection<DtpDto>> GetRecentDtp(int limit);
        Task<DtpDto> CreateDtp(DtpDto dtpDto);
        Task<DtpDto> UpdateDtp(DtpDto dtpDto);
        Task<int> DeleteDtp(int id);

        IQueryable<Dta> GetQueryableDta();
        Task<ICollection<DtaDto>> GetAllDta(int dtpId);
        Task<DtaDto> GetDta(int id);
        Task<DtaDto> CreateDta(int dtpId, DtaDto dtaDto);
        Task<DtaDto> UpdateDta(DtaDto dtaDto);
        Task<int> DeleteDta(int id);
        Task<int> DeleteAllDta(int dtpId);
        
        IQueryable<DtpDataset> GetQueryableDtpDatasets();
        Task<ICollection<DtpDatasetDto>> GetAllDtpDatasets();
        Task<DtpDatasetDto> GetDtpDataset(int id);
        Task<DtpDatasetDto> CreateDtpDataset(string objectId, DtpDatasetDto dtpDatasetDto);
        Task<DtpDatasetDto> UpdateDtpDataset(DtpDatasetDto dtpDatasetDto);
        Task<int> DeleteDtpDataset(int id);
        
        IQueryable<DtpObject> GetQueryableDtpObjects();
        Task<ICollection<DtpObjectDto>> GetAllDtpObjects(int dtpId);
        Task<DtpObjectDto> GetDtpObject(int id);
        Task<DtpObjectDto> CreateDtpObject(int dtpId, string objectId, DtpObjectDto dtpObjectDto);
        Task<DtpObjectDto> UpdateDtpObject(DtpObjectDto dtpObjectDto);
        Task<int> DeleteDtpObject(int id);
        Task<int> DeleteAllDtpObjects(int dtpId);
        
        IQueryable<DtpStudy> GetQueryableDtpStudies();
        Task<ICollection<DtpStudyDto>> GetAllDtpStudies(int dtpId);
        Task<DtpStudyDto> GetDtpStudy(int id);
        Task<DtpStudyDto> CreateDtpStudy(int dtpId, string studyId, DtpStudyDto dtpStudyDto);
        Task<DtpStudyDto> UpdateDtpStudy(DtpStudyDto dtpStudyDto);
        Task<int> DeleteDtpStudy(int id);
        Task<int> DeleteAllDtpStudies(int dtpId);
    }
}