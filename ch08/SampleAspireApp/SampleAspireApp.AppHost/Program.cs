var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.SampleAspireApp_ApiService>("apiservice");

builder.AddProject<Projects.SampleAspireApp_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();
