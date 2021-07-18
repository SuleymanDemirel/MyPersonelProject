using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class TicketsDetailDto: IDto
    {
        public int id { get; set; }
        public int NumberOfTicketId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public string ProductName { get; set; }
       
        public string CategoryName { get; set; }

        public string UserName { get; set; }


    }
}
