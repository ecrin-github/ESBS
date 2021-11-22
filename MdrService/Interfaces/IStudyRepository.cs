using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Models.Study;

namespace MdrService.Interfaces
{
    public interface IStudyRepository
    {
        Task<Study> GetStudyById(int? id);
        Task<ICollection<Study>> GetStudies(ICollection<int> ids);

        Task<ICollection<StudyContributor>> GetStudyContributors(int studyId);
        Task<ICollection<StudyFeature>> GetStudyFeatures(int studyId);
        Task<ICollection<StudyIdentifier>> GetStudyIdentifiers(int studyId);
        Task<ICollection<StudyRelationship>> GetStudyRelationships(int studyId);
        Task<ICollection<StudyTitle>> GetStudyTitles(int studyId);
        Task<ICollection<StudyTopic>> GetStudyTopics(int studyId);
    }
}