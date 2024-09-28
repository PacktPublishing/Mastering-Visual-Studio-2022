using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using SampleML_AzureFunction;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SampleML_AzureFunction;
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddPredictionEnginePool<SampleML.ModelInput, SampleML.ModelOutput>()
    .FromFile("SampleML.mlnet");
    }
}
