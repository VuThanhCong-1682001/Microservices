using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Basket.API.Services;
using Basket.API.Services.Interfaces;
using Contracts.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Shared.Dtos.ScheduledJob;
using ILogger = Serilog.ILogger;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCacheService;
        private readonly ISerializeService _serializeService;
        private readonly ILogger _logger;
        private readonly BackgroundJobHttpService _backgroundJobHttpService;
        private readonly IEmailTemplateService _emailTemplateService;

        public BasketRepository(
            IDistributedCache redisCacheService,
            ISerializeService serializeService,
            ILogger logger,
            BackgroundJobHttpService backgroundJobHttpService,
            IEmailTemplateService emailTemplateService)
        {
            _redisCacheService = redisCacheService;
            _serializeService = serializeService;
            _logger = logger;
            _backgroundJobHttpService = backgroundJobHttpService;
            _emailTemplateService = emailTemplateService;
        }

        public async Task<bool> DeleteBasketFromUsername(string username)
        {
            try
            {
                await _redisCacheService.RemoveAsync(username);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("DeleteBasketFromUsername: " + ex.Message);
                return false;
            }
        }

        public async Task<Cart> GetBasketByUsername(string username)
        {
            var basket = await _redisCacheService.GetStringAsync(username);
            return string.IsNullOrEmpty(basket) ? null : _serializeService.Deserialize<Cart>(basket);
        }

        public async Task<Cart> UpdateBasket(Cart cart, DistributedCacheEntryOptions options = null)
        {
            if (options != null)
                await _redisCacheService.SetStringAsync(cart.UserName, _serializeService.Serialize(cart), options);
            else
                await _redisCacheService.SetStringAsync(cart.UserName, _serializeService.Serialize(cart));

            try
            {

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return await GetBasketByUsername(cart.UserName);
        }

        private async Task TriggerSendEmailReminderCheckout(Cart cart)
        {
            var emailTemplate = _emailTemplateService.GenerateReminderCheckoutOrderEmail(cart.UserName);

            var model = new ReminderCheckoutOrderDto(
                cart.EmailAddress, 
                "Reminder Checkout", 
                emailTemplate, 
                DateTimeOffset.UtcNow.AddSeconds(30));


        }
    }
}
