using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MdrService.Configs;
using MdrService.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MdrService.Services
{
    public class ContextService : IContextService
    {
        private static readonly HttpClient Client = new();
        private readonly IDistributedCache _distributedCache;

        private const string RootContextUrl = "https://api.ecrin-rms.org/context";

        public ContextService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        private static async Task<string> GetPropertyName(string url)
        {
            var res = await Client.GetAsync(url);
            using var content = res.Content;
            var result = await content.ReadAsStringAsync();
            var root = (JObject)JsonConvert.DeserializeObject<object>(result);
            var statusCode = root["statusCode"].ToString();
            return statusCode != "200" ? null : root["data"][0]["name"].ToString();
        }

        public async Task<string> GetSizeUnitType(int? id)
        {
            if (id == null) return null;

            var cacheKey = "sizeUnit_" + id;

            string sizeUnit;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                sizeUnit = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/size-units/" + id;
                sizeUnit = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(sizeUnit);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return sizeUnit;
        }
        
        public async Task<string> GetTimeUnitType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "timeUnit_" + id;

            string timeUnit;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                timeUnit = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/time-units/" + id;
                timeUnit = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(timeUnit);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return timeUnit;
        }

        public async Task<string> GetStudyType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "studyType_" + id;

            string studyType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/study-types/" + id;
                studyType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(studyType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyType;
        }

        public async Task<string> GetStudyStatus(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "studyStatus_" + id;

            string studyStatus;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyStatus = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/study-statuses/" + id;
                studyStatus = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(studyStatus);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyStatus;
        }

        public async Task<string> GetFeatureType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "featureType_" + id;

            string featureType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                featureType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/study-feature-types/" + id;
                featureType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(featureType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return featureType;
        }

        public async Task<string> GetFeatureValue(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "featureValue_" + id;

            string featureValue;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                featureValue = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/study-feature-categories/" + id;
                featureValue = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(featureValue);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return featureValue;
        }

        public async Task<string> GetGenderElig(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "genderElig_" + id;

            string genderElig;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                genderElig = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/gender-eligibility-types/" + id;
                genderElig = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(genderElig);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return genderElig;
        }

        public async Task<string> GetTitleType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "titleType_" + id;

            string titleType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                titleType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/title-types/" + id;
                titleType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(titleType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return titleType;
        }

        public async Task<string> GetTopicType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "topicType_" + id;

            string topicType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                topicType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/topic-types/" + id;
                topicType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(topicType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return topicType;
        }

        public async Task<string> GetObjectType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "objectType_" + id;

            string objectType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/object-types/" + id;
                objectType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(objectType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectType;
        }

        public async Task<string> GetObjectClass(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "objectClass_" + id;

            string objectClass;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectClass = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/object-classes/" + id;
                objectClass = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(objectClass);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectClass;
        }

        public async Task<string> GetAccessType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "accessType_" + id;

            string accessType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                accessType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/object-access-types/" + id;
                accessType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(accessType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return accessType;
        }

        public async Task<string> GetDescriptionType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "descriptionType_" + id;

            string descriptionType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                descriptionType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/description-types/" + id;
                descriptionType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(descriptionType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return descriptionType;
        }

        public async Task<string> GetIdentifierType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "identifierType_" + id;

            string identifierType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                identifierType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/identifier-types/" + id;
                identifierType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(identifierType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return identifierType;
        }

        public async Task<string> GetStudyRelationshipType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "studyRelType_" + id;

            string studyRelType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyRelType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/study-relationship-types/" + id;
                studyRelType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(studyRelType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return studyRelType;
        }
        
        public async Task<string> GetObjectRelationshipType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "objectRelType_" + id;

            string objectRelType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectRelType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/object-relationship-types/" + id;
                objectRelType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(objectRelType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return objectRelType;
        }

        public async Task<string> GetDateType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "dateType_" + id;

            string dateType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                dateType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/date-types/" + id;
                dateType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(dateType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return dateType;
        }

        public async Task<string> GetInstanceType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "instanceType_" + id;

            string instanceType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                instanceType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/object-instance-types/" + id;
                instanceType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(instanceType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return instanceType;
        }

        public async Task<string> GetRecordkeyType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "rkType_" + id;

            string rkType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                rkType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/dataset-recordkey-types/" + id;
                rkType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(rkType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return rkType;
        }

        public async Task<string> GetDeidentType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "deidentType_" + id;

            string deidentType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                deidentType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/dataset-deidentification-types/" + id;
                deidentType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(deidentType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return deidentType;
        }

        public async Task<string> GetConsentType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "consentType_" + id;

            string consentType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                consentType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/dataset-consent-types/" + id;
                consentType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(consentType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return consentType;
        }

        public async Task<string> GetResourceType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "resourceType_" + id;

            string resourceType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                resourceType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/resource-types/" + id;
                resourceType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(resourceType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return resourceType;
        }

        public async Task<string> GetDoiStatus(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "doiStatus_" + id;

            string doiStatus;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                doiStatus = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/doi-status-types/" + id;
                doiStatus = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(doiStatus);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return doiStatus;
        }

        public async Task<string> GetContributionType(int? id)
        {
            if (id == null) return null;
            
            var cacheKey = "contribType_" + id;

            string contribType;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                contribType = JsonConvert.DeserializeObject<string>(serializedValue);
            }
            else
            {
                var url = RootContextUrl + "/contribution-types/" + id;
                contribType = await GetPropertyName(url);
                serializedValue = JsonConvert.SerializeObject(contribType);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationContext))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationContext));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }
            return contribType;
        }
    }
}