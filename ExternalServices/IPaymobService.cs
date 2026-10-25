using System.Text.Json;
using ELProject.Domain.Models;

namespace ELProject.ExternalServices
{
    public interface IPaymobService
    {
        public Task<string> CreatePaymentIntentAsync(Order order, ApplicationUser student, string paymentMethod = "Card");
        public Task<string> CalculateHmac(JsonElement obj, string secret);
    }
}