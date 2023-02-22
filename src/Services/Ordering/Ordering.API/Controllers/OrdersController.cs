using AutoMapper;
using Contracts.Messages;
using Contracts.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Common.Interfaces;
using Ordering.Application.Common.Models;
using Ordering.Application.Features.V1.Orders.Queries.GetOrders;
using Ordering.Domain.Entities;
using Shared.Services.Email;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Ordering.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMessageProducer _messageProducer;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrdersController(
            IMediator mediator, 
            IMessageProducer messageProducer,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _messageProducer = messageProducer;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        private static class RouteNames
        {
            public const string GetOrders = nameof(GetOrders);
        }

        [HttpGet("{username}", Name = RouteNames.GetOrders)]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderByUserName([Required] string username)
        {
            var query = new GetOrdersQuery(username);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var addedOrder = await _orderRepository.CreateOrder(order);
            await _orderRepository.SaveChangesAsync();
            var result = _mapper.Map<OrderDto>(addedOrder);

            _messageProducer.SendMessage(result);
            return Ok(result);
        }

        //[HttpGet("send-mail")]
        //public async Task<IActionResult> SendMail()
        //{
        //    var message = new MailRequest
        //    {
        //        Body = "<h1>Hello</h1>",
        //        Subject = "ASPNETCORE",
        //        ToAddress = "thanhcong1682001@gmail.com"
        //    };
        //    await _emailService.SendEmailAsync(message);
        //    return Ok();
        //}
    }
}
