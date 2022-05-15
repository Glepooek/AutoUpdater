using GeneralUpdate.AspNetCore.Hubs;
using GeneralUpdate.AspNetCore.Services;
using GeneralUpdate.Core.DTOs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUpdateService, GeneralUpdateService>();
builder.Services.AddSignalR();
var app = builder.Build();

//app.MapHub<VersionHub>("/versionhub");

//app.Use(async (context, next) =>
//{
//    var hubContext = context.RequestServices.GetRequiredService<IHubContext<VersionHub>>();
//    await CommonHubContextMethod((IHubContext)hubContext);
//    if (next != null)
//    {
//        await next.Invoke();
//    }
//});

//async Task CommonHubContextMethod(IHubContext context)
//{
//    await context.Clients.All.SendAsync("clientMethod","");
//}

app.MapGet("/versions/{clientType}/{clientVersion}/{clientAppKey}", async (int clientType, string clientVersion, string clientAppKey, IUpdateService updateService) =>
{
    //TODO: Link database query appSecretKey.
    var appSecretKey = "41A54379-C7D6-4920-8768-21A3468572E5";
    return await updateService.UpdateVersionsTaskAsync(clientType, clientVersion, clientAppKey, appSecretKey, UpdateVersions);
});

app.MapGet("/validate/{clientType}/{clientVersion}/{clientAppKey}", async (int clientType, string clientVersion,string clientAppKey, IUpdateService updateService) =>
{
    //TODO: Link database query appSecretKey.
    var appSecretKey = "41A54379-C7D6-4920-8768-21A3468572E5";
    return await updateService.UpdateValidateTaskAsync(clientType, clientVersion, clientAppKey, appSecretKey, GetLastVersion(), true, GetValidateInfos);
});
app.Run();

async Task<List<UpdateVersionDTO>> UpdateVersions(int clientType, string clientVersion)
{
    //TODO:Link database query information.Different version information can be returned according to the 'clientType' of request.
    var results = new List<UpdateVersionDTO>();
    results.Add(new UpdateVersionDTO("1bfd7236258b12c51fd09f13808235df", 1626711760, "9.1.3.0", "http://192.168.50.170/patch.zip", "updatepacket1"));
    //results.Add(new UpdateVersionDTO("d9a3785f08ed3dd92872bd807ebfb917", 1626711820, "9.1.4.0",
    //"http://192.168.50.170/Update2.zip",
    //"updatepacket2"));
    //results.Add(new UpdateVersionDTO("224da586553d60315c55e689a789b7bd", 1626711880, "9.1.5.0",
    //"http://192.168.50.170/Update3.zip",
    //"updatepacket3"));
    return await Task.FromResult(results);
}

async Task<List<UpdateVersionDTO>> GetValidateInfos(int clientType, string clientVersion)
{
    //TODO:Link database query information.Different version information can be returned according to the 'clientType' of request.
    var results = new List<UpdateVersionDTO>();
    results.Add(new UpdateVersionDTO("1bfd7236258b12c51fd09f13808235df", 1626711760, "9.1.3.0", null, null));
    //results.Add(new UpdateVersionDTO("d9a3785f08ed3dd92872bd807ebfb917", 1626711820, "9.1.4.0", null, null));
    //results.Add(new UpdateVersionDTO("224da586553d60315c55e689a789b7bd", 1626711880, "9.1.5.0", null, null));
    return await Task.FromResult(results);
}

string GetLastVersion()
{
    //TODO:Link database query information.
    return "9.1.3.0";
}