using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp1
{
    public static class VNPayFakePayment
    {
        [FunctionName("VNPayFakePayment")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string orderId = data?.orderId;
            string amount = data?.amount;
            string paymentStatus = "success"; // Simulated success status

            var response = new
            {
                orderId = orderId,
                amount = amount,
                status = paymentStatus,
                message = "Payment processed successfully"
            };

            return new OkObjectResult(response);
        }
    }
}
