var builder = DistributedApplication.CreateBuilder(args);

//var ollama = builder.AddOllama("ollama").WithDataVolume().WithOpenWebUI();
//var phi3_mini = ollama.AddModel("phi3:mini");  

var apiService = builder.AddProject<Projects.MySuperHeroApp_ApiService>("apiservice");

builder.AddProject<Projects.MySuperHeroApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
