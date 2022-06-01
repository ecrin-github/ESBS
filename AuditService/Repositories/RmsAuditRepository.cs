using AuditService.Contracts.Request.v1;
using AuditService.Contracts.Response.v1;
using AuditService.Interfaces;
using AuditService.Models.Audit.RMS;
using AuditService.Models.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Repositories;

public class RmsAuditRepository : IRmsAuditRepository
{
    private AuditDbConnection _dbConnection;
    private IUserIdentityService _identityService;
    private IDataMapper _dataMapper;

    public RmsAuditRepository(
        AuditDbConnection auditDbConnection, 
        IUserIdentityService identityService,
        IDataMapper dataMapper)
    {
        _dbConnection = auditDbConnection ?? throw new ArgumentNullException(nameof(auditDbConnection));
        _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
    }
    
    public async Task<AuditResponseDto> CreateRmsAuditRecordChange(AuditRequestDto auditRequestDto)
    {
        var rmsAuditRecord = new RmsRecordChange
        {
            TableId = auditRequestDto.TableId,
            TableName = auditRequestDto.TableName,
            ChangeType = auditRequestDto.ChangeType,
            ChangeTime = DateTime.Now,
            UserName = null,
            Prior = auditRequestDto.Prior,
            Post = auditRequestDto.Post
        };
        await _dbConnection.RmsRecordChanges.AddAsync(rmsAuditRecord);
        await _dbConnection.SaveChangesAsync();
        return _dataMapper.BuildRmsAuditResponse(rmsAuditRecord);
    }

    public async Task<AuditResponseDto[]?> GetRmsTableAuditHistory(string tableName)
    {
        var checkRecords = await _dbConnection.RmsRecordChanges.AnyAsync();
        if (!checkRecords) return null;

        var res = await _dbConnection.RmsRecordChanges.AsNoTracking().Where(p => p.TableName!.ToLower() == tableName.ToLower()).ToArrayAsync();
        return _dataMapper.MapRmsAuditRecords(res);
    }

    public async Task<AuditResponseDto[]?> GetUserRmsAuditHistory(string accessToken)
    {
        var checkRecords = await _dbConnection.RmsRecordChanges.AnyAsync();
        if (!checkRecords) return null;

        var userName = await _identityService.GetUserIdentity(accessToken);
        if (userName == null) return null;

        var res = await _dbConnection.RmsRecordChanges.AsNoTracking().Where(p => p.UserName!.ToLower() == userName.ToLower()).ToArrayAsync();
        return _dataMapper.MapRmsAuditRecords(res);
    }
}