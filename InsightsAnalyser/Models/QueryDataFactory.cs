using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

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
                return csv.GetRecords<QueryData>().ToList();
            }
        }
    }
}