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
        //  private const string ApiKey = "4e605ee2af96816038aecb5232984a8b";
        // private const string UploadUrl = "https://api.imgbb.com/1/upload";

        public string addimage(IFormFile file)
        {
            string imagePath = "";
            var client = new HttpClient();

           
            if (file.Length > 0)
            {
                using var ms = new MemoryStream();
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var base64Image = Convert.ToBase64String(fileBytes);

                var content = new MultipartFormDataContent
                {
                    { new StringContent("4e605ee2af96816038aecb5232984a8b"), "key" },
                    { new StringContent(base64Image), "image" }
                };

                var response = client.PostAsync("https://api.imgbb.com/1/upload", content).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var result = JsonDocument.Parse(json);
                    var url = result.RootElement.GetProperty("data").GetProperty("url").GetString();
                    if (url != null)
                    {
                        imagePath= url;
                    }
                }
            }
            

            return imagePath;
        }
        public List<string> addimage(IFormFileCollection files)
        {
            List<string> imagePaths = new List<string>();
            var client = new HttpClient();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using var ms = new MemoryStream();
                    file.CopyTo(ms); 
                    var fileBytes = ms.ToArray();
                    var base64Image = Convert.ToBase64String(fileBytes);

                    var content = new MultipartFormDataContent
                    {
                        { new StringContent("4e605ee2af96816038aecb5232984a8b"), "key" },
                        { new StringContent(base64Image), "image" }
                    };

                    var response = client.PostAsync("https://api.imgbb.com/1/upload", content).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        var result = JsonDocument.Parse(json);
                        var url = result.RootElement.GetProperty("data").GetProperty("url").GetString();
                        if (url != null)
                        {
                            imagePaths.Add(url);
                        }
                    }
                }
            }

            return imagePaths;
        }
    }
}
