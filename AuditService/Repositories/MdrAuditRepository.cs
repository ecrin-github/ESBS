using AuditService.Contracts.Request.v1;
using AuditService.Contracts.Response.v1;
using AuditService.Interfaces;
using AuditService.Models.Audit.MDR;
using AuditService.Models.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Repositories;

public class MdrAuditRepository : IMdrAuditRepository
{
    private readonly AuditDbConnection _dbConnection;
    private IUserIdentityService _identityService;
    private IDataMapper _dataMapper;

    public MdrAuditRepository(
        AuditDbConnection auditDbConnection, 
        IUserIdentityService identityService,
        IDataMapper dataMapper)
    {
        _dbConnection = auditDbConnection ?? throw new ArgumentNullException(nameof(auditDbConnection));
        _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
    }
    
    public async Task<AuditResponseDto> CreateMdrAuditRecordChange(AuditRequestDto auditRequestDto)
    {
        var mdrAuditRecord = new MdrRecordChange
        {
            TableId = auditRequestDto.TableId,
            TableName = auditRequestDto.TableName,
            ChangeType = auditRequestDto.ChangeType,
            ChangeTime = DateTime.Now,
            UserName = null,
            Prior = auditRequestDto.Prior,
            Post = auditRequestDto.Post
        };
        await _dbConnection.MdrRecordChanges.AddAsync(mdrAuditRecord);
        await _dbConnection.SaveChangesAsync();
        return _dataMapper.BuildMdrAuditResponse(mdrAuditRecord);
    }

    public async Task<AuditResponseDto[]?> GetMdrTableAuditHistory(string tableName)
    {
        var checkRecords = await _dbConnection.MdrRecordChanges.AnyAsync();
        if (!checkRecords) return null;
        var res = await _dbConnection.MdrRecordChanges.AsNoTracking().Where(p => p.TableName!.ToLower() == tableName.ToLower()).ToArrayAsync();
        return _dataMapper.MapMdrAuditRecords(res);
    }

    public async Task<AuditResponseDto[]?> GetUserMdrAuditHistory(string accessToken)
    {
        var checkRecords = await _dbConnection.MdrRecordChanges.AnyAsync();
        if (!checkRecords) return null;

        var userName = await _identityService.GetUserIdentity(accessToken);
        if (userName == null) return null;

        var res = await _dbConnection.MdrRecordChanges.AsNoTracking().Where(p => p.UserName!.ToLower() == userName.ToLower()).ToArrayAsync();
        return _dataMapper.MapMdrAuditRecords(res);
    }
}