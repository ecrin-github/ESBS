using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using context_services.Interfaces;
using context_services.Models.DbConnection;
using context_services.Models.Rms;
using LinqToDB;

namespace context_services.Repositories
{
    public class RmsContextRepository : IRmsContextRepository
    {
        private readonly RmsDbConnection _dbConnection;

        public RmsContextRepository(RmsDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<ICollection<AccessPrereqType>> GetAccessPrereqTypes()
        {
            if (!_dbConnection.AccessPrereqTypes.Any()) return null;
            return await _dbConnection.AccessPrereqTypes.ToArrayAsync();
        }

        public async Task<AccessPrereqType> GetAccessPrereqType(int id)
        {
            if (!_dbConnection.AccessPrereqTypes.Any()) return null;
            return await _dbConnection.AccessPrereqTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<CheckStatusType>> GetCheckStatusTypes()
        {
            if (!_dbConnection.CheckStatusTypes.Any()) return null;
            return await _dbConnection.CheckStatusTypes.ToArrayAsync();
        }

        public async Task<CheckStatusType> GetCheckStatusType(int id)
        {
            if (!_dbConnection.CheckStatusTypes.Any()) return null;
            return await _dbConnection.CheckStatusTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DtpStatusType>> GetDtpStatusTypes()
        {
            if (!_dbConnection.DtpStatusTypes.Any()) return null;
            return await _dbConnection.DtpStatusTypes.ToArrayAsync();
        }

        public async Task<DtpStatusType> GetDtpStatusType(int id)
        {
            if (!_dbConnection.DtpStatusTypes.Any()) return null;
            return await _dbConnection.DtpStatusTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DupStatusType>> GetDupStatusTypes()
        {
            if (!_dbConnection.DupStatusTypes.Any()) return null;
            return await _dbConnection.DupStatusTypes.ToArrayAsync();
        }

        public async Task<DupStatusType> GetDupStatusType(int id)
        {
            if (!_dbConnection.DupStatusTypes.Any()) return null;
            return await _dbConnection.DupStatusTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<LegalStatusType>> GetLegalStatusTypes()
        {
            if (!_dbConnection.LegalStatusTypes.Any()) return null;
            return await _dbConnection.LegalStatusTypes.ToArrayAsync();
        }

        public async Task<LegalStatusType> GetLegalStatusType(int id)
        {
            if (!_dbConnection.LegalStatusTypes.Any()) return null;
            return await _dbConnection.LegalStatusTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<RepoAccessType>> GetRepoAccessTypes()
        {
            if (!_dbConnection.RepoAccessTypes.Any()) return null;
            return await _dbConnection.RepoAccessTypes.ToArrayAsync();
        }

        public async Task<RepoAccessType> GetRepoAccessType(int id)
        {
            if (!_dbConnection.RepoAccessTypes.Any()) return null;
            return await _dbConnection.RepoAccessTypes.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}