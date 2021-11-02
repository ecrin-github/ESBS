namespace MdrService.Contracts.Routes.ApiRoutes.v1
{
    public static class ApiRoutes
    {
        private const string QueryRoot = "/es/query";
        private const string RawQueryRoot = "/es/raw-query";

        private const string QueryVersion = "v1";
        private const string RawQueryVersion = "v1";
        
        private const string QueryBase = QueryRoot + "/" + QueryVersion;
        private const string RawQueryBase = RawQueryRoot + "/" + RawQueryVersion;

        public static class Query
        {
            public const string GetSpecificStudy = QueryBase + "/specific-study";

            public const string GetByStudyCharacteristics = QueryBase + "/study-characteristics";
            
            public const string GetViaPublishedPaper = QueryBase + "/via-published-paper";
            
            public const string GetByStudyId = QueryBase + "/study-id";
        }

        public static class RawQuery
        {
            public const string GetStudySearchResults = RawQueryBase + "/study";
            
            public const string GetObjectSearchResults = RawQueryBase + "/object";
        }
    }
}