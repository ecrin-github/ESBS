using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdrService.Configs;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;


namespace MdrService.Repositories
{
    public class LinksRepository : ILinksRepository
    {
        private readonly MdrDbConnection _dbConnection;
        private readonly IDistributedCache _distributedCache;

        public LinksRepository(
            MdrDbConnection mdrDbConnection,
            IDistributedCache distributedCache)
        {
            _dbConnection = mdrDbConnection ?? throw new ArgumentNullException(nameof(mdrDbConnection));
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }
        
        public async Task<ICollection<int>> GetObjectStudies(int objectId)
        {
            var cacheKey = "objectStudyIds_" + objectId;

            int[] objectStudyIds;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectStudyIds = JsonConvert.DeserializeObject<int[]>(serializedValue);
            }
            else
            {
                objectStudyIds = await _dbConnection.StudyObjectLinks.Where(p => p.ObjectId.Equals(objectId))
                    .Select(p => p.StudyId).ToArrayAsync();
                serializedValue = JsonConvert.SerializeObject(objectStudyIds);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectStudyIds;
        }

        public async Task<ICollection<int>> GetStudyObjects(int studyId)
        {
            var cacheKey = "studyObjectIds_" + studyId;

            int[] studyObjectIds;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyObjectIds = JsonConvert.DeserializeObject<int[]>(serializedValue);
            }
            else
            {
                studyObjectIds = await _dbConnection.StudyObjectLinks.Where(p => p.StudyId.Equals(studyId))
                    .Select(p => p.ObjectId).ToArrayAsync();
                serializedValue = JsonConvert.SerializeObject(studyObjectIds);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyObjectIds;
        }
    }
}