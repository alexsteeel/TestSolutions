using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Получение данных из RESTful API.
    /// </summary>
    public class RestApiReader<T> : IReader<IModel>
        where T : IModel
    {
        public RestApiReader(string url)
        {
            URL = url;
        }

        /// <summary>
        /// URL для получения данных.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Получение коллекции данных по ссылке.
        /// </summary>
        /// <returns>Коллекция данных.</returns>
        public IList<IModel> Read()
        {
            IList<T> result = new List<T>();

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Empty).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<RootObject<T>>().Result.Data;
            }
            else
            {
                throw new HttpRequestException($"{(int)response.StatusCode} ({response.ReasonPhrase})");
            }

            client.Dispose();

            return result.Cast<IModel>().ToList();
        }
    }
}
