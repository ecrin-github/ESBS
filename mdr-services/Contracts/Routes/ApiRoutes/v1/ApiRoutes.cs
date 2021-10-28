namespace mdr_services.Contracts.Routes.ApiRoutes.v1
{
    public static class ApiRoutes
    {
        private const string QueryRoot = "mdr-es/query";
        private const string RawQueryRoot = "mdr-es/raw-query";

        private const string QueryBase = "/" + QueryRoot + "/";
        private const string RawQueryBase = "/" + RawQueryRoot + "/";

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