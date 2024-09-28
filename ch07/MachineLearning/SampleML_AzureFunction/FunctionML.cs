using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.ML;

namespace SampleML_AzureFunction
{
    public class FunctionML
    {
        private PredictionEnginePool<SampleML.ModelInput, SampleML.ModelOutput> _predictionEnginePool;

        public FunctionML(PredictionEnginePool<SampleML.ModelInput,
                SampleML.ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [FunctionName("FunctionML")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            SampleML.ModelInput input = JsonConvert.DeserializeObject<SampleML.ModelInput>(requestBody);

            SampleML.ModelOutput responseMessage = await Task.FromResult(_predictionEnginePool.Predict(input));

            return new OkObjectResult(responseMessage);
        }
    }
}
