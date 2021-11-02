using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdmService.DTO.Study;
using MdmService.Models.Study;

namespace MdmService.Interfaces
{
    public interface IStudyRepository
    {
        // Study
        IQueryable<Study> GetQueryableStudies();
        Task<ICollection<StudyDto>> GetAllStudies();
        Task<StudyDto> GetStudyById(string sdSid);
        Task<StudyDto> CreateStudy(StudyDto studyDto);
        Task<StudyDto> UpdateStudy(StudyDto studyDto);
        Task<int> DeleteStudy(string sdSid);
        
        // Study data
        Task<ICollection<StudyDataDto>> GetStudiesData();
        Task<StudyDataDto> GetStudyData(string sdSid);
        Task<ICollection<StudyDataDto>> GetRecentStudyData(int limit);
        Task<StudyDataDto> CreateStudyData(StudyDataDto studyData);
        Task<StudyDataDto> UpdateStudyData(StudyDataDto studyData);

        // Study contributors
        IQueryable<StudyContributor> GetQueryableStudyContributors();
        Task<ICollection<StudyContributorDto>> GetStudyContributors(string sdSid);
        Task<StudyContributorDto> GetStudyContributor(int? id);
        Task<StudyContributorDto> CreateStudyContributor(string sdSid, StudyContributorDto studyContributorDto);
        Task<StudyContributorDto> UpdateStudyContributor(StudyContributorDto studyContributorDto);
        Task<int> DeleteStudyContributor(int id);
        Task<int> DeleteAllStudyContributors(string sdSid);

        // Study features
        IQueryable<StudyFeature> GetQueryableStudyFeatures();
        Task<ICollection<StudyFeatureDto>> GetStudyFeatures(string sdSid);
        Task<StudyFeatureDto> GetStudyFeature(int id);
        Task<StudyFeatureDto> CreateStudyFeature(string sdSid, StudyFeatureDto studyFeatureDto);
        Task<StudyFeatureDto> UpdateStudyFeature(StudyFeatureDto studyFeatureDto);
        Task<int> DeleteStudyFeature(int id);
        Task<int> DeleteAllStudyFeatures(string sdSid);

        // Study identifiers
        IQueryable<StudyIdentifier> GetQueryableStudyIdentifiers();
        Task<ICollection<StudyIdentifierDto>> GetStudyIdentifiers(string sdSid);
        Task<StudyIdentifierDto> GetStudyIdentifier(int id);
        Task<StudyIdentifierDto> CreateStudyIdentifier(string sdSid, StudyIdentifierDto studyIdentifierDto);
        Task<StudyIdentifierDto> UpdateStudyIdentifier(StudyIdentifierDto studyIdentifierDto);
        Task<int> DeleteStudyIdentifier(int id);
        Task<int> DeleteAllStudyIdentifiers(string sdSid);

        // Study references
        IQueryable<StudyReference> GetQueryableStudyReferences();
        Task<ICollection<StudyReferenceDto>> GetStudyReferences(string sdSid);
        Task<StudyReferenceDto> GetStudyReference(int id);
        Task<StudyReferenceDto> CreateStudyReference(string sdSid, StudyReferenceDto studyReferenceDto);
        Task<StudyReferenceDto> UpdateStudyReference(StudyReferenceDto studyReferenceDto);
        Task<int> DeleteStudyReference(int id);
        Task<int> DeleteAllStudyReferences(string sdSid);

        // Study relationships
        IQueryable<StudyRelationship> GetQueryableStudyRelationships();
        Task<ICollection<StudyRelationshipDto>> GetStudyRelationships(string sdSid);
        Task<StudyRelationshipDto> GetStudyRelationship(int id);
        Task<StudyRelationshipDto> CreateStudyRelationship(string sdSid, StudyRelationshipDto studyRelationshipDto);
        Task<StudyRelationshipDto> UpdateStudyRelationship(StudyRelationshipDto studyRelationshipDto);
        Task<int> DeleteStudyRelationship(int id);
        Task<int> DeleteAllStudyRelationships(string sdSid);

        // Study titles
        IQueryable<StudyTitle> GetQueryableStudyTitles();
        Task<ICollection<StudyTitleDto>> GetStudyTitles(string sdSid);
        Task<StudyTitleDto> GetStudyTitle(int id);
        Task<StudyTitleDto> CreateStudyTitle(string sdSid, StudyTitleDto studyTitleDto);
        Task<StudyTitleDto> UpdateStudyTitle(StudyTitleDto studyTitleDto);
        Task<int> DeleteStudyTitle(int id);
        Task<int> DeleteAllStudyTitles(string sdSid);

        // Study topics
        IQueryable<StudyTopic> GetQueryableStudyTopics();
        Task<ICollection<StudyTopicDto>> GetStudyTopics(string sdSid);
        Task<StudyTopicDto> GetStudyTopic(int id);
        Task<StudyTopicDto> CreateStudyTopic(string sdSid, StudyTopicDto studyTopicDto);
        Task<StudyTopicDto> UpdateStudyTopic(StudyTopicDto studyTopicDto);
        Task<int> DeleteStudyTopic(int id);
        Task<int> DeleteAllStudyTopics(string sdSid);
    }
}