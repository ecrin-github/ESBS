using System.Net.Http;
using System.Threading.Tasks;
using MdrService.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MdrService.Services
{
    public class ContextService : IContextService
    {
        private static readonly HttpClient Client = new();

        private const string RootContextUrl = "https://api.ecrin-rms.org/context";

        private async Task<string> GetPropertyName(string url)
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
            var url = RootContextUrl + "/size-units/" + id;
            return await GetPropertyName(url);
        }
        
        public async Task<string> GetTimeUnitType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/time-units/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetStudyType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/study-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetStudyStatus(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/study-statuses/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetFeatureType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/study-feature-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetFeatureValue(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/study-feature-categories/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetGenderElig(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/gender-eligibility-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetTitleType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/title-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetTopicType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/topic-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetObjectType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/object-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetObjectClass(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/object-classes/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetAccessType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/object-access-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetDescriptionType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/description-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetIdentifierType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/identifier-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetStudyRelationshipType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/study-relationship-types/" + id;
            return await GetPropertyName(url);
        }
        
        public async Task<string> GetObjectRelationshipType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/object-relationship-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetDateType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/date-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetInstanceType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/object-instance-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetRecordkeyType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/dataset-recordkey-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetDeidentType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/dataset-deidentification-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetConsentType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/dataset-consent-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetResourceType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/resource-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetDoiStatus(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/doi-status-types/" + id;
            return await GetPropertyName(url);
        }

        public async Task<string> GetContributionType(int? id)
        {
            if (id == null) return null;
            var url = RootContextUrl + "/contribution-types/" + id;
            return await GetPropertyName(url);
        }
    }
}