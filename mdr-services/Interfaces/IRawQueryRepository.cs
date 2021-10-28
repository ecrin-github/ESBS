using System.Threading.Tasks;
using mdr_services.Contracts.Requests.v1;
using mdr_services.Contracts.Responses.v1;

namespace mdr_services.Interfaces
{
    public interface IRawQueryRepository
    {
        Task<BaseResponse> GetStudySearchResults(RawQueryRequest rawQueryRequest);
        Task<BaseResponse> GetObjectSearchResults(RawQueryRequest rawQueryRequest);
    }
}