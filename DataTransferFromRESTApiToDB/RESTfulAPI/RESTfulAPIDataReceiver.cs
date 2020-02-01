using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Получение данных из RESTful API.
    /// </summary>
    public class RESTfulAPIDataReceiver
    {
        /// <summary>
        /// Получить данные указанного типа по ссылке.
        /// </summary>
        /// <typeparam name="T">Тип данных для конвертации из JSON.</typeparam>
        /// <param name="url">Ссылка для получения данных.</param>
        private static void Get<T>(string url)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Empty).Result;

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<RootObject<T>>().Result;
            }
            else
            {
                throw new HttpRequestException($"{(int)response.StatusCode} ({response.ReasonPhrase})");
            }

            client.Dispose();
        }
    }
}
