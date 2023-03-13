using System.Text;
using CleanArchitecture.Domain.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CleanArchitecture.Application.Common.Dtos.CondoLife;
using StackExchange.Redis;

namespace CleanArchitecture.Infrastructure.HttpClients.CondoLife;

public class CondoLifeAuthorizationAdapter
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly CondoCredential _condoCredentials;
    private readonly string _loginUrl;
    private readonly IDatabase _redis;
    public CondoLifeAuthorizationAdapter(IHttpClientFactory httpClientFactory, IOptions<AppSettings> options/*, IConnectionMultiplexer redis*/)
    {
        _loginUrl = options.Value.ClientSettings.CondoLife.BaseUrl + options.Value.ClientSettings.CondoLife.Login;
        _condoCredentials = options.Value.ClientSettings.CondoLife.CredentialSettings;
        _httpClientFactory = httpClientFactory;
        //_redis = redis.GetDatabase(RedisDatabaseKeys.IntegrationProjectRedis);
    }

    public async Task<string> GetAccessToken(bool withoutCache = false)
    {
        if (_redis.KeyExists(CacheKeys.CondoAccessToken) && !withoutCache)
        {
            return JsonConvert.DeserializeObject<string>(await _redis.StringGetAsync(CacheKeys.CondoAccessToken));
        }

        var client = _httpClientFactory.CreateClient();
        var content = JsonConvert.SerializeObject(_condoCredentials);
        var buffer = Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var result = await client.PostAsync(_loginUrl, byteContent);
        result.EnsureSuccessStatusCode();
        var body = await result.Content.ReadAsStringAsync();
        var loginResultModel = System.Text.Json.JsonSerializer.Deserialize<CondoLoginResultDto>(body);

        await _redis.StringSetAsync(CacheKeys.CondoAccessToken,
            JsonConvert.SerializeObject(loginResultModel?.access_token),
            new TimeSpan(120, 0, 0));
        
        return loginResultModel?.access_token;
    }
    public string GetSiteId()
    {
        return _condoCredentials.SiteId;
    }
}
