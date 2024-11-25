using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using EgeApp.Frontend.Mvc.Models;
using EgeApp.Frontend.Mvc.Models.Category;
using EgeApp.Frontend.Mvc.Models.Response;

namespace EgeApp.Frontend.Mvc.Services
{
    public static class CategoryService
    {
        private const string BaseUrl = "http://localhost:5200/api/Categories";

        public static async Task<ResponseModel<List<CategoryViewModel>>> GetActives(bool isActive = true)
        {
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = new();
                try
                {
                    httpResponseMessage = await httpClient.GetAsync($"{BaseUrl}/GetActives/{isActive}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new ResponseModel<List<CategoryViewModel>> { Data = null, Error = "Server Hatası!", IsSucceeded = false };
                }

                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);
                return response;
            }
        }

        public static async Task<ResponseModel<List<CategoryViewModel>>> GetAllAsync()
        {
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{BaseUrl}/GetAll");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);
                return response;
            }
        }

        public static async Task<ResponseModel<CategoryViewModel>> GetByIdAsync(int id)
        {
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"{BaseUrl}/{id}");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<CategoryViewModel>>(contentResponse);
                return response;
            }
        }

        public static async Task<ResponseModel<List<SelectListItem>>> GetSelectListItemsAsync()
        {
            ResponseModel<List<SelectListItem>> result = new();
            var response = await GetActives();
            if (response.IsSucceeded)
            {
                result.Data = response.Data
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
                result.IsSucceeded = true;
            }
            result.Error = response.Error;
            result.IsSucceeded = response.IsSucceeded;
            return result;
        }

        public static async Task<ResponseModel<bool>> CreateAsync(CategoryCreateViewModel model)
        {
            using (HttpClient httpClient = new())
            {
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{BaseUrl}/Create", content);

                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<bool>>(contentResponse);
                return response;
            }
        }

        public static async Task<ResponseModel<bool>> UpdateAsync(CategoryEditViewModel model)
        {
            using (HttpClient httpClient = new())
            {
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PutAsync($"{BaseUrl}/Update", content);

                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<bool>>(contentResponse);
                return response;
            }
        }

        public static async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync($"{BaseUrl}/Delete/{id}");
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseModel<bool>>(contentResponse);
                return response;
            }
        }
    }
}