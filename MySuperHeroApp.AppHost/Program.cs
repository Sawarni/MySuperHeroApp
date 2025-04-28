var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MySuperHeroApp_ApiService>("apiservice");

builder.AddProject<Projects.MySuperHeroApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
