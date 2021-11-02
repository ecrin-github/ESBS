using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1.FetchedData;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Models.Elasticsearch.Object;
using MdrService.Models.Elasticsearch.Study;

namespace MdrService.Interfaces
{
    public interface IDataMapper
    {
        Task<List<StudyListResponse>> MapStudy(ICollection<Study> studies);
        
        Task<List<StudyListResponse>> MapRawStudies(ICollection<Study> studies);
        
        Task<List<StudyListResponse>> MapRawObjects(ICollection<Object> objects);

        Task<List<StudyListResponse>> MapViaPublishedPaper(ICollection<Object> objects);

        Task<List<StudyListResponse>> MapStudies(FetchedStudies fetchedStudies, FiltersListRequest filtersListRequest);
    }
}