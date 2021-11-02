using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1;

namespace MdrService.Interfaces
{
    public interface IRawQueryRepository
    {
        Task<BaseResponse> GetStudySearchResults(RawQueryRequest rawQueryRequest);
        Task<BaseResponse> GetObjectSearchResults(RawQueryRequest rawQueryRequest);
    }
}