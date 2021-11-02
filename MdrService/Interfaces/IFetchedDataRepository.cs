using System.Threading.Tasks;
using MdrService.Contracts.Responses.v1.FetchedData;

namespace MdrService.Interfaces
{
    public interface IFetchedDataRepository
    {
        Task<FetchedObjects> GetStudyObjects(int[] ids);
        Task<FetchedStudies> GetObjectStudies(int[] ids);
    }
}