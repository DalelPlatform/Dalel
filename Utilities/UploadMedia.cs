using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Utilities
{
    public class UploadMedia
    {
        private const string ApiKey = "4e605ee2af96816038aecb5232984a8b";
        private const string UploadUrl = "https://api.imgbb.com/1/upload";

        public static List<string> UploadImgaes(IFormFileCollection files)
        {
            List<string> uploadedImageUrls = new();

            using HttpClient client = new();

            foreach (var file in files)
            {
                using var ms = new MemoryStream();
                file.CopyTo(ms); // Sync
                var fileBytes = ms.ToArray();
                string base64Image = Convert.ToBase64String(fileBytes);

                var content = new MultipartFormDataContent
                {
                    { new StringContent(ApiKey), "key" },
                    { new StringContent(base64Image), "image" }
                };

                var response = client.PostAsync(UploadUrl, content).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var result = JsonDocument.Parse(json);
                    var url = result.RootElement.GetProperty("data").GetProperty("url").GetString();
                    if (url != null)
                        uploadedImageUrls.Add(url);
                }
            }

            return uploadedImageUrls;
        }
        public static async Task<List<string>> UploadImgaesAsync(IFormFileCollection files)
        {
            List<string> uploadedImageUrls = new();

            using HttpClient client = new();

            foreach (var file in files)
            {
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                string base64Image = Convert.ToBase64String(fileBytes);

                var content = new MultipartFormDataContent
                {
                    { new StringContent(ApiKey), "key" },
                    { new StringContent(base64Image), "image" }
                };

                var response = await client.PostAsync(UploadUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonDocument.Parse(json);
                    var url = result.RootElement.GetProperty("data").GetProperty("url").GetString();
                    if (url != null)
                        uploadedImageUrls.Add(url);
                }
            }

            return uploadedImageUrls;
        }
    }
}
