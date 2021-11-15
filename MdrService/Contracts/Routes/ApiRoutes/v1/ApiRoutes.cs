namespace MdrService.Contracts.Routes.ApiRoutes.v1
{
    public static class ApiRoutes
    {
        private const string QueryRoot = "/es";

        private const string QueryVersion = "/v1";

        private const string QueryPath = "/query";
        
        private const string QueryBase = QueryRoot + QueryVersion + QueryPath;

        public static class Query
        {
            public const string GetSpecificStudy = QueryBase + "/specific-study";

            public const string GetByStudyCharacteristics = QueryBase + "/study-characteristics";
            
            public const string GetViaPublishedPaper = QueryBase + "/via-published-paper";
            
            public const string GetByStudyId = QueryBase + "/study-id";
        }
    }
}