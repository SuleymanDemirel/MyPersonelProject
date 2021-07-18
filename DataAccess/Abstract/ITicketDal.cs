using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITicketDal : IEntityRepository<Ticket>
    {
        List<TicketsDetailDto> GetByTicketsUserId(Expression<Func<Ticket, bool>> filter = null);
        

    }
}
