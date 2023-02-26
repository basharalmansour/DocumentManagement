using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleanArchitecture.Infrastructure.HttpClients;

public abstract class BaseHttpClient
{
    private readonly HttpClient _httpClient;

    protected BaseHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Return type parameter</typeparam>
    /// <param name="url"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected virtual async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url); 
        
        var content = await response.Content.ReadAsStringAsync();
        var a = typeof(T);
        if (typeof(T).IsValueType || typeof(T) == typeof(String))
            return (T)Convert.ChangeType(content,typeof(T));

        var result = System.Text.Json.JsonSerializer.Deserialize<T>(content);
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Return type parameter</typeparam>
    /// <param name="url"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected virtual async Task<T> PutAsync<T>(string url,object body,CancellationToken cancellationToken = default)
    {
        
       
        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), Encoding.UTF8,
  "application/json");
        var response = await _httpClient.PutAsync(url,content,cancellationToken);
        var result = System.Text.Json.JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
        return result;
    }
    protected virtual async Task PutAsync(string url, object body, CancellationToken cancellationToken = default)
    {

        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body));
        var response = await _httpClient.PutAsync(url, content);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Return type parameter</typeparam>
    /// <param name="url">Full url</param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected virtual async Task<T> PostAsync<T>(string url, object body, CancellationToken cancellationToken = default)
    {
        var content = PrepareJsonBodyContent(body);
        var responseMessage = await _httpClient.PostAsync(url, content);
        var contentresp = await responseMessage.Content.ReadAsStringAsync();
        if (typeof(T).IsValueType)
            return (T)Convert.ChangeType(contentresp, typeof(T));
        var result = System.Text.Json.JsonSerializer.Deserialize<T>(contentresp);
        return result;
    }
    protected virtual async Task PostAsync(string url,object body)
    {
        var content = PrepareJsonBodyContent(body);
        await _httpClient.PostAsync(url, content); 
    }
    protected virtual async Task<T> PostWithFormUrlEncoded<T>(string url,Dictionary<string,string> form,CancellationToken cancellationToken = default)
    {
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(form) };
        var response = await _httpClient.PostAsync(url, new FormUrlEncodedContent(form), cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken) ?? String.Empty;
        return JsonConvert.DeserializeObject<T>(content,new IsoDateTimeConverter()
        {
             DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
        });
    }
    protected virtual async Task PostWithFormUrlEncoded(string url, Dictionary<string, string> form, CancellationToken cancellationToken = default)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(form) };
        var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
    }
    protected virtual async Task<T> GetWithFormUrlEncoded<T>(string url, Dictionary<string, string> form = null, CancellationToken cancellationToken = default)
    {
        HttpRequestMessage requestMessage = default;
        requestMessage = new HttpRequestMessage(HttpMethod.Get, url) { Content = form is not null ? new FormUrlEncodedContent(form) : default };
        var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken) ?? String.Empty;
        return JsonConvert.DeserializeObject<T>(content,
            new IsoDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            });
    }
    protected ByteArrayContent PrepareJsonBodyContent(object body,string mediaTypeHeaderValue = "application/json")
    {
        var content = JsonConvert.SerializeObject(body);
        var buffer = Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue(mediaTypeHeaderValue);
        return byteContent;
    }
}
