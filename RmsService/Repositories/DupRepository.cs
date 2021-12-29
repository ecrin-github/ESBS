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
    public class DupRepository : IDupRepository
    {
        private readonly RmsDbConnection _dbConnection;
        private readonly IDataMapper _dataMapper;

        public DupRepository(RmsDbConnection dbContext, IDataMapper dataMapper)
        {
            _dbConnection = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
        }

        public IQueryable<DupObject> GetQueryableDupObjects()
        {
            return _dbConnection.DupObjects;
        }

        public async Task<ICollection<DupObjectDto>> GetDupObjects(int dupId)
        {
            var data = _dbConnection.DupObjects.Where(p => p.DupId == dupId);
            return data.Any() ? _dataMapper.DupObjectDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<DupObjectDto> GetDupObject(int id)
        {
            var dupObject = await _dbConnection.DupObjects.FirstOrDefaultAsync(p => p.Id == id);
            return dupObject != null ? _dataMapper.DupObjectDtoMapper(dupObject) : null;
        }

        public async Task<DupObjectDto> CreateDupObject(int dupId, DupObjectDto dupObjectDto)
        {
            var dupObject = new DupObject
            {
                DupId = dupId,
                CreatedOn = DateTime.Now,
                ObjectId = dupObjectDto.ObjectId,
                AccessTypeId = dupObjectDto.AccessTypeId,
                AccessDetails = dupObjectDto.AccessDetails,
                Notes = dupObjectDto.Notes
            };

            await _dbConnection.DupObjects.AddAsync(dupObject);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DupObjectDtoMapper(dupObject);
        }

        public async Task<DupObjectDto> UpdateDupObject(DupObjectDto dupObjectDto)
        {
            var dbDupObject = await _dbConnection.DupObjects.FirstOrDefaultAsync(p => p.Id == dupObjectDto.Id);
            if (dbDupObject == null) return null;
            
            dbDupObject.ObjectId = dupObjectDto.ObjectId;
            dbDupObject.AccessTypeId = dupObjectDto.AccessTypeId;
            dbDupObject.AccessDetails = dupObjectDto.AccessDetails;
            dbDupObject.Notes = dupObjectDto.Notes;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DupObjectDtoMapper(dbDupObject);
        }

        public async Task<int> DeleteDupObject(int id)
        {
            var data = await _dbConnection.DupObjects.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.DupObjects.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllDupObjects(int dupId)
        {
            var data = _dbConnection.DupObjects.Where(p => p.DupId == dupId);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.DupObjects.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<DupPrereq> GetQueryableDupPrereqs()
        {
            return _dbConnection.DupPrereqs;
        }

        public async Task<ICollection<DupPrereqDto>> GetDupPrereqs(int dupId)
        {
            var data = _dbConnection.DupPrereqs.Where(p => p.DupId == dupId);
            return data.Any() ? _dataMapper.DupPrereqDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<DupPrereqDto> GetDupPrereq(int id)
        {
            var dupPrereq = await _dbConnection.DupPrereqs.FirstOrDefaultAsync(p => p.Id == id);
            return dupPrereq != null ? _dataMapper.DupPrereqDtoMapper(dupPrereq) : null;
        }

        public async Task<DupPrereqDto> CreateDupPrereq(int dupId, DupPrereqDto dupPrereqDto)
        {
            var dupPrereq = new DupPrereq
            {
                DupId = dupId,
                CreatedOn = DateTime.Now,
                ObjectId = dupPrereqDto.ObjectId,
                MetNotes = dupPrereqDto.MetNotes,
                PreRequisiteId = dupPrereqDto.PreRequisiteId,
                PrerequisiteMet = dupPrereqDto.PrerequisiteMet
            };

            await _dbConnection.DupPrereqs.AddAsync(dupPrereq);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DupPrereqDtoMapper(dupPrereq);
        }

        public async Task<DupPrereqDto> UpdateDupPrereq(DupPrereqDto dupPrereqDto)
        {
            var dbDupPrereq = await _dbConnection.DupPrereqs.FirstOrDefaultAsync(p => p.Id == dupPrereqDto.Id);
            if (dbDupPrereq == null) return null;
            
            dbDupPrereq.ObjectId = dupPrereqDto.ObjectId;
            dbDupPrereq.MetNotes = dupPrereqDto.MetNotes;
            dbDupPrereq.PreRequisiteId = dupPrereqDto.PreRequisiteId;
            dbDupPrereq.PrerequisiteMet = dupPrereqDto.PrerequisiteMet;

            await _dbConnection.SaveChangesAsync();
            return _dataMapper.DupPrereqDtoMapper(dbDupPrereq);
        }

        public async Task<int> DeleteDupPrereq(int id)
        {
            var data = await _dbConnection.DupPrereqs.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.DupPrereqs.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllDupPrereqs(int dupId)
        {
            var data = _dbConnection.DupPrereqs.Where(p => p.DupId == dupId);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.DupPrereqs.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<SecondaryUse> GetQueryableSecondaryUses()
        {
            return _dbConnection.SecondaryUses;
        }

        public async Task<ICollection<SecondaryUseDto>> GetSecondaryUses(int dupId)
        {
            var data = _dbConnection.SecondaryUses.Where(p => p.DupId == dupId);
            return data.Any() ? _dataMapper.SecondaryUseDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<SecondaryUseDto> GetSecondaryUse(int id)
        {
            var secUse = await _dbConnection.SecondaryUses.FirstOrDefaultAsync(p => p.Id == id);
            return secUse != null ? _dataMapper.SecondaryUseDtoMapper(secUse) : null;
        }

        public async Task<SecondaryUseDto> CreateSecondaryUse(int dupId, SecondaryUseDto secondaryUseDto)
        {
            var secondaryUse = new SecondaryUse
            {
                DupId = dupId,
                CreatedOn = DateTime.Now,
                SecondaryUseType = secondaryUseDto.SecondaryUseType,
                Publication = secondaryUseDto.Publication,
                Doi = secondaryUseDto.Doi,
                AttributionPresent = secondaryUseDto.AttributionPresent,
                Notes = secondaryUseDto.Notes
            };

            await _dbConnection.SecondaryUses.AddAsync(secondaryUse);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.SecondaryUseDtoMapper(secondaryUse);
        }

        public async Task<SecondaryUseDto> UpdateSecondaryUse(SecondaryUseDto secondaryUseDto)
        {
            var dbSecondaryUse =
                await _dbConnection.SecondaryUses.FirstOrDefaultAsync(p => p.Id == secondaryUseDto.Id);
            if (dbSecondaryUse == null) return null;
            
            dbSecondaryUse.SecondaryUseType = secondaryUseDto.SecondaryUseType;
            dbSecondaryUse.Publication = secondaryUseDto.Publication;
            dbSecondaryUse.Doi = secondaryUseDto.Doi;
            dbSecondaryUse.AttributionPresent = secondaryUseDto.AttributionPresent;
            dbSecondaryUse.Notes = secondaryUseDto.Notes;

            await _dbConnection.SaveChangesAsync();
            return _dataMapper.SecondaryUseDtoMapper(dbSecondaryUse);
        }

        public async Task<int> DeleteSecondaryUse(int id)
        {
            var data = await _dbConnection.SecondaryUses.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.SecondaryUses.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllSecondaryUses(int dupId)
        {
            var data = _dbConnection.SecondaryUses.Where(p => p.DupId == dupId);
            if (!data.Any()) return 0;

            var count = data.Count();
            _dbConnection.SecondaryUses.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<Dua> GetQueryableDua()
        {
            return _dbConnection.Duas;
        }

        public async Task<ICollection<DuaDto>> GetAllDua(int dupId)
        {
            var data = _dbConnection.Duas.Where(p => p.DupId == dupId);
            return data.Any() ? _dataMapper.DuaDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<DuaDto> GetDua(int id)
        {
            var dua = await _dbConnection.Duas.FirstOrDefaultAsync(p => p.Id == id);
            return dua != null ? _dataMapper.DuaDtoMapper(dua) : null;
        }

        public async Task<DuaDto> CreateDua(int dupId, DuaDto duaDto)
        {
            var dua = new Dua
            {
                DupId = dupId,
                CreatedOn = DateTime.Now,
                ConformsToDefault = duaDto.ConformsToDefault,
                Variations = duaDto.Variations,
                RepoAsProxy = duaDto.RepoAsProxy,
                RepoSignatory1 = duaDto.RepoSignatory1,
                RepoSignatory2 = duaDto.RepoSignatory2,
                ProviderSignatory1 = duaDto.ProviderSignatory1,
                ProviderSignatory2 = duaDto.ProviderSignatory2,
                RequesterSignatory1 = duaDto.RequesterSignatory1,
                RequesterSignatory2 = duaDto.RequesterSignatory2,
                Notes = duaDto.Notes
            };

            await _dbConnection.Duas.AddAsync(dua);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DuaDtoMapper(dua);
        }

        public async Task<DuaDto> UpdateDua(DuaDto duaDto)
        {
            var dbDua = await _dbConnection.Duas.FirstOrDefaultAsync(p => p.Id == duaDto.Id);
            if (dbDua == null) return null;
            
            dbDua.ConformsToDefault = duaDto.ConformsToDefault;
            dbDua.Variations = duaDto.Variations;
            dbDua.RepoAsProxy = duaDto.RepoAsProxy;
            dbDua.RepoSignatory1 = duaDto.RepoSignatory1;
            dbDua.RepoSignatory2 = duaDto.RepoSignatory2;
            dbDua.ProviderSignatory1 = duaDto.ProviderSignatory1;
            dbDua.ProviderSignatory2 = duaDto.ProviderSignatory2;
            dbDua.RequesterSignatory1 = duaDto.RequesterSignatory1;
            dbDua.RequesterSignatory2 = duaDto.RequesterSignatory2;
            dbDua.Notes = duaDto.Notes;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DuaDtoMapper(dbDua);
        }

        public async Task<int> DeleteDua(int id)
        {
            var data = await _dbConnection.Duas.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.Duas.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllDua(int dupId)
        {
            var data = _dbConnection.Duas.Where(p => p.DupId == dupId);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.Duas.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<Dup> GetQueryableDup()
        {
            return _dbConnection.Dups;
        }

        public async Task<ICollection<DupDto>> GetAllDup()
        {
            return _dbConnection.Dups.Any() ? _dataMapper.DupDtoBuilder(await _dbConnection.Dups.ToArrayAsync()) : null;
        }

        public async Task<DupDto> GetDup(int id)
        {
            var dup = await _dbConnection.Dups.FirstOrDefaultAsync(p => p.Id == id);
            return dup == null ? null : _dataMapper.DupDtoMapper(dup);
        }

        public async Task<ICollection<DupDto>> GetRecentDup(int limit)
        {
            if (!_dbConnection.Dups.Any()) return null;

            var recentDup = await _dbConnection.Dups.OrderByDescending(p => p.Id).Take(limit).ToArrayAsync();
            return _dataMapper.DupDtoBuilder(recentDup);
        }

        public async Task<DupDto> CreateDup(DupDto dupDto)
        {
            var dup = new Dup
            {
                CreatedOn = DateTime.Now,
                OrgId = dupDto.OrgId,
                DisplayName = dupDto.DisplayName,
                StatusId = dupDto.StatusId,
                InitialContactDate = dupDto.InitialContactDate,
                SetUpCompleted = dupDto.SetUpCompleted,
                PrereqsMet = dupDto.PrereqsMet,
                DuaAgreedDate = dupDto.DuaAgreedDate,
                AvailabilityRequested = dupDto.AvailabilityRequested,
                AvailabilityConfirmed = dupDto.AvailabilityConfirmed,
                AccessConfirmed = dupDto.AccessConfirmed
            };

            await _dbConnection.Dups.AddAsync(dup);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DupDtoMapper(dup);
        }

        public async Task<DupDto> UpdateDup(DupDto dupDto)
        {
            var dbDup = await _dbConnection.Dups.FirstOrDefaultAsync(p => p.Id == dupDto.Id);
            if (dbDup == null) return null;
            
            dbDup.OrgId = dupDto.OrgId;
            dbDup.DisplayName = dupDto.DisplayName;
            dbDup.StatusId = dupDto.StatusId;
            dbDup.InitialContactDate = dupDto.InitialContactDate;
            dbDup.SetUpCompleted = dupDto.SetUpCompleted;
            dbDup.PrereqsMet = dupDto.PrereqsMet;
            dbDup.DuaAgreedDate = dupDto.DuaAgreedDate;
            dbDup.AvailabilityRequested = dupDto.AvailabilityRequested;
            dbDup.AvailabilityConfirmed = dupDto.AvailabilityConfirmed;
            dbDup.AccessConfirmed = dupDto.AccessConfirmed;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DupDtoMapper(dbDup);
        }

        public async Task<int> DeleteDup(int id)
        {
            var dup = await _dbConnection.Dups.FirstOrDefaultAsync(p => p.Id == id);
            if (dup == null) return 0;
            
            await DeleteAllDua(id);
            await DeleteAllDupObjects(id);
            await DeleteAllDupPrereqs(id);
            await DeleteAllSecondaryUses(id);

            _dbConnection.Dups.Remove(dup);
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

        public async Task<PaginationResponse<DupDto>> PaginateDup(PaginationRequest paginationRequest)
        {
            var dup = new List<DupDto>();

            var skip = CalculateSkip(paginationRequest.Page, paginationRequest.Size);

            var query = _dbConnection.Dups
                .AsNoTracking()
                .OrderBy(arg => arg.Id);

            var data = await query
                .Skip(skip)
                .Take(paginationRequest.Size)
                .ToListAsync();
            
            var total = await query.CountAsync();

            if (data is {Count: > 0})
            {
                foreach (var dupRecord in data)
                {
                    dup.Add(_dataMapper.DupDtoMapper(dupRecord));
                }
            }

            return new PaginationResponse<DupDto>
            {
                Total = total,
                Data = dup
            };
        }

        public async Task<PaginationResponse<DupDto>> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            var dup = new List<DupDto>();

            var skip = CalculateSkip(filteringByTitleRequest.Page, filteringByTitleRequest.Size);

            var query = _dbConnection.Dups
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
                foreach (var dupRecord in data)
                {
                    dup.Add(_dataMapper.DupDtoMapper(dupRecord));
                }
            }

            return new PaginationResponse<DupDto>
            {
                Total = total,
                Data = dup
            };
        }

        public async Task<int> GetTotalDup()
        {
            return await _dbConnection.Dups.AsNoTracking().CountAsync();
        }

        public async Task<int> GetUncompletedDup()
        {
            return await _dbConnection.Dups.AsNoTracking().Where(p => p.StatusId == 16).CountAsync();
        }
    }
}