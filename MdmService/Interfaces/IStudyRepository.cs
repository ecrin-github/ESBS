using System.Collections.Generic;
using System.Threading.Tasks;
using MdmService.DTO.Study;

namespace MdmService.Interfaces
{
    public interface IStudyRepository
    {
        // Study
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
        Task<ICollection<StudyContributorDto>> GetStudyContributors(string sdSid);
        Task<StudyContributorDto> GetStudyContributor(int? id);
        Task<StudyContributorDto> CreateStudyContributor(StudyContributorDto studyContributorDto);
        Task<StudyContributorDto> UpdateStudyContributor(StudyContributorDto studyContributorDto);
        Task<int> DeleteStudyContributor(int id);
        Task<int> DeleteAllStudyContributors(string sdSid);

        // Study features
        Task<ICollection<StudyFeatureDto>> GetStudyFeatures(string sdSid);
        Task<StudyFeatureDto> GetStudyFeature(int? id);
        Task<StudyFeatureDto> CreateStudyFeature(StudyFeatureDto studyFeatureDto);
        Task<StudyFeatureDto> UpdateStudyFeature(StudyFeatureDto studyFeatureDto);
        Task<int> DeleteStudyFeature(int id);
        Task<int> DeleteAllStudyFeatures(string sdSid);

        // Study identifiers
        Task<ICollection<StudyIdentifierDto>> GetStudyIdentifiers(string sdSid);
        Task<StudyIdentifierDto> GetStudyIdentifier(int? id);
        Task<StudyIdentifierDto> CreateStudyIdentifier(StudyIdentifierDto studyIdentifierDto);
        Task<StudyIdentifierDto> UpdateStudyIdentifier(StudyIdentifierDto studyIdentifierDto);
        Task<int> DeleteStudyIdentifier(int id);
        Task<int> DeleteAllStudyIdentifiers(string sdSid);

        // Study references
        Task<ICollection<StudyReferenceDto>> GetStudyReferences(string sdSid);
        Task<StudyReferenceDto> GetStudyReference(int? id);
        Task<StudyReferenceDto> CreateStudyReference(StudyReferenceDto studyReferenceDto);
        Task<StudyReferenceDto> UpdateStudyReference(StudyReferenceDto studyReferenceDto);
        Task<int> DeleteStudyReference(int id);
        Task<int> DeleteAllStudyReferences(string sdSid);

        // Study relationships
        Task<ICollection<StudyRelationshipDto>> GetStudyRelationships(string sdSid);
        Task<StudyRelationshipDto> GetStudyRelationship(int? id);
        Task<StudyRelationshipDto> CreateStudyRelationship(StudyRelationshipDto studyRelationshipDto);
        Task<StudyRelationshipDto> UpdateStudyRelationship(StudyRelationshipDto studyRelationshipDto);
        Task<int> DeleteStudyRelationship(int id);
        Task<int> DeleteAllStudyRelationships(string sdSid);

        // Study titles
        Task<ICollection<StudyTitleDto>> GetStudyTitles(string sdSid);
        Task<StudyTitleDto> GetStudyTitle(int? id);
        Task<StudyTitleDto> CreateStudyTitle(StudyTitleDto studyTitleDto);
        Task<StudyTitleDto> UpdateStudyTitle(StudyTitleDto studyTitleDto);
        Task<int> DeleteStudyTitle(int id);
        Task<int> DeleteAllStudyTitles(string sdSid);

        // Study topics
        Task<ICollection<StudyTopicDto>> GetStudyTopics(string sdSid);
        Task<StudyTopicDto> GetStudyTopic(int? id);
        Task<StudyTopicDto> CreateStudyTopic(StudyTopicDto studyTopicDto);
        Task<StudyTopicDto> UpdateStudyTopic(StudyTopicDto studyTopicDto);
        Task<int> DeleteStudyTopic(int id);
        Task<int> DeleteAllStudyTopics(string sdSid);
    }
}