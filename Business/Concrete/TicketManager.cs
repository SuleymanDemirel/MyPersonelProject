using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TicketManager : ITicketService
    {
        ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }
        public IResult Add(Ticket ticket)
        {
            _ticketDal.Add(ticket);
            return new SuccessResult(Messages.TicketAdd);
        }

        public IResult Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }


        public IDataResult<List<TicketsDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<TicketsDetailDto>>(_ticketDal.GetByTicketsUserId(), Messages.TicketListed);
            
        }

        public IDataResult<List<TicketsDetailDto>> GetByTicketsUserId(int id)
        {
            return new SuccessDataResult<List<TicketsDetailDto>>(_ticketDal.GetByTicketsUserId(u => u.UserId == id));
        }

        public IResult Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
