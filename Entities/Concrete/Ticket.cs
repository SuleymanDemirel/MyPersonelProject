using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Ticket : IEntity
    {
        public int id { get; set; }

        public int UserId { get; set; }

        
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        public int NumberOfTickets { get; set; }


    }
}
