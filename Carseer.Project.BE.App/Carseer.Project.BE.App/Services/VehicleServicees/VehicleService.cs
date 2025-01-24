﻿using Carseer.Project.BE.Domain.V1.Responses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection.PortableExecutable;

namespace Carseer.Project.BE.App.Services.VehicleServicees
{
    public class VehicleService : IVehicleService
    {
        private string GetAllMakes = "https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json";
        private readonly HttpClient _httpClient;
        public VehicleService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<MakeResponse> GetMakesAsync()
        {
            try
            {
                var result = await GetAsync(GetAllMakes);
                if (result != null)
                {
                    if (result.IsSuccessStatusCode && (int)result.StatusCode >= 200 && (int)result.StatusCode < 300)
                    {
                        var response = await result.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<MakeResponse>(response) ?? new();

                    }
                    throw new Exception();
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        private async Task<HttpResponseMessage> GetAsync(string api)
        {
            var httpResponseMessage = await _httpClient.GetAsync(api);
            if (httpResponseMessage.IsSuccessStatusCode && (int)httpResponseMessage.StatusCode >= 200 && (int)httpResponseMessage.StatusCode < 300)
            {
                return httpResponseMessage;

            }
            return new HttpResponseMessage();
        }
    }

}
