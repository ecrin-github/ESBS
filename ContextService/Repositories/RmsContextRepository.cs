using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContextService.Interfaces;
using ContextService.Models.DbConnection;
using ContextService.Models.Rms;
using Microsoft.EntityFrameworkCore;

namespace ContextService.Repositories
{
    public class RmsContextRepository : IRmsContextRepository
    {
        private readonly RmsDbConnection _dbConnection;

        public RmsContextRepository(RmsDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }
        
        public async Task<ICollection<AccessPrereqType>> GetAccessPrereqTypes()
        {
            if (!_dbConnection.AccessPrereqTypes.Any()) return null;
            return await _dbConnection.AccessPrereqTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<AccessPrereqType> GetAccessPrereqType(int id)
        {
            if (!_dbConnection.AccessPrereqTypes.Any()) return null;
            return await _dbConnection.AccessPrereqTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<CheckStatusType>> GetCheckStatusTypes()
        {
            if (!_dbConnection.CheckStatusTypes.Any()) return null;
            return await _dbConnection.CheckStatusTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<CheckStatusType> GetCheckStatusType(int id)
        {
            if (!_dbConnection.CheckStatusTypes.Any()) return null;
            return await _dbConnection.CheckStatusTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DtpStatusType>> GetDtpStatusTypes()
        {
            if (!_dbConnection.DtpStatusTypes.Any()) return null;
            return await _dbConnection.DtpStatusTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<DtpStatusType> GetDtpStatusType(int id)
        {
            if (!_dbConnection.DtpStatusTypes.Any()) return null;
            return await _dbConnection.DtpStatusTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DupStatusType>> GetDupStatusTypes()
        {
            if (!_dbConnection.DupStatusTypes.Any()) return null;
            return await _dbConnection.DupStatusTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<DupStatusType> GetDupStatusType(int id)
        {
            if (!_dbConnection.DupStatusTypes.Any()) return null;
            return await _dbConnection.DupStatusTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<LegalStatusType>> GetLegalStatusTypes()
        {
            if (!_dbConnection.LegalStatusTypes.Any()) return null;
            return await _dbConnection.LegalStatusTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<LegalStatusType> GetLegalStatusType(int id)
        {
            if (!_dbConnection.LegalStatusTypes.Any()) return null;
            return await _dbConnection.LegalStatusTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<RepoAccessType>> GetRepoAccessTypes()
        {
            if (!_dbConnection.RepoAccessTypes.Any()) return null;
            return await _dbConnection.RepoAccessTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<RepoAccessType> GetRepoAccessType(int id)
        {
            if (!_dbConnection.RepoAccessTypes.Any()) return null;
            return await _dbConnection.RepoAccessTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}