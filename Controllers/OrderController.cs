﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharmacyManagementServiceWebApi.Dto;
using pharmacyManagementServiceWebApi.Models;
using pharmacyManagementServiceWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacyManagementServiceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var order = _orderRepository.GetAll();
            return Ok(order);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //if (id <= 0)
            //{
            //    throw new InvalidException("Invalid Id");
            //}
            var supplier = _orderRepository.GetOrder(id);
            //if (supplier == null)
            //{
            //    throw new InvalidException("Invalid Id");
            //}
            return new OkObjectResult(supplier);
        }
        [HttpPost]
        public IActionResult Post(OrderDto orderDto)
        {
            var order = new OrderDetail
            {
                DrugId = orderDto.DrugId,
                Quantity = orderDto.Quantity,
                TotalAmount = orderDto.TotalAmount,
                OrderPrice = orderDto.OrderPrice,
            };
            var newOrder = _orderRepository.Create(order);
            return Created("Sucess", newOrder);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderDto orderDto)
        {
            var order = new OrderDetail
            {
                DrugId = orderDto.DrugId,
                Quantity = orderDto.Quantity,
                TotalAmount = orderDto.TotalAmount,
                OrderPrice = orderDto.OrderPrice,
            };
            _orderRepository.UpdateOrder(order);
            return new OkResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderRepository.DeleteOrder(id);
            return Ok();
        }
    }
}
