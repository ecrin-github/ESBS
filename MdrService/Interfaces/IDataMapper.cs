using System.Collections.Generic;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Models.Elasticsearch.Study;

namespace MdrService.Interfaces
{
    public interface IDataMapper
    {
        List<StudyListResponse> MapStudies(IEnumerable<Study> studies);
    }
}