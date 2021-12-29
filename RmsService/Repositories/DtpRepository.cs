using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RmsService.Contracts.Requests.Filtering;
using RmsService.Contracts.Responses;
using RmsService.DTO;
using RmsService.Interfaces;
using RmsService.Models;
using RmsService.Models.DbConnection;

namespace RmsService.Repositories
{
    public class DtpRepository : IDtpRepository
    {
        private readonly RmsDbConnection _dbConnection;
        private readonly IDataMapper _dataMapper;

        public DtpRepository(RmsDbConnection dbContext, IDataMapper dataMapper)
        {
            _dbConnection = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
        }

        public IQueryable<Dta> GetQueryableDta()
        {
            return _dbConnection.Dtas;
        }

        public async Task<ICollection<DtaDto>> GetAllDta(int dtpId)
        {
            var data = _dbConnection.Dtas.Where(p => p.DtpId == dtpId);
            return data.Any() ? _dataMapper.DtaDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<DtaDto> GetDta(int id)
        {
            var dta = await _dbConnection.Dtas.FirstOrDefaultAsync(p => p.Id == id);
            return dta != null ? _dataMapper.DtaDtoMapper(dta) : null;
        }

        public async Task<DtaDto> CreateDta(int dtpId, DtaDto dtaDto)
        {
            var dta = new Dta
            {
                DtpId = dtpId,
                CreatedOn = DateTime.Now,
                ConformsToDefault = dtaDto.ConformsToDefault,
                Variations = dtaDto.Variations,
                RepoSignatory1 = dtaDto.RepoSignatory1,
                RepoSignatory2 = dtaDto.RepoSignatory2,
                ProviderSignatory1 = dtaDto.ProviderSignatory1,
                ProviderSignatory2 = dtaDto.ProviderSignatory2,
                Notes = dtaDto.Notes
            };

            await _dbConnection.Dtas.AddAsync(dta);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtaDtoMapper(dta);
        }

        public async Task<DtaDto> UpdateDta(DtaDto dtaDto)
        {
            var dbDta = await _dbConnection.Dtas.FirstOrDefaultAsync(p => p.Id == dtaDto.Id);
            if (dbDta == null) return null;
            
            dbDta.ConformsToDefault = dtaDto.ConformsToDefault;
            dbDta.Variations = dtaDto.Variations;
            dbDta.RepoSignatory1 = dtaDto.RepoSignatory1;
            dbDta.RepoSignatory2 = dtaDto.RepoSignatory2;
            dbDta.ProviderSignatory1 = dtaDto.ProviderSignatory1;
            dbDta.ProviderSignatory2 = dtaDto.ProviderSignatory2;
            dbDta.Notes = dtaDto.Notes;
                
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtaDtoMapper(dbDta);
        }

        public async Task<int> DeleteDta(int id)
        {
            var data = await _dbConnection.Dtas.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.Dtas.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllDta(int dtpId)
        {
            var data = _dbConnection.Dtas.Where(p => p.DtpId == dtpId);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.Dtas.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<DtpDataset> GetQueryableDtpDatasets()
        {
            return _dbConnection.DtpDatasets;
        }

        public async Task<ICollection<DtpDatasetDto>> GetAllDtpDatasets()
        {
            var data = _dbConnection.DtpDatasets;
            return data.Any() ? _dataMapper.DtpDatasetDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<DtpDatasetDto> GetDtpDataset(int id)
        {
            var dtpDataset = await _dbConnection.DtpDatasets.FirstOrDefaultAsync(p => p.Id == id);
            return dtpDataset != null ? _dataMapper.DtpDatasetDtoMapper(dtpDataset) : null;
        }

        public async Task<DtpDatasetDto> CreateDtpDataset(string objectId, DtpDatasetDto dtpDatasetDto)
        {
            var dtpDataset = new DtpDataset
            {
                ObjectId = objectId,
                CreatedOn = DateTime.Now,
                LegalStatusId = dtpDatasetDto.LegalStatusId,
                LegalStatusText = dtpDatasetDto.LegalStatusText,
                LegalStatusPath = dtpDatasetDto.LegalStatusPath,
                DescmdCheckBy = dtpDatasetDto.DescmdCheckBy,
                DescmdCheckDate = dtpDatasetDto.DescmdCheckDate,
                DescmdCheckStatusId = dtpDatasetDto.DescmdCheckStatusId,
                DeidentCheckBy = dtpDatasetDto.DeidentCheckBy,
                DeidentCheckDate = dtpDatasetDto.DeidentCheckDate,
                DeidentCheckStatusId = dtpDatasetDto.DeidentCheckStatusId,
                Notes = dtpDatasetDto.Notes
            };

            await _dbConnection.DtpDatasets.AddAsync(dtpDataset);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtpDatasetDtoMapper(dtpDataset);
        }

        public async Task<DtpDatasetDto> UpdateDtpDataset(DtpDatasetDto dtpDatasetDto)
        {
            var dbDtpDataset = await _dbConnection.DtpDatasets.FirstOrDefaultAsync(p => p.Id == dtpDatasetDto.Id);
            if (dbDtpDataset == null) return null;
            
            dbDtpDataset.LegalStatusId = dtpDatasetDto.LegalStatusId;
            dbDtpDataset.LegalStatusText = dtpDatasetDto.LegalStatusText;
            dbDtpDataset.LegalStatusPath = dtpDatasetDto.LegalStatusPath;
            dbDtpDataset.DescmdCheckBy = dtpDatasetDto.DescmdCheckBy;
            dbDtpDataset.DescmdCheckDate = dtpDatasetDto.DescmdCheckDate;
            dbDtpDataset.DescmdCheckStatusId = dtpDatasetDto.DescmdCheckStatusId;
            dbDtpDataset.DeidentCheckBy = dtpDatasetDto.DeidentCheckBy;
            dbDtpDataset.DeidentCheckDate = dtpDatasetDto.DeidentCheckDate;
            dbDtpDataset.DeidentCheckStatusId = dtpDatasetDto.DeidentCheckStatusId;
            dbDtpDataset.Notes = dtpDatasetDto.Notes;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtpDatasetDtoMapper(dbDtpDataset);
        }

        public async Task<int> DeleteDtpDataset(int id)
        {
            var data = await _dbConnection.DtpDatasets.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.DtpDatasets.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public IQueryable<DtpObject> GetQueryableDtpObjects()
        {
            return _dbConnection.DtpObjects;
        }

        public async Task<ICollection<DtpObjectDto>> GetAllDtpObjects(int dtpId)
        {
            var data = _dbConnection.DtpObjects.Where(p => p.DtpId == dtpId);
            return data.Any() ? _dataMapper.DtpObjectDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<DtpObjectDto> GetDtpObject(int id)
        {
            var dtpObject = await _dbConnection.DtpObjects.FirstOrDefaultAsync(p => p.Id == id);
            return dtpObject != null ? _dataMapper.DtpObjectDtoMapper(dtpObject) : null;
        }

        public async Task<DtpObjectDto> CreateDtpObject(int dtpId, string objectId, DtpObjectDto dtpObjectDto)
        {
            var dtpObject = new DtpObject
            {
                DtpId = dtpId,
                ObjectId = objectId,
                CreatedOn = DateTime.Now,
                IsDataset = dtpObjectDto.IsDataset,
                AccessTypeId = dtpObjectDto.AccessTypeId,
                DownloadAllowed = dtpObjectDto.DownloadAllowed,
                AccessDetails = dtpObjectDto.AccessDetails,
                RequiresEmbargoPeriod = dtpObjectDto.RequiresEmbargoPeriod,
                EmbargoEndDate = dtpObjectDto.EmbargoEndDate,
                EmbargoStillApplies = dtpObjectDto.EmbargoStillApplies,
                AccessCheckStatusId = dtpObjectDto.AccessCheckStatusId,
                AccessCheckDate = dtpObjectDto.AccessCheckDate,
                AccessCheckBy = dtpObjectDto.AccessCheckBy,
                MdCheckStatusId = dtpObjectDto.MdCheckStatusId,
                MdCheckBy = dtpObjectDto.MdCheckBy,
                MdCheckDate = dtpObjectDto.MdCheckDate,
                Notes = dtpObjectDto.Notes
            };

            await _dbConnection.DtpObjects.AddAsync(dtpObject);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtpObjectDtoMapper(dtpObject);
        }

        public async Task<DtpObjectDto> UpdateDtpObject(DtpObjectDto dtpObjectDto)
        {
            var dbDtpObject = await _dbConnection.DtpObjects.FirstOrDefaultAsync(p => p.Id == dtpObjectDto.Id);
            if (dbDtpObject == null) return null;
            
            dbDtpObject.IsDataset = dtpObjectDto.IsDataset;
            dbDtpObject.AccessTypeId = dtpObjectDto.AccessTypeId;
            dbDtpObject.DownloadAllowed = dtpObjectDto.DownloadAllowed;
            dbDtpObject.AccessDetails = dtpObjectDto.AccessDetails;
            dbDtpObject.RequiresEmbargoPeriod = dtpObjectDto.RequiresEmbargoPeriod;
            dbDtpObject.EmbargoEndDate = dtpObjectDto.EmbargoEndDate;
            dbDtpObject.EmbargoStillApplies = dtpObjectDto.EmbargoStillApplies;
            dbDtpObject.AccessCheckStatusId = dtpObjectDto.AccessCheckStatusId;
            dbDtpObject.AccessCheckDate = dtpObjectDto.AccessCheckDate;
            dbDtpObject.AccessCheckBy = dtpObjectDto.AccessCheckBy;
            dbDtpObject.MdCheckStatusId = dtpObjectDto.MdCheckStatusId;
            dbDtpObject.MdCheckBy = dtpObjectDto.MdCheckBy;
            dbDtpObject.MdCheckDate = dtpObjectDto.MdCheckDate;
            dbDtpObject.Notes = dtpObjectDto.Notes;
            
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtpObjectDtoMapper(dbDtpObject);
        }

        public async Task<int> DeleteDtpObject(int id)
        {
            var data = await _dbConnection.DtpObjects.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.DtpObjects.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllDtpObjects(int dtpId)
        {
            var data = _dbConnection.DtpObjects.Where(p => p.DtpId == dtpId);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.DtpObjects.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<DtpStudy> GetQueryableDtpStudies()
        {
            return _dbConnection.DtpStudies;
        }

        public async Task<ICollection<DtpStudyDto>> GetAllDtpStudies(int dtpId)
        {
            var data = _dbConnection.DtpStudies.Where(p => p.DtpId == dtpId);
            return data.Any() ? _dataMapper.DtpStudyDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<DtpStudyDto> GetDtpStudy(int id)
        {
            var dtpStudy = await _dbConnection.DtpStudies.FirstOrDefaultAsync(p => p.Id == id);
            return dtpStudy != null ? _dataMapper.DtpStudyDtoMapper(dtpStudy) : null;
        }

        public async Task<DtpStudyDto> CreateDtpStudy(int dtpId, string studyId, DtpStudyDto dtpStudyDto)
        {
            var dtpStudy = new DtpStudy
            {
                DtpId = dtpId,
                StudyId = studyId,
                CreatedOn = DateTime.Now,
                MdCheckStatusId = dtpStudyDto.MdCheckStatusId,
                MdCheckBy = dtpStudyDto.MdCheckBy,
                MdCheckDate = dtpStudyDto.MdCheckDate
            };

            await _dbConnection.DtpStudies.AddAsync(dtpStudy);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtpStudyDtoMapper(dtpStudy);
        }

        public async Task<DtpStudyDto> UpdateDtpStudy(DtpStudyDto dtpStudyDto)
        {
            var dbDtpStudy = await _dbConnection.DtpStudies.FirstOrDefaultAsync(p => p.Id == dtpStudyDto.Id);
            if (dbDtpStudy == null) return null;
            
            dbDtpStudy.MdCheckStatusId = dtpStudyDto.MdCheckStatusId;
            dbDtpStudy.MdCheckBy = dtpStudyDto.MdCheckBy;
            dbDtpStudy.MdCheckDate = dtpStudyDto.MdCheckDate;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtpStudyDtoMapper(dbDtpStudy);
        }

        public async Task<int> DeleteDtpStudy(int id)
        {
            var data = await _dbConnection.DtpStudies.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.DtpStudies.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllDtpStudies(int dtpId)
        {
            var data = _dbConnection.DtpStudies.Where(p => p.DtpId == dtpId);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.DtpStudies.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<Dtp> GetQueryableDtp()
        {
            return _dbConnection.Dtps;
        }

        public async Task<ICollection<DtpDto>> GetAllDtp()
        {
            return _dbConnection.Dtps.Any() ? _dataMapper.DtpDtoBuilder(await _dbConnection.Dtps.ToArrayAsync()) : null;
        }

        public async Task<DtpDto> GetDtp(int id)
        {
            return _dataMapper.DtpDtoMapper(await _dbConnection.Dtps.FirstOrDefaultAsync(p => p.Id == id));
        }

        public async Task<ICollection<DtpDto>> GetRecentDtp(int limit)
        {
            if (!_dbConnection.Dtps.Any()) return null;

            var recentDtp = await _dbConnection.Dtps.OrderByDescending(p => p.Id).Take(limit).ToArrayAsync();
            return _dataMapper.DtpDtoBuilder(recentDtp);
        }

        public async Task<DtpDto> CreateDtp(DtpDto dtpDto)
        {
            var dtp = new Dtp
            {
                CreatedOn = DateTime.Now,
                OrgId = dtpDto.OrgId,
                DisplayName = dtpDto.DisplayName,
                StatusId = dtpDto.StatusId,
                InitialContactDate = dtpDto.InitialContactDate,
                SetUpCompleted = dtpDto.SetUpCompleted,
                MdAccessGranted = dtpDto.MdAccessGranted,
                MdCompleteDate = dtpDto.MdCompleteDate,
                DtaAgreedDate = dtpDto.DtaAgreedDate,
                UploadAccessRequested = dtpDto.UploadAccessRequested,
                UploadAccessConfirmed = dtpDto.UploadAccessConfirmed,
                UploadsComplete = dtpDto.UploadsComplete,
                QcChecksCompleted = dtpDto.QcChecksCompleted,
                MdIntegratedWithMdr = dtpDto.MdIntegratedWithMdr,
                AvailabilityRequested = dtpDto.AvailabilityRequested,
                AvailabilityConfirmed = dtpDto.AvailabilityConfirmed
            };

            await _dbConnection.Dtps.AddAsync(dtp);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtpDtoMapper(dtp);
        }

        public async Task<DtpDto> UpdateDtp(DtpDto dtpDto)
        {
            var dbDtp = await _dbConnection.Dtps.FirstOrDefaultAsync(p => p.Id == dtpDto.Id);
            if (dbDtp == null) return null;
            
            dbDtp.OrgId = dtpDto.OrgId;
            dbDtp.DisplayName = dtpDto.DisplayName;
            dbDtp.StatusId = dtpDto.StatusId;
            dbDtp.InitialContactDate = dtpDto.InitialContactDate;
            dbDtp.SetUpCompleted = dtpDto.SetUpCompleted;
            dbDtp.MdAccessGranted = dtpDto.MdAccessGranted;
            dbDtp.MdCompleteDate = dtpDto.MdCompleteDate;
            dbDtp.DtaAgreedDate = dtpDto.DtaAgreedDate;
            dbDtp.UploadAccessRequested = dtpDto.UploadAccessRequested;
            dbDtp.UploadAccessConfirmed = dtpDto.UploadAccessConfirmed;
            dbDtp.UploadsComplete = dtpDto.UploadsComplete;
            dbDtp.QcChecksCompleted = dtpDto.QcChecksCompleted;
            dbDtp.MdIntegratedWithMdr = dtpDto.MdIntegratedWithMdr;
            dbDtp.AvailabilityRequested = dtpDto.AvailabilityRequested;
            dbDtp.AvailabilityConfirmed = dtpDto.AvailabilityConfirmed;
                
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DtpDtoMapper(dbDtp);
        }

        public async Task<int> DeleteDtp(int id)
        {
            var data = await _dbConnection.Dtps.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.Dtps.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }


        private static int CalculateSkip(int page, int size)
        {
            var skip = 0;
            if (page > 1)
            {
                skip = (page - 1) * size;
            }

            return skip;
        }

        public async Task<PaginationResponse<DtpDto>> PaginateDtp(PaginationRequest paginationRequest)
        {
            var dtp = new List<DtpDto>();

            var skip = CalculateSkip(paginationRequest.Page, paginationRequest.Size);

            var query = _dbConnection.Dtps
                .AsNoTracking()
                .OrderBy(arg => arg.Id);

            var data = await query
                .Skip(skip)
                .Take(paginationRequest.Size)
                .ToListAsync();
            
            var total = await query.CountAsync();

            if (data is {Count: > 0})
            {
                foreach (var dtpRecord in data)
                {
                    dtp.Add(_dataMapper.DtpDtoMapper(dtpRecord));
                }
            }

            return new PaginationResponse<DtpDto>
            {
                Total = total,
                Data = dtp
            };
        }

        public async Task<PaginationResponse<DtpDto>> FilterDtpByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            var dtp = new List<DtpDto>();

            var skip = CalculateSkip(filteringByTitleRequest.Page, filteringByTitleRequest.Size);

            var query = _dbConnection.Dtps
                .AsNoTracking()
                .Where(p => p.DisplayName.ToLower().Contains(filteringByTitleRequest.Title.ToLower()))
                .OrderBy(arg => arg.Id);

            var data = await query
                .Skip(skip)
                .Take(filteringByTitleRequest.Size)
                .ToListAsync();
            
            var total = await query.CountAsync();

            if (data is {Count: > 0})
            {
                foreach (var dtpRecord in data)
                {
                    dtp.Add(_dataMapper.DtpDtoMapper(dtpRecord));
                }
            }

            return new PaginationResponse<DtpDto>
            {
                Total = total,
                Data = dtp
            };
        }

        public async Task<int> GetTotalDtp()
        {
            return await _dbConnection.Dtps.AsNoTracking().CountAsync();
        }

        public async Task<int> GetUncompletedDtp()
        {
            return await _dbConnection.Dtps.AsNoTracking().Where(p => p.StatusId == 16).CountAsync();
        }
    }
}