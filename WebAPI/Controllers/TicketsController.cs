using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("add")]
        public IActionResult Add(Ticket ticket) // client'dan,angular'dan,react'dan vs. gönderdiğin ürünü buraya koy.
        {
            var result = _ticketService.Add(ticket);
            if (result.Success)// işlem sonucu true ise
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyticketsuserid")]
        public IActionResult GetByTicketsUserId(int id)
        {
            var result = _ticketService.GetByTicketsUserId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ticketService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
