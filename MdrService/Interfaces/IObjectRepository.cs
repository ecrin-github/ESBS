using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Models.Object;

namespace MdrService.Interfaces
{
    public interface IObjectRepository
    {
        Task<DataObject> GetDataObjectById(int id);
        Task<ICollection<DataObject>> GetDataObjects(ICollection<int> ids);

        Task<ICollection<ObjectContributor>> GetObjectContributors(int objectId);
        Task<ObjectDataset> GetObjectDatasets(int objectId);
        Task<ICollection<ObjectDate>> GetObjectDates(int objectId);
        Task<ICollection<ObjectDescription>> GetObjectDescriptions(int objectId);
        Task<ICollection<ObjectIdentifier>> GetObjectIdentifiers(int objectId);
        Task<ICollection<ObjectInstance>> GetObjectInstances(int objectId);
        Task<ICollection<ObjectRelationship>> GetObjectRelationships(int objectId);
        Task<ICollection<ObjectRight>> GetObjectRights(int objectId);
        Task<ICollection<ObjectTitle>> GetObjectTitles(int objectId);
        Task<ICollection<ObjectTopic>> GetObjectTopics(int objectId);
    }
}