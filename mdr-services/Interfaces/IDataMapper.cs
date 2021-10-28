using System.Collections.Generic;
using System.Threading.Tasks;
using mdr_services.Contracts.Requests.v1;
using mdr_services.Contracts.Responses.v1.FetchedData;
using mdr_services.Contracts.Responses.v1.StudyListResponse;
using mdr_services.Models.Elasticsearch.Object;
using mdr_services.Models.Elasticsearch.Study;

namespace mdr_services.Interfaces
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