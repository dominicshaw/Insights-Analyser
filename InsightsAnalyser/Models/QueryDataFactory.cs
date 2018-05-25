using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using DevExpress.Mvvm.POCO;

namespace InsightsAnalyser.Models
{
    public class QueryDataFactory
    {
        private readonly string _fileName;

        public QueryDataFactory(string fileName)
        {
            _fileName = fileName;
        }

        public List<QueryData> Get()
        {
            using (var reader = new StringReader(File.ReadAllText(_fileName)))
            {
                var csv = new CsvReader(reader);
                var records = csv.GetRecords<QueryData>().ToList();

                var grouped =
                    from r in records
                    group r by new
                    {
                        r.timestamp,
                        r.name,
                        r.itemType,
                        r.operation_Name,
                        r.operation_Id,
                        r.operation_ParentId,
                        r.operation_SyntheticSource,
                        r.session_Id,
                        r.user_Id,
                        r.user_AuthenticatedId,
                        r.user_AccountId,
                        r.application_Version,
                        r.client_Type,
                        r.client_Model,
                        r.client_OS,
                        r.client_IP,
                        r.client_City,
                        r.client_StateOrProvince,
                        r.client_CountryOrRegion,
                        r.client_Browser,
                        r.cloud_RoleName,
                        r.cloud_RoleInstance,
                        r.appId,
                        r.appName,
                        r.iKey,
                        r.sdkVersion,
                        r.itemCount,
                        r.customMeasurements
                    }
                    into g
                    select new QueryData()
                    {
                        timestamp                 = g.Key.timestamp,
                        name                      = g.Key.name,
                        itemType                  = g.Key.itemType,
                        operation_Name            = g.Key.operation_Name,
                        operation_Id              = g.Key.operation_Id,
                        operation_ParentId        = g.Key.operation_ParentId,
                        operation_SyntheticSource = g.Key.operation_SyntheticSource,
                        session_Id                = g.Key.session_Id,
                        user_Id                   = g.Key.user_Id,
                        user_AuthenticatedId      = g.Key.user_AuthenticatedId,
                        user_AccountId            = g.Key.user_AccountId,
                        application_Version       = g.Key.application_Version,
                        client_Type               = g.Key.client_Type,
                        client_Model              = g.Key.client_Model,
                        client_OS                 = g.Key.client_OS,
                        client_IP                 = g.Key.client_IP,
                        client_City               = g.Key.client_City,
                        client_StateOrProvince    = g.Key.client_StateOrProvince,
                        client_CountryOrRegion    = g.Key.client_CountryOrRegion,
                        client_Browser            = g.Key.client_Browser,
                        cloud_RoleName            = g.Key.cloud_RoleName,
                        cloud_RoleInstance        = g.Key.cloud_RoleInstance,
                        appId                     = g.Key.appId,
                        appName                   = g.Key.appName,
                        iKey                      = g.Key.iKey,
                        sdkVersion                = g.Key.sdkVersion,
                        itemCount                 = g.Key.itemCount,
                        customMeasurements        = g.Key.customMeasurements,
                        customDimensions          = g.Select(x => x.customDimensions).First(),
                        itemId                    = g.Select(x => x.itemId).First()
                    };

                var onesILike = grouped.Where(x => x.itemId == new Guid("c5f6fc65-6023-11e8-a6e7-f10671242c42") || x.itemId == new Guid("cc7e6f09-6023-11e8-949c-8b1239809af7")).ToArray();

                return grouped.ToList();
            }
        }
    }
}