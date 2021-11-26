using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdrService.Configs;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;
using MdrService.Models.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MdrService.Repositories
{
    public class ObjectRepository : IObjectRepository
    {
        private readonly MdrDbConnection _dbConnection;
        private readonly IDistributedCache _distributedCache;

        public ObjectRepository(
            MdrDbConnection mdrDbConnection,
            IDistributedCache distributedCache)
        {
            _dbConnection = mdrDbConnection ?? throw new ArgumentNullException(nameof(mdrDbConnection));
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
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
            var cacheKey = "objectContributors_" + objectId;

            ObjectContributor[] objectContributors;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectContributors = JsonConvert.DeserializeObject<ObjectContributor[]>(serializedValue);
            }
            else
            {
                objectContributors = await _dbConnection.ObjectContributors.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectContributors);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectContributors;
        }

        public async Task<ObjectDataset> GetObjectDatasets(int objectId)
        {
            var cacheKey = "objectDataset_" + objectId;

            ObjectDataset objectDataset;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectDataset = JsonConvert.DeserializeObject<ObjectDataset>(serializedValue);
            }
            else
            {
                objectDataset = await _dbConnection.ObjectDatasets.FirstOrDefaultAsync(p => p.ObjectId == objectId);                
                serializedValue = JsonConvert.SerializeObject(objectDataset);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectDataset;
        }

        public async Task<ICollection<ObjectDate>> GetObjectDates(int objectId)
        {
            var cacheKey = "objectDates_" + objectId;

            ObjectDate[] objectDates;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectDates = JsonConvert.DeserializeObject<ObjectDate[]>(serializedValue);
            }
            else
            {
                objectDates = await _dbConnection.ObjectDates.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectDates);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectDates;
        }

        public async Task<ICollection<ObjectDescription>> GetObjectDescriptions(int objectId)
        {
            var cacheKey = "objectDescriptions_" + objectId;

            ObjectDescription[] objectDescriptions;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectDescriptions = JsonConvert.DeserializeObject<ObjectDescription[]>(serializedValue);
            }
            else
            {
                objectDescriptions = await _dbConnection.ObjectDescriptions.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectDescriptions);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectDescriptions;
        }

        public async Task<ICollection<ObjectIdentifier>> GetObjectIdentifiers(int objectId)
        {
            var cacheKey = "objectIdentifiers_" + objectId;

            ObjectIdentifier[] objectIdentifiers;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectIdentifiers = JsonConvert.DeserializeObject<ObjectIdentifier[]>(serializedValue);
            }
            else
            {
                objectIdentifiers = await _dbConnection.ObjectIdentifiers.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectIdentifiers);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectIdentifiers;
        }

        public async Task<ICollection<ObjectInstance>> GetObjectInstances(int objectId)
        {
            var cacheKey = "objectInstances_" + objectId;

            ObjectInstance[] objectInstances;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectInstances = JsonConvert.DeserializeObject<ObjectInstance[]>(serializedValue);
            }
            else
            {
                objectInstances = await _dbConnection.ObjectInstances.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectInstances);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectInstances;
        }

        public async Task<ICollection<ObjectRelationship>> GetObjectRelationships(int objectId)
        {
            var cacheKey = "objectRelationships_" + objectId;

            ObjectRelationship[] objectRelationships;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectRelationships = JsonConvert.DeserializeObject<ObjectRelationship[]>(serializedValue);
            }
            else
            {
                objectRelationships = await _dbConnection.ObjectRelationships.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectRelationships);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectRelationships;
        }

        public async Task<ICollection<ObjectRight>> GetObjectRights(int objectId)
        {
            var cacheKey = "objectRights_" + objectId;

            ObjectRight[] objectRights;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectRights = JsonConvert.DeserializeObject<ObjectRight[]>(serializedValue);
            }
            else
            {
                objectRights = await _dbConnection.ObjectRights.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectRights);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectRights;
        }

        public async Task<ICollection<ObjectTitle>> GetObjectTitles(int objectId)
        {
            var cacheKey = "objectTitles_" + objectId;

            ObjectTitle[] objectTitles;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectTitles = JsonConvert.DeserializeObject<ObjectTitle[]>(serializedValue);
            }
            else
            {
                objectTitles = await _dbConnection.ObjectTitles.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectTitles);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectTitles;
        }

        public async Task<ICollection<ObjectTopic>> GetObjectTopics(int objectId)
        {
            var cacheKey = "objectTopics_" + objectId;

            ObjectTopic[] objectTopics;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectTopics = JsonConvert.DeserializeObject<ObjectTopic[]>(serializedValue);
            }
            else
            {
                objectTopics = await _dbConnection.ObjectTopics.Where(p => p.ObjectId == objectId).ToArrayAsync();                
                serializedValue = JsonConvert.SerializeObject(objectTopics);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectTopics;
        }
    }
}