using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdrService.Configs;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;
using MdrService.Models.Study;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MdrService.Repositories
{
    public class StudyRepository : IStudyRepository
    {
        private readonly MdrDbConnection _dbConnection;
        private readonly IDistributedCache _distributedCache;

        public StudyRepository(
            MdrDbConnection mdrDbConnection,
            IDistributedCache distributedCache)
        {
            _dbConnection = mdrDbConnection ?? throw new ArgumentNullException(nameof(mdrDbConnection));
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }
        
        public async Task<Study> GetStudyById(int? id)
        {
            if (id == null) return null;
            return await _dbConnection.Studies.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Study>> GetStudies(ICollection<int> ids)
        {
            return await _dbConnection.Studies.AsNoTracking().Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public async Task<ICollection<StudyContributor>> GetStudyContributors(int studyId)
        {
            var cacheKey = "studyContributors_" + studyId;

            StudyContributor[] studyContributors;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyContributors = JsonConvert.DeserializeObject<StudyContributor[]>(serializedValue);
            }
            else
            {
                studyContributors = await _dbConnection.StudyContributors.AsNoTracking()
                    .Where(p => p.StudyId == studyId).ToArrayAsync();
                serializedValue = JsonConvert.SerializeObject(studyContributors);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyContributors;
        }

        public async Task<ICollection<StudyFeature>> GetStudyFeatures(int studyId)
        {
            var cacheKey = "studyFeatures_" + studyId;

            StudyFeature[] studyFeatures;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyFeatures = JsonConvert.DeserializeObject<StudyFeature[]>(serializedValue);
            }
            else
            {
                studyFeatures = await _dbConnection.StudyFeatures.AsNoTracking()
                    .Where(p => p.StudyId == studyId).ToArrayAsync();
                serializedValue = JsonConvert.SerializeObject(studyFeatures);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyFeatures;
        }

        public async Task<ICollection<StudyIdentifier>> GetStudyIdentifiers(int studyId)
        {
            var cacheKey = "studyIdentifiers_" + studyId;

            StudyIdentifier[] studyIdentifiers;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyIdentifiers = JsonConvert.DeserializeObject<StudyIdentifier[]>(serializedValue);
            }
            else
            {
                studyIdentifiers = await _dbConnection.StudyIdentifiers.AsNoTracking()
                    .Where(p => p.StudyId == studyId).ToArrayAsync();
                serializedValue = JsonConvert.SerializeObject(studyIdentifiers);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyIdentifiers;
        }

        public async Task<ICollection<StudyRelationship>> GetStudyRelationships(int studyId)
        {
            var cacheKey = "studyRelationships_" + studyId;
            
            StudyRelationship[] studyRelationships;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyRelationships = JsonConvert.DeserializeObject<StudyRelationship[]>(serializedValue);
            }
            else
            {
                studyRelationships = await _dbConnection.StudyRelationships.AsNoTracking()
                    .Where(p => p.StudyId == studyId).ToArrayAsync();
                serializedValue = JsonConvert.SerializeObject(studyRelationships);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyRelationships;
        }

        public async Task<ICollection<StudyTitle>> GetStudyTitles(int studyId)
        {
            var cacheKey = "studyTitles_" + studyId;

            StudyTitle[] studyTitles;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyTitles = JsonConvert.DeserializeObject<StudyTitle[]>(serializedValue);
            }
            else
            {
                studyTitles = await _dbConnection.StudyTitles.AsNoTracking()
                    .Where(p => p.StudyId == studyId).ToArrayAsync();
                serializedValue = JsonConvert.SerializeObject(studyTitles);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyTitles;
        }

        public async Task<ICollection<StudyTopic>> GetStudyTopics(int studyId)
        {
            var cacheKey = "studyTopics_" + studyId;

            StudyTopic[] studyTopics;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyTopics = JsonConvert.DeserializeObject<StudyTopic[]>(serializedValue);
            }
            else
            {
                studyTopics = await _dbConnection.StudyTopics.AsNoTracking()
                    .Where(p => p.StudyId == studyId).ToArrayAsync();
                serializedValue = JsonConvert.SerializeObject(studyTopics);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyTopics;
        }
    }
}