using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Open_Store
{
    public record RepoProfile(string Name, string FullName, string Author)
    {
        const string API = "https://api.github.com/repos/";

        public static RepoProfile GetProfile(string name)
        {
            if (!Basics.IsConnected())
            {
                Environment.Exit(-1);
            }

            using HttpClient httpClient = new HttpClient();

            // Set the User-Agent header
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(Const.NAME, Const.version));

            HttpResponseMessage existenceResponse = httpClient.GetAsync($"{API}{name}").Result;
            existenceResponse.EnsureSuccessStatusCode();

            using JsonDocument jsonDocument = JsonDocument.Parse(existenceResponse.Content.ReadAsStringAsync().Result);
            JsonElement root = jsonDocument.RootElement;

            string? repoName = root.GetProperty("name").GetString();
            string? fullName = root.GetProperty("full_name").GetString();
            string? author = root.GetProperty("owner").GetProperty("login").GetString();

            if (repoName == null || fullName == null || author == null)
            {
                Error.SomeError();
            }

            return new RepoProfile(repoName, fullName, author);
        }
    }
}
