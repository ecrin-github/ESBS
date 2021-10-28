using System.Threading.Tasks;
using mdr_services.Contracts.Responses.v1.FetchedData;

namespace mdr_services.Interfaces
{
    public interface IFetchedDataRepository
    {
        Task<FetchedObjects> GetStudyObjects(int[] ids);
        Task<FetchedStudies> GetObjectStudies(int[] ids);
    }
}