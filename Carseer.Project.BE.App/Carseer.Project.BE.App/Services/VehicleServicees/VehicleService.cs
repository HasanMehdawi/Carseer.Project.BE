using Carseer.Project.BE.Domain.V1.Responses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection.PortableExecutable;

namespace Carseer.Project.BE.App.Services.VehicleServicees
{
    public class VehicleService : IVehicleService
    {
        private string GetAllMakes = "https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json";
        private string GetVehicleTypesForMakeById = "https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{id}?format=json";
        private string GetModelsForMakeIdAndACombinationOfYearAndVehicleType = "https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{id}/modelyear/{year}?format=json";
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
        public async Task<VehicleTypeResponse> GetVehicleTypesForMakeAsync(long makeId)
        {
            try
            {
                string GetVehicleTypesForMakeByIdApi = GetVehicleTypesForMakeById.Replace("{id}" ,makeId.ToString());
                var result = await GetAsync(GetVehicleTypesForMakeByIdApi);
                if (result != null)
                {
                    if (result.IsSuccessStatusCode && (int)result.StatusCode >= 200 && (int)result.StatusCode < 300)
                    {
                        var response = await result.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<VehicleTypeResponse>(response) ?? new();

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
        public async Task<VehicleModelResponse> GetModelsForMakeYearAsync(long makeId , int year)
        {
            try
            {
                string GetModelsForMakeIdAndACombinationOfYearAndVehicleTypeApi = GetModelsForMakeIdAndACombinationOfYearAndVehicleType.Replace("{id}" ,makeId.ToString())
                    .Replace("{year}" ,year.ToString());
                var result = await GetAsync(GetModelsForMakeIdAndACombinationOfYearAndVehicleTypeApi);
                if (result != null)
                {
                    if (result.IsSuccessStatusCode && (int)result.StatusCode >= 200 && (int)result.StatusCode < 300)
                    {
                        var response = await result.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<VehicleModelResponse>(response) ?? new();

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
