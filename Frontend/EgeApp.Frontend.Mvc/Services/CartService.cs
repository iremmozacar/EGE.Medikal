using System;
using System.Text;
using Newtonsoft.Json;
using EgeApp.Frontend.Mvc.Controllers;
using EgeApp.Frontend.Mvc.Models.Cart;
using EgeApp.Frontend.Mvc.Models.Product;
using EgeApp.Frontend.Mvc.Models.Response;

namespace EgeApp.Frontend.Mvc.Services;

public class CartService
{
    public static async Task<ResponseModel<NoContent>> AddToCartAsync(AddToCartViewModel model)
    {
        using (HttpClient httpClient = new())
        {
            var serializeModel = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5200/api/carts/addtocart", stringContent);
            var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<NoContent>>(httpResponseMessageString);
            return response;
        }
    }
    public static async Task<ResponseModel<CartViewModel>> GetCartAsync(string userId)
    {
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5200/api/Carts/GetCart/{userId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<CartViewModel>>(contentResponse);
            return response;
        }
    }
    public static async Task<ResponseModel<CartItemViewModel>> GetCartItemAsync(int cartItemId)
    {
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:5200/api/Carts/GetCartItem/{cartItemId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<CartItemViewModel>>(contentResponse);
            return response;
        }
    }
    public static async Task<ResponseModel<ReturnChangeQuantityModel>> ChangeQuantityAsync(int cartItemId, int quantity, string userId)
    {
        using (HttpClient httpClient = new())
        {
            var serializeModel = JsonConvert.SerializeObject(new { cartItemId, quantity });
            var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:5200/api/carts/changequantity", stringContent);
            var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<ReturnChangeQuantityModel>>(httpResponseMessageString);
            ResponseModel<ReturnChangeQuantityModel> result = new();
            if (response.IsSucceeded)
            {
                var cartItem = await GetCartItemAsync(cartItemId);
                if (cartItem != null)
                {
                    result.Data.CartItemTotal = cartItem.Data.Quantity * cartItem.Data.Product.Price;
                }
                var cart = await GetCartAsync(userId);
                if (cart != null)
                {
                    result.Data.SubTotal = cart.Data.GetTotalPrice();
                    result.Data.CartTotal = result.Data.SubTotal > 20000 ? result.Data.SubTotal : result.Data.SubTotal + 1000;
                }
            }
            else
            {
                result.Data = null;
                result.Error = response.Error;
                result.IsSucceeded = response.IsSucceeded;
            }
            return result;
        }
    }
    public static async Task<ResponseModel<NoContent>> DeleteCartItemAsync(int cartItemId)
    {
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync($"http://localhost:5200/api/Carts/DeleteItem/{cartItemId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<NoContent>>(contentResponse);
            return response;
        }
    }
    public static async Task<ResponseModel<NoContent>> ClearCartAsync(int cartId)
    {
        using (HttpClient httpClient = new())
        {
            HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync($"http://localhost:5200/api/Carts/ClearCart/{cartId}");
            string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<NoContent>>(contentResponse);
            return response;
        }
    }
    public static async Task<ResponseModel<NoContent>> InitiliazeCartAsync(string userId)
    {
        using (HttpClient httpClient = new())
        {
            var serializeModel = JsonConvert.SerializeObject(new { UserId = userId });
            var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"http://localhost:5200/api/carts/createcart", stringContent);
            var httpResponseMessageString = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<NoContent>>(httpResponseMessageString);
            return response;
        }
    }
}

