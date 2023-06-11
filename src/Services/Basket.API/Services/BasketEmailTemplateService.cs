﻿using Basket.API.Services.Interfaces;

namespace Basket.API.Services
{
    public class BasketEmailTemplateService : EmailTemplateService, IEmailTemplateService
    {
        public string GenerateReminderCheckoutOrderEmail(string username)
        {
            var checkoutUrl = "http://localhost:5001/baskets/checkout";
            var emailText = ReadEmailTemplateContent("reminder-checkout-order");
            var emailReplacedText = emailText.Replace("[username]", username)
                                             .Replace("[checkoutUrl]", checkoutUrl);
            return emailReplacedText; 
        }
    }
}
