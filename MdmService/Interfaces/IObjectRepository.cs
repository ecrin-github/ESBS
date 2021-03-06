using System.Collections.Generic;
using System.Threading.Tasks;
using MdmService.Contracts.Requests.Filtering;
using MdmService.Contracts.Responses;
using MdmService.DTO.Object;

namespace MdmService.Interfaces
{
    public interface IObjectRepository
    {
        // Data objects
        Task<ICollection<DataObjectDto>> GetAllDataObjects();
        Task<DataObjectDto> GetObjectById(string sdOid);
        Task<DataObjectDto> CreateDataObject(DataObjectDto dataObjectDto, string accessToken);
        Task<DataObjectDto> UpdateDataObject(DataObjectDto dataObjectDto, string accessToken);
        Task<int> DeleteDataObject(string sdOid);
        
        //Data objects data
        Task<ICollection<DataObjectDataDto>> GetDataObjectsData();
        Task<DataObjectDataDto> GetDataObjectData(string sdOid);
        Task<ICollection<DataObjectDataDto>> GetRecentObjectData(int limit);
        Task<DataObjectDataDto> CreateDataObjectData(DataObjectDataDto dataObjectData, string accessToken);
        Task<DataObjectDataDto> UpdateDataObjectData(DataObjectDataDto dataObjectData, string accessToken);

        // Object contributors
        Task<ICollection<ObjectContributorDto>> GetObjectContributors(string sdOid);
        Task<ObjectContributorDto> GetObjectContributor(int? id);
        Task<ObjectContributorDto> CreateObjectContributor(ObjectContributorDto objectContributorDto, string accessToken);
        Task<ObjectContributorDto> UpdateObjectContributor(ObjectContributorDto objectContributorDto, string accessToken);
        Task<int> DeleteObjectContributor(int id);
        Task<int> DeleteAllObjectContributors(string sdOid);

        // Object datasets
        Task<ObjectDatasetDto> GetObjectDatasets(string sdOid);
        Task<ObjectDatasetDto> GetObjectDataset(int? id);
        Task<ObjectDatasetDto> CreateObjectDataset(ObjectDatasetDto objectDatasetDto, string accessToken);
        Task<ObjectDatasetDto> UpdateObjectDataset(ObjectDatasetDto objectDatasetDto, string accessToken);
        Task<int> DeleteObjectDataset(int id);
        Task<int> DeleteAllObjectDatasets(string sdOid);

        // Object dates
        Task<ICollection<ObjectDateDto>> GetObjectDates(string sdOid);
        Task<ObjectDateDto> GetObjectDate(int? id);
        Task<ObjectDateDto> CreateObjectDate(ObjectDateDto objectDateDto, string accessToken);
        Task<ObjectDateDto> UpdateObjectDate(ObjectDateDto objectDateDto, string accessToken);
        Task<int> DeleteObjectDate(int id);
        Task<int> DeleteAllObjectDates(string sdOid);

        // Object descriptions
        Task<ICollection<ObjectDescriptionDto>> GetObjectDescriptions(string sdOid);
        Task<ObjectDescriptionDto> GetObjectDescription(int? id);
        Task<ObjectDescriptionDto> CreateObjectDescription(ObjectDescriptionDto objectDescriptionDto, string accessToken);
        Task<ObjectDescriptionDto> UpdateObjectDescription(ObjectDescriptionDto objectDescriptionDto, string accessToken);
        Task<int> DeleteObjectDescription(int id);
        Task<int> DeleteAllObjectDescriptions(string sdOid);

        // Object identifiers
        Task<ICollection<ObjectIdentifierDto>> GetObjectIdentifiers(string sdOid);
        Task<ObjectIdentifierDto> GetObjectIdentifier(int? id);
        Task<ObjectIdentifierDto> CreateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto, string accessToken);
        Task<ObjectIdentifierDto> UpdateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto, string accessToken);
        Task<int> DeleteObjectIdentifier(int id);
        Task<int> DeleteAllObjectIdentifiers(string sdOid);

        // Object instances
        Task<ICollection<ObjectInstanceDto>> GetObjectInstances(string sdOid);
        Task<ObjectInstanceDto> GetObjectInstance(int? id);
        Task<ObjectInstanceDto> CreateObjectInstance(ObjectInstanceDto objectInstanceDto, string accessToken);
        Task<ObjectInstanceDto> UpdateObjectInstance(ObjectInstanceDto objectInstanceDto, string accessToken);
        Task<int> DeleteObjectInstance(int id);
        Task<int> DeleteAllObjectInstances(string sdOid);

        // Object relationships
        Task<ICollection<ObjectRelationshipDto>> GetObjectRelationships(string sdOid);
        Task<ObjectRelationshipDto> GetObjectRelationship(int? id);
        Task<ObjectRelationshipDto> CreateObjectRelationship(ObjectRelationshipDto objectRelationshipDto, string accessToken);
        Task<ObjectRelationshipDto> UpdateObjectRelationship(ObjectRelationshipDto objectRelationshipDto, string accessToken);
        Task<int> DeleteObjectRelationship(int id);
        Task<int> DeleteAllObjectRelationships(string sdOid);

        // Object rights
        Task<ICollection<ObjectRightDto>> GetObjectRights(string sdOid);
        Task<ObjectRightDto> GetObjectRight(int? id);
        Task<ObjectRightDto> CreateObjectRight(ObjectRightDto objectRightDto, string accessToken);
        Task<ObjectRightDto> UpdateObjectRight(ObjectRightDto objectRightDto, string accessToken);
        Task<int> DeleteObjectRight(int id);
        Task<int> DeleteAllObjectRights(string sdOid);

        // Object titles
        Task<ICollection<ObjectTitleDto>> GetObjectTitles(string sdOid);
        Task<ObjectTitleDto> GetObjectTitle(int? id);
        Task<ObjectTitleDto> CreateObjectTitle(ObjectTitleDto objectTitleDto, string accessToken);
        Task<ObjectTitleDto> UpdateObjectTitle(ObjectTitleDto objectTitleDto, string accessToken);
        Task<int> DeleteObjectTitle(int id);
        Task<int> DeleteAllObjectTitles(string sdOid);
        

        // Object topics
        Task<ICollection<ObjectTopicDto>> GetObjectTopics(string sdOid);
        Task<ObjectTopicDto> GetObjectTopic(int? id);
        Task<ObjectTopicDto> CreateObjectTopic(ObjectTopicDto objectTopicDto, string accessToken);
        Task<ObjectTopicDto> UpdateObjectTopic(ObjectTopicDto objectTopicDto, string accessToken);
        Task<int> DeleteObjectTopic(int id);
        Task<int> DeleteAllObjectTopics(string sdOid);

        // Extensions
        Task<PaginationResponse<DataObjectDto>> PaginateDataObjects(PaginationRequest paginationRequest);
        Task<PaginationResponse<DataObjectDto>> FilterDataObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest);
        Task<int> GetTotalDataObjects();
    }
}