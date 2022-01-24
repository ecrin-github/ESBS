using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdmService.DTO.Audit;
using MdmService.Interfaces;
using MdmService.Models.Audit;
using MdmService.Models.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace MdmService.Services
{
    public class AuditService : IAuditService
    {
        private readonly MdmDbConnection _dbConnection;

        public AuditService(MdmDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<bool> AddAuditRecord(AuditDto auditDto)
        {
            if (auditDto == null) return false;
            var auditRecord = new RecordChange()
            {
                TableId = auditDto.TableId,
                TableName = auditDto.TableName,
                ChangeType = auditDto.ChangeType,
                ChangeTime = DateTime.Now,
                UserName = auditDto.UserName,
                Prior = auditDto.Prior,
                Post = auditDto.Post
            };
            await _dbConnection.RecordChanges.AddAsync(auditRecord);
            await _dbConnection.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<RecordChange>> GetTableAuditHistory(string tableName)
        {
            var checkRecords = await _dbConnection.RecordChanges.AnyAsync();
            if (!checkRecords) return null;
            return await _dbConnection.RecordChanges.AsNoTracking().Where(p => p.TableName.ToLower() == tableName.ToLower()).ToArrayAsync();
        }

        public async Task<ICollection<RecordChange>> GetUserAuditHistory(string userName)
        {
            var checkRecords = await _dbConnection.RecordChanges.AnyAsync();
            if (!checkRecords) return null;
            return await _dbConnection.RecordChanges.AsNoTracking().Where(p => p.UserName.ToLower() == userName.ToLower()).ToArrayAsync();
        }
    }
}