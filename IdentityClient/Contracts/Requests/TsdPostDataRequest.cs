namespace IdentityClient.Contracts.Requests
{
    public class TsdPostDataRequest
    {
        public string ElixirToken { get; set; }
        public ElixirInfo ElixirInfo { get; set; }
        public string DatasetId { get; set; }
    }
}