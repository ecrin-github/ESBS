using System.Collections.Generic;

namespace MdrService.Contracts.Requests.v1
{
    public class FiltersRequest
    {
        public ICollection<int> StudyTypes { get; set; }
        public ICollection<int> StudyStatuses { get; set; }
        public ICollection<int> StudyGenderEligibility { get; set; }
        public ICollection<int> StudyFeatureValues { get; set; }
        public ICollection<int> ObjectTypes { get; set; }
        public ICollection<int> ObjectAccessTypes { get; set; }
    }
}