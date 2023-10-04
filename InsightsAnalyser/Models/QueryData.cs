using System;
using CsvHelper.Configuration.Attributes;

namespace InsightsAnalyser.Models
{
    public class QueryData
    {

        [Name("timestamp [UTC]")]
        public DateTime timestamp { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string success { get; set; }
        public string message { get; set; }
        public string size { get; set; }
        public string duration { get; set; }
        public string performanceBucket { get; set; }
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
        public string _ResourceId { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string resultCode { get; set; }
        public string problemId { get; set; }
        public string handledAt { get; set; }
        public string type { get; set; }
        public string assembly { get; set; }
        public string method { get; set; }
        public string outerType { get; set; }
        public string outerMessage { get; set; }
        public string outerAssembly { get; set; }
        public string outerMethod { get; set; }
        public string innermostType { get; set; }
        public string innermostMessage { get; set; }
        public string innermostAssembly { get; set; }
        public string innermostMethod { get; set; }
        public string severityLevel { get; set; }
        public string details { get; set; }
        public string target { get; set; }
        public string data { get; set; }
    }
}