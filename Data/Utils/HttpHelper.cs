using System.Text;
using Data.Models.Common;

namespace Data.Utils;

public static class HttpHelper
{
    // basic authen pro: Basic MjQ3OjI0N0BQcm8=
    // basic authen dev: Basic MjQ3OjI0N0BEZXY=
    public static async Task<string> Post(string url, string jsonParam)
    {
        var client = new HttpClient();
        var response = client.PostAsync(url, new StringContent(jsonParam, Encoding.UTF8, "application/json")).Result;
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public static async Task<string> PostJob(string url, string jsonParam)
    {
        var client = new HttpClient();
        var response = client.PostAsync(url, new StringContent(jsonParam, Encoding.UTF8, "application/json")).Result;
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public static async Task<string> GetAsync(string url)
    {
        var client = new HttpClient();
        var response = client.GetAsync(url).Result;
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public static async Task<string> GetAsyncForGateWay(string url)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("token", "hrm");
        client.DefaultRequestHeaders.Add("userName", "hrm");
        var response = client.GetAsync(url).Result;
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public static async Task<string> PostGateWay(string url, string jsonParam)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("token", "hrm");
        client.DefaultRequestHeaders.Add("userName", "hrm");
        var response = client.PostAsync(url, new StringContent(jsonParam, Encoding.UTF8, "application/json")).Result;
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public static async Task<string> PostBasicHRMAuthen(string url, string jsonParam)
    {
        var client = new HttpClient();
        var account = Connection.AppSettings["HRMAccount"];
        var basicAuthen = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(account))}";
        client.DefaultRequestHeaders.Add("Authorization", basicAuthen);
        var response = client.PostAsync(url, new StringContent(jsonParam, Encoding.UTF8, "application/json")).Result;
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public static async Task<string> PostAuthen(string url, string jsonParam)
    {
        var client = new HttpClient();
        var account = Connection.AppSettings["PMSAccount"];
        var basicAuthen = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(account))}";
        client.DefaultRequestHeaders.Add("Authorization", basicAuthen);
        var response = client.PostAsync(url, new StringContent(jsonParam, Encoding.UTF8, "application/json")).Result;
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public static async Task<string> GetBasicHRMAuthen(string url)
    {
        var client = new HttpClient();
        var account = Connection.AppSettings["HRMAccount"];
        var basicAuthen = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(account))}";
        client.DefaultRequestHeaders.Add("Authorization", basicAuthen);
        var response = client.GetAsync(url).Result;
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
}