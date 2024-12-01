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
        private static readonly HttpClient HttpClient = new();

        public static async Task<ResponseModel<List<CategoryViewModel>>> GetActives(bool isActive = true)
        {
            return await GetAsync<List<CategoryViewModel>>($"{BaseUrl}/GetActives/{isActive}");
        }

        public static async Task<ResponseModel<List<CategoryViewModel>>> GetAllAsync()
        {
            return await GetAsync<List<CategoryViewModel>>($"{BaseUrl}/GetAll");
        }

        public static async Task<ResponseModel<CategoryViewModel>> GetByIdAsync(int id)
        {
            return await GetAsync<CategoryViewModel>($"{BaseUrl}/{id}");
        }

        public static async Task<ResponseModel<List<SelectListItem>>> GetSelectListItemsAsync()
        {
            var response = await GetActives();
            if (!response.IsSucceeded)
            {
                return new ResponseModel<List<SelectListItem>> { IsSucceeded = false, Error = response.Error };
            }

            return new ResponseModel<List<SelectListItem>>
            {
                IsSucceeded = true,
                Data = response.Data.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList()
            };
        }

        public static async Task<ResponseModel<CategoryViewModel>> CreateAsync(CategoryCreateViewModel model)
        {
            return await PostAsync<CategoryCreateViewModel, CategoryViewModel>($"{BaseUrl}/Create", model);
        }

        public static async Task<ResponseModel<bool>> UpdateAsync(CategoryUpdateViewModel model)
        {
            return await PutAsync<CategoryUpdateViewModel, bool>($"{BaseUrl}/Update", model);
        }

        public static async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            return await DeleteAsync<bool>($"{BaseUrl}/Delete/{id}");
        }

        // Yardımcı Metotlar
        private static async Task<ResponseModel<T>> GetAsync<T>(string url)
        {
            try
            {
                var response = await HttpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseModel<T>>(content) ?? new ResponseModel<T> { IsSucceeded = false, Error = "Invalid response" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<T> { IsSucceeded = false, Error = $"Exception: {ex.Message}" };
            }
        }

        private static async Task<ResponseModel<TResult>> PostAsync<TRequest, TResult>(string url, TRequest request)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(url, content);
                var contentResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseModel<TResult>>(contentResponse) ?? new ResponseModel<TResult> { IsSucceeded = false, Error = "Invalid response" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<TResult> { IsSucceeded = false, Error = $"Exception: {ex.Message}" };
            }
        }

        private static async Task<ResponseModel<TResult>> PutAsync<TRequest, TResult>(string url, TRequest request)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await HttpClient.PutAsync(url, content);
                var contentResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseModel<TResult>>(contentResponse) ?? new ResponseModel<TResult> { IsSucceeded = false, Error = "Invalid response" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<TResult> { IsSucceeded = false, Error = $"Exception: {ex.Message}" };
            }
        }

        private static async Task<ResponseModel<TResult>> DeleteAsync<TResult>(string url)
        {
            try
            {
                var response = await HttpClient.DeleteAsync(url);
                var contentResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseModel<TResult>>(contentResponse) ?? new ResponseModel<TResult> { IsSucceeded = false, Error = "Invalid response" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<TResult> { IsSucceeded = false, Error = $"Exception: {ex.Message}" };
            }
        }
    }
}
