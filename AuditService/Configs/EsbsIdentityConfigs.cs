namespace AuditService.Configs
{
    public class EsbsIdentityConfigs
    {
        public const string EsbsIdentityServerUrl = "https://localhost:7001";

        public const string EsbsClientId = "the_rms_client";
        public const string EsbsClientSecret = "r6DBdwHD7OsnUq39p7u0ECw877YSfC7A";

        public const string EsbsScope = "openid profile email address mdmAPI rmsAPI userAPI roles";
    }
}