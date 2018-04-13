using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using InsightsAnalyser.Annotations;
using InsightsAnalyser.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InsightsAnalyser.ViewModels
{
    public class QueryDataViewModel : INotifyPropertyChanged
    {
        private readonly QueryData _model;
        
        public DateTime Timestamp => _model.timestamp;
        public string Name => _model.name;
        public string ItemType => _model.itemType;
        public string CustomMeasurements => _model.customMeasurements;
        public string OperationName => _model.operation_Name;
        public Guid OperationId => _model.operation_Id;
        public Guid OperationParentId => _model.operation_ParentId;
        public string OperationSyntheticSource => _model.operation_SyntheticSource;
        public Guid SessionId => _model.session_Id;
        public Guid UserId => _model.user_Id;
        public string UserAuthenticatedId => _model.user_AuthenticatedId;
        public string UserAccountId => _model.user_AccountId;
        public decimal ApplicationVersion => _model.application_Version;
        public string ClientType => _model.client_Type;
        public string ClientModel => _model.client_Model;
        public string ClientOs => _model.client_OS;
        public string ClientIP => _model.client_IP;
        public string ClientCity => _model.client_City;
        public string ClientStateOrProvince => _model.client_StateOrProvince;
        public string ClientCountryOrRegion => _model.client_CountryOrRegion;
        public string ClientBrowser => _model.client_Browser;
        public string CloudRoleName => _model.cloud_RoleName;
        public string CloudRoleInstance => _model.cloud_RoleInstance;
        public Guid AppId => _model.appId;
        public string AppName => _model.appName;
        public Guid IKey => _model.iKey;
        public string SdkVersion => _model.sdkVersion;
        public Guid ItemId => _model.itemId;
        public int ItemCount => _model.itemCount;
        
        public string CustomDimensions { get; }
        public CustomData CustomDimensionsBreakout { get; }

        public string Properties { get; }
        public string User { get; }

        public QueryDataViewModel(QueryData model)
        {
            _model = model;
            
            CustomDimensionsBreakout = JsonConvert.DeserializeObject<CustomData>(_model.customDimensions);
            CustomDimensions = JsonConvert.SerializeObject(CustomDimensionsBreakout, Formatting.Indented);

            if (string.IsNullOrEmpty(CustomDimensionsBreakout.Properties)) 
                return;

            var props = JsonConvert.DeserializeObject<dynamic>(CustomDimensionsBreakout.Properties);

            Properties = JsonConvert.SerializeObject(props, Formatting.Indented);

            if (props is JObject o && o.ContainsKey("user"))
            {
                User = o["user"].Value<string>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}