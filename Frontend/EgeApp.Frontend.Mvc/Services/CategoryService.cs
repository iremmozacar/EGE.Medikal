using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using EgeApp.Frontend.Mvc.Models;
using EgeApp.Frontend.Mvc.Models.Category;
using EgeApp.Frontend.Mvc.Models.Response;

namespace EgeApp.Frontend.Mvc.Services;

public static class CategoryService
{
    public static async Task<ResponseModel<List<CategoryViewModel>>> GetActives(bool isActive = true)
    {
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = new();
            try
            {
                httpResponseMessage = await httpClient.GetAsync($"http://localhost:5200/api/Categories/GetActives/{isActive}");
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
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5200/api/Categories/GetAll");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<List<CategoryViewModel>>>(contentResponse);
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
}
