using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSPM
{
    public sealed class ConnectionManager
    {
        private static DynamoDBContext _context;
        public static DynamoDBContext Context
        {
            get { return _context; }
        }
        public static async void StartConnection()
        {
            var logginConfig = AWSConfigs.LoggingConfig;
            logginConfig.LogMetrics = true;
            logginConfig.LogResponses = ResponseLoggingOption.Always;
            logginConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
            logginConfig.LogTo = LoggingOptions.SystemDiagnostics;

            AWSConfigs.AWSRegion = "us-east-2";
            CognitoAWSCredentials credenciales = new CognitoAWSCredentials("us-east-2:0e4856d6-54a2-49aa-b7f9-8c5e87bbd5d9", RegionEndpoint.USEast2);
            var client = new AmazonDynamoDBClient(credenciales, RegionEndpoint.USEast2);
            _context = new DynamoDBContext(client);
        }
    }
}
