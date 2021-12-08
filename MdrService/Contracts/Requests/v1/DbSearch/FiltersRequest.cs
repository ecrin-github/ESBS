using System.Collections.Generic;

namespace MdrService.Contracts.Requests.v1.DbSearch
{
    public class FiltersRequest
    {
        public IList<int> StudyTypes { get; set; }
        public IList<int> StudyStatuses { get; set; }
        public IList<int> StudyGenderEligibility { get; set; }
        public IList<int> StudyFeatureValues { get; set; }
        public IList<int> ObjectTypes { get; set; }
        public IList<int> ObjectAccessTypes { get; set; }
    }
}