namespace MdrService.Contracts.Routes.ApiRoutes.v1
{
    public static class ApiRoutes
    {
        private const string QueryRoot = "/api";

        private const string QueryVersion = "/v1";

        private const string QueryPath = "/search";
        private const string RawSqlQueryPath = "/raw-sql-search";
        
        private const string QueryBase = QueryRoot + QueryVersion + QueryPath;
        private const string RawSqlQueryBase = QueryRoot + QueryVersion + RawSqlQueryPath;
        
        public static class Query
        {
            public const string GetSpecificStudy = QueryBase + "/specific-study";

            public const string GetByStudyCharacteristics = QueryBase + "/study-characteristics";
            
            public const string GetViaPublishedPaper = QueryBase + "/via-published-paper";
            
            public const string GetByStudyId = QueryBase + "/study-id";
        }
        
        public static class RawSqlQuery
        {
            public const string GetSpecificStudy = RawSqlQueryBase + "/specific-study";

            public const string GetByStudyCharacteristics = RawSqlQueryBase + "/study-characteristics";
            
            public const string GetViaPublishedPaper = RawSqlQueryBase + "/via-published-paper";
        }
    }
}