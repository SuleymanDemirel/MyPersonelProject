using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ITicketService
    {
       
        IResult Add(Ticket ticket);
        IResult Update(Ticket ticket);
        IResult Delete(Ticket ticket);

        IDataResult<List<TicketsDetailDto>> GetByTicketsUserId(int id);

        IDataResult<List<TicketsDetailDto>> GetAll();


    }
}

