using MvcExamenApi1.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcExamenApi1.Services
{
    public class ServicePersonajes
    {
        private MediaTypeWithQualityHeaderValue header;
        private string ApiUrl;

        public ServicePersonajes()
        {
            this.ApiUrl = "https://webapiexamen1samu.azurewebsites.net/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }


        public async Task<List<PersonajeSerie>> GetPersonajesAsync()
        {
            string request = "api/personajes";
            List<PersonajeSerie> data = await this.CallApiAsync<List<PersonajeSerie>>(request);
            return data;
        }


        public async Task<List<PersonajeSerie>> GetPersonajesSeriesAsync(string serie)
        {
            string request = "api/personajes/GetPersonajesSeries/"+serie;
            List<PersonajeSerie> data = await this.CallApiAsync<List<PersonajeSerie>>(request);
            return data;
        }


        public async Task<List<string>> GetSeriesAsync()
        {
            string request = "api/personajes/series";
            List<string> data = await this.CallApiAsync<List<string>>(request);
            return data;
        }


        public async Task<PersonajeSerie> GetPersonajesIdAsync(int id)
        {
            string request = "api/personajes/PersonajesSeries/"+id;
            PersonajeSerie data = await this.CallApiAsync<PersonajeSerie>(request);
            return data;
        }


        public async Task DeletePersonajeAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/personajes/deletepersonaje/" + id;
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.DeleteAsync(request);
            }
        }
        public async Task InsertPersonajeAsync(PersonajeSerie per)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/personajes/insertpersonaje";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string json = JsonConvert.SerializeObject(per);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
            }
        }
        public async Task UpdatePersonajeAsync(PersonajeSerie per)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/personajes/updatepersonaje";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string json = JsonConvert.SerializeObject(per);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
            }
        }

    }
}
