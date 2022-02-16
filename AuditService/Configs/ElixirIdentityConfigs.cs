namespace AuditService.Configs
{
    public class ElixirIdentityConfigs
    {
        public const string OidcUrl = "https://login.elixir-czech.org/oidc/";
        public const string AuthorizeUrl = "https://login.elixir-czech.org/oidc/authorize";
        public const string TokenUrl = "https://login.elixir-czech.org/oidc/token";
        public const string UserInfoUrl = "https://login.elixir-czech.org/oidc/userinfo";
        
        public const string ClientId = "5262a0e9-a72c-4854-b23d-6cf31be724ce";
        public const string ClientSecret = "e7cb1a82-e36c-469b-ac67-436299ed15a6c6c78061-4e4e-49f9-854c-f9c7857cb46a";

        public const string SecondClientId = "4a67e332-44fd-4513-b790-b80155bd0b65";
        
        public const string Scope = "openid profile email address phone " +
                                    "offline_access perun_api country " +
                                    "schac_home_organization " +
                                    "eduperson_scoped_affiliation " +
                                    "eduperson_entitlement " +
                                    "eduperson_entitlement_extended " +
                                    "eduperson_orcid";
        
        public const string LocalRedirectUrlToIdentityCallback = "http://localhost:5050/elixir/callback";
        public const string LocalRedirectUrlToIdentityCallbackApiGateway = "http://localhost:5000/identity/elixir/callback";
        public const string LocalRedirectUrlToRmsPortal = "https://ecrin-rms.org";
        
        public const string RedirectUrlToIdentityCallback = "https://identity.ecrin-rms.org/elixir/callback";
        public const string RedirectUrlToIdentityCallbackApiGateway = "https://api.ecrin-rms.org/identity/elixir/callback";
        public const string RedirectUrlToRmsPortal = "https://ecrin-rms.org";
        
        public const string Code = "code";

        public const string GrantType = "authorization_code";
    }
}