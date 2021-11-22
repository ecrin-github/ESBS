using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;
using MdrService.Models.Object;
using Microsoft.EntityFrameworkCore;

namespace MdrService.Repositories
{
    public class ObjectRepository : IObjectRepository
    {
        private readonly MdrDbConnection _dbConnection;

        public ObjectRepository(MdrDbConnection mdrDbConnection)
        {
            _dbConnection = mdrDbConnection;
        }
        
        public async Task<DataObject> GetDataObjectById(int id)
        {
            return await _dbConnection.DataObjects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DataObject>> GetDataObjects(ICollection<int> ids)
        {
            return await _dbConnection.DataObjects.Where(p => ids.Contains(p.Id)).ToArrayAsync();
        }

        public async Task<ICollection<ObjectContributor>> GetObjectContributors(int objectId)
        {
            return await _dbConnection.ObjectContributors.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }

        public async Task<ObjectDataset> GetObjectDatasets(int objectId)
        {
            return await _dbConnection.ObjectDatasets.FirstOrDefaultAsync(p => p.ObjectId == objectId);
        }

        public async Task<ICollection<ObjectDate>> GetObjectDates(int objectId)
        {
            return await _dbConnection.ObjectDates.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }

        public async Task<ICollection<ObjectDescription>> GetObjectDescriptions(int objectId)
        {
            return await _dbConnection.ObjectDescriptions.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }

        public async Task<ICollection<ObjectIdentifier>> GetObjectIdentifiers(int objectId)
        {
            return await _dbConnection.ObjectIdentifiers.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }

        public async Task<ICollection<ObjectInstance>> GetObjectInstances(int objectId)
        {
            return await _dbConnection.ObjectInstances.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }

        public async Task<ICollection<ObjectRelationship>> GetObjectRelationships(int objectId)
        {
            return await _dbConnection.ObjectRelationships.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }

        public async Task<ICollection<ObjectRight>> GetObjectRights(int objectId)
        {
            return await _dbConnection.ObjectRights.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }

        public async Task<ICollection<ObjectTitle>> GetObjectTitles(int objectId)
        {
            return await _dbConnection.ObjectTitles.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }

        public async Task<ICollection<ObjectTopic>> GetObjectTopics(int objectId)
        {
            return await _dbConnection.ObjectTopics.Where(p => p.ObjectId == objectId).ToArrayAsync();
        }
    }
}