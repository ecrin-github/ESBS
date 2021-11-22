using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Models.Object;
using MdrService.Models.Study;

namespace MdrService.Interfaces
{
    public interface ILinksRepository
    {
        Task<ICollection<int>> GetObjectStudies(int objectId);
        Task<ICollection<int>> GetStudyObjects(int studyId);
    }
}