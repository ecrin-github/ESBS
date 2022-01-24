using System.Collections.Generic;
using System.Threading.Tasks;
using MdmService.Contracts.Requests.Filtering;
using MdmService.Contracts.Responses;
using MdmService.DTO.Study;

namespace MdmService.Interfaces
{
    public interface IStudyRepository
    {
        // Study
        Task<ICollection<StudyDto>> GetAllStudies();
        Task<StudyDto> GetStudyById(string sdSid);
        Task<StudyDto> CreateStudy(StudyDto studyDto, string accessToken);
        Task<StudyDto> UpdateStudy(StudyDto studyDto, string accessToken);
        Task<int> DeleteStudy(string sdSid);
        
        // Study data
        Task<ICollection<StudyDataDto>> GetStudiesData();
        Task<StudyDataDto> GetStudyData(string sdSid);
        Task<ICollection<StudyDataDto>> GetRecentStudyData(int limit);
        Task<StudyDataDto> CreateStudyData(StudyDataDto studyData, string accessToken);
        Task<StudyDataDto> UpdateStudyData(StudyDataDto studyData, string accessToken);

        // Study contributors
        Task<ICollection<StudyContributorDto>> GetStudyContributors(string sdSid);
        Task<StudyContributorDto> GetStudyContributor(int? id);
        Task<StudyContributorDto> CreateStudyContributor(StudyContributorDto studyContributorDto, string accessToken);
        Task<StudyContributorDto> UpdateStudyContributor(StudyContributorDto studyContributorDto, string accessToken);
        Task<int> DeleteStudyContributor(int id);
        Task<int> DeleteAllStudyContributors(string sdSid);

        // Study features
        Task<ICollection<StudyFeatureDto>> GetStudyFeatures(string sdSid);
        Task<StudyFeatureDto> GetStudyFeature(int? id);
        Task<StudyFeatureDto> CreateStudyFeature(StudyFeatureDto studyFeatureDto, string accessToken);
        Task<StudyFeatureDto> UpdateStudyFeature(StudyFeatureDto studyFeatureDto, string accessToken);
        Task<int> DeleteStudyFeature(int id);
        Task<int> DeleteAllStudyFeatures(string sdSid);

        // Study identifiers
        Task<ICollection<StudyIdentifierDto>> GetStudyIdentifiers(string sdSid);
        Task<StudyIdentifierDto> GetStudyIdentifier(int? id);
        Task<StudyIdentifierDto> CreateStudyIdentifier(StudyIdentifierDto studyIdentifierDto, string accessToken);
        Task<StudyIdentifierDto> UpdateStudyIdentifier(StudyIdentifierDto studyIdentifierDto, string accessToken);
        Task<int> DeleteStudyIdentifier(int id);
        Task<int> DeleteAllStudyIdentifiers(string sdSid);

        // Study references
        Task<ICollection<StudyReferenceDto>> GetStudyReferences(string sdSid);
        Task<StudyReferenceDto> GetStudyReference(int? id);
        Task<StudyReferenceDto> CreateStudyReference(StudyReferenceDto studyReferenceDto, string accessToken);
        Task<StudyReferenceDto> UpdateStudyReference(StudyReferenceDto studyReferenceDto, string accessToken);
        Task<int> DeleteStudyReference(int id);
        Task<int> DeleteAllStudyReferences(string sdSid);

        // Study relationships
        Task<ICollection<StudyRelationshipDto>> GetStudyRelationships(string sdSid);
        Task<StudyRelationshipDto> GetStudyRelationship(int? id);
        Task<StudyRelationshipDto> CreateStudyRelationship(StudyRelationshipDto studyRelationshipDto, string accessToken);
        Task<StudyRelationshipDto> UpdateStudyRelationship(StudyRelationshipDto studyRelationshipDto, string accessToken);
        Task<int> DeleteStudyRelationship(int id);
        Task<int> DeleteAllStudyRelationships(string sdSid);

        // Study titles
        Task<ICollection<StudyTitleDto>> GetStudyTitles(string sdSid);
        Task<StudyTitleDto> GetStudyTitle(int? id);
        Task<StudyTitleDto> CreateStudyTitle(StudyTitleDto studyTitleDto, string accessToken);
        Task<StudyTitleDto> UpdateStudyTitle(StudyTitleDto studyTitleDto, string accessToken);
        Task<int> DeleteStudyTitle(int id);
        Task<int> DeleteAllStudyTitles(string sdSid);

        // Study topics
        Task<ICollection<StudyTopicDto>> GetStudyTopics(string sdSid);
        Task<StudyTopicDto> GetStudyTopic(int? id);
        Task<StudyTopicDto> CreateStudyTopic(StudyTopicDto studyTopicDto, string accessToken);
        Task<StudyTopicDto> UpdateStudyTopic(StudyTopicDto studyTopicDto, string accessToken);
        Task<int> DeleteStudyTopic(int id);
        Task<int> DeleteAllStudyTopics(string sdSid);

        // Extensions
        Task<PaginationResponse<StudyDto>> PaginateStudies(PaginationRequest paginationRequest);
        Task<PaginationResponse<StudyDto>> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest);
        Task<int> GetTotalStudies();
    }
}