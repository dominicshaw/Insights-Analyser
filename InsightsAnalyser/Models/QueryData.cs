using System;

namespace InsightsAnalyser.Models
{
    public class QueryData
    {
        public DateTime timestamp { get; set; }
        public string name { get; set; }
        public string itemType { get; set; }
        public string customDimensions { get; set; }
        public string customMeasurements { get; set; }
        public string operation_Name { get; set; }
        public Guid operation_Id { get; set; }
        public Guid operation_ParentId { get; set; }
        public string operation_SyntheticSource { get; set; }
        public Guid session_Id { get; set; }
        public Guid user_Id { get; set; }
        public string user_AuthenticatedId { get; set; }
        public string user_AccountId { get; set; }
        public decimal application_Version { get; set; }
        public string client_Type { get; set; }
        public string client_Model { get; set; }
        public string client_OS { get; set; }
        public string client_IP { get; set; }
        public string client_City { get; set; }
        public string client_StateOrProvince { get; set; }
        public string client_CountryOrRegion { get; set; }
        public string client_Browser { get; set; }
        public string cloud_RoleName { get; set; }
        public string cloud_RoleInstance { get; set; }
        public Guid appId { get; set; }
        public string appName { get; set; }
        public Guid iKey { get; set; }
        public string sdkVersion { get; set; }
        public Guid itemId { get; set; }
        public int itemCount { get; set; }
    }
}