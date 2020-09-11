using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionAZ204_Blob
{
    public static class QueueAndBlob
    {
        [FunctionName("QueueAndBlob")]
        public static void Run([QueueTrigger("myqueue-test", Connection = "AzureWebJobsStorage")]string myQueueItem,
            [Blob("samples-workitems/{QueueTrigger}", FileAccess.Read, Connection = "AzureWebJobsStorage")] Stream myBlob,
            ILogger log)
        {
            log.LogInformation($" Blob Trigger file name: {myBlob}");
            StreamReader reader = new StreamReader(myBlob);

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem} /n {reader.ReadToEnd()}");
        }
    }
}
