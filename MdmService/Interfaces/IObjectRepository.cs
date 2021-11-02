using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdmService.DTO.Object;
using MdmService.Models.Object;

namespace MdmService.Interfaces
{
    public interface IObjectRepository
    {
        // Data objects
        IQueryable<DataObject> GetQueryableDataObjects();
        Task<ICollection<DataObjectDto>> GetAllDataObjects();
        Task<DataObjectDto> GetObjectById(string sdOid);
        Task<DataObjectDto> CreateDataObject(DataObjectDto dataObjectDto);
        Task<DataObjectDto> UpdateDataObject(DataObjectDto dataObjectDto);
        Task<int> DeleteDataObject(string sdOid);
        
        //Data objects data
        Task<ICollection<DataObjectDataDto>> GetDataObjectsData();
        Task<DataObjectDataDto> GetDataObjectData(string sdOid);
        Task<ICollection<DataObjectDataDto>> GetRecentObjectData(int limit);
        Task<DataObjectDataDto> CreateDataObjectData(DataObjectDataDto dataObjectData);
        Task<DataObjectDataDto> UpdateDataObjectData(DataObjectDataDto dataObjectData);

        // Object contributors
        IQueryable<ObjectContributor> GetQueryableObjectContributors();
        Task<ICollection<ObjectContributorDto>> GetObjectContributors(string sdOid);
        Task<ObjectContributorDto> GetObjectContributor(int id);
        Task<ObjectContributorDto> CreateObjectContributor(string sdOid, ObjectContributorDto objectContributorDto);
        Task<ObjectContributorDto> UpdateObjectContributor(ObjectContributorDto objectContributorDto);
        Task<int> DeleteObjectContributor(int id);
        Task<int> DeleteAllObjectContributors(string sdOid);

        // Object datasets
        IQueryable<ObjectDataset> GetQueryableObjectDatasets();
        Task<ICollection<ObjectDatasetDto>> GetObjectDatasets(string sdOid);
        Task<ObjectDatasetDto> GetObjectDataset(int id);
        Task<ObjectDatasetDto> CreateObjectDataset(string sdOid, ObjectDatasetDto objectDatasetDto);
        Task<ObjectDatasetDto> UpdateObjectDataset(ObjectDatasetDto objectDatasetDto);
        Task<int> DeleteObjectDataset(int id);
        Task<int> DeleteAllObjectDatasets(string sdOid);

        // Object dates
        IQueryable<ObjectDate> GetQueryableObjectDates();
        Task<ICollection<ObjectDateDto>> GetObjectDates(string sdOid);
        Task<ObjectDateDto> GetObjectDate(int id);
        Task<ObjectDateDto> CreateObjectDate(string sdOid, ObjectDateDto objectDateDto);
        Task<ObjectDateDto> UpdateObjectDate(ObjectDateDto objectDateDto);
        Task<int> DeleteObjectDate(int id);
        Task<int> DeleteAllObjectDates(string sdOid);

        // Object descriptions
        IQueryable<ObjectDescription> GetQueryableObjectDescriptions();
        Task<ICollection<ObjectDescriptionDto>> GetObjectDescriptions(string sdOid);
        Task<ObjectDescriptionDto> GetObjectDescription(int id);
        Task<ObjectDescriptionDto> CreateObjectDescription(string sdOid, ObjectDescriptionDto objectDescriptionDto);
        Task<ObjectDescriptionDto> UpdateObjectDescription(ObjectDescriptionDto objectDescriptionDto);
        Task<int> DeleteObjectDescription(int id);
        Task<int> DeleteAllObjectDescriptions(string sdOid);

        // Object identifiers
        IQueryable<ObjectIdentifier> GetQueryableObjectIdentifiers();
        Task<ICollection<ObjectIdentifierDto>> GetObjectIdentifiers(string sdOid);
        Task<ObjectIdentifierDto> GetObjectIdentifier(int id);
        Task<ObjectIdentifierDto> CreateObjectIdentifier(string sdOid, ObjectIdentifierDto objectIdentifierDto);
        Task<ObjectIdentifierDto> UpdateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto);
        Task<int> DeleteObjectIdentifier(int id);
        Task<int> DeleteAllObjectIdentifiers(string sdOid);

        // Object instances
        IQueryable<ObjectInstance> GetQueryableObjectInstances();
        Task<ICollection<ObjectInstanceDto>> GetObjectInstances(string sdOid);
        Task<ObjectInstanceDto> GetObjectInstance(int id);
        Task<ObjectInstanceDto> CreateObjectInstance(string sdOid, ObjectInstanceDto objectInstanceDto);
        Task<ObjectInstanceDto> UpdateObjectInstance(ObjectInstanceDto objectInstanceDto);
        Task<int> DeleteObjectInstance(int id);
        Task<int> DeleteAllObjectInstances(string sdOid);

        // Object relationships
        IQueryable<ObjectRelationship> GetQueryableObjectRelationships();
        Task<ICollection<ObjectRelationshipDto>> GetObjectRelationships(string sdOid);
        Task<ObjectRelationshipDto> GetObjectRelationship(int id);
        Task<ObjectRelationshipDto> CreateObjectRelationship(string sdOid, ObjectRelationshipDto objectRelationshipDto);
        Task<ObjectRelationshipDto> UpdateObjectRelationship(ObjectRelationshipDto objectRelationshipDto);
        Task<int> DeleteObjectRelationship(int id);
        Task<int> DeleteAllObjectRelationships(string sdOid);

        // Object rights
        IQueryable<ObjectRight> GetQueryableObjectRights();
        Task<ICollection<ObjectRightDto>> GetObjectRights(string sdOid);
        Task<ObjectRightDto> GetObjectRight(int id);
        Task<ObjectRightDto> CreateObjectRight(string sdOid, ObjectRightDto objectRightDto);
        Task<ObjectRightDto> UpdateObjectRight(ObjectRightDto objectRightDto);
        Task<int> DeleteObjectRight(int id);
        Task<int> DeleteAllObjectRights(string sdOid);

        // Object titles
        IQueryable<ObjectTitle> GetQueryableObjectTitles();
        Task<ICollection<ObjectTitleDto>> GetObjectTitles(string sdOid);
        Task<ObjectTitleDto> GetObjectTitle(int id);
        Task<ObjectTitleDto> CreateObjectTitle(string sdOid, ObjectTitleDto objectTitleDto);
        Task<ObjectTitleDto> UpdateObjectTitle(ObjectTitleDto objectTitleDto);
        Task<int> DeleteObjectTitle(int id);
        Task<int> DeleteAllObjectTitles(string sdOid);
        

        // Object topics
        IQueryable<ObjectTopic> GetQueryableObjectTopic();
        Task<ICollection<ObjectTopicDto>> GetObjectTopics(string sdOid);
        Task<ObjectTopicDto> GetObjectTopic(int id);
        Task<ObjectTopicDto> CreateObjectTopic(string sdOid, ObjectTopicDto objectTopicDto);
        Task<ObjectTopicDto> UpdateObjectTopic(ObjectTopicDto objectTopicDto);
        Task<int> DeleteObjectTopic(int id);
        Task<int> DeleteAllObjectTopics(string sdOid);
    }
}