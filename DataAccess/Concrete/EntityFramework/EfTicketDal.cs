using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTicketDal : EfEntityRepositoryBase<Ticket, CekilisDbContext>, ITicketDal
    {
     

        public List<TicketsDetailDto> GetByTicketsUserId(Expression<Func<Ticket, bool>> filter = null)
        {
            using (CekilisDbContext context = new CekilisDbContext())
            {
                var result = from t in filter == null ? context.Tickets : context.Tickets.Where(filter)
                             join c in context.Categories
                             on t.CategoryId equals c.CategoryId
                             join p in context.Products
                             on t.ProductId equals p.ProductId
                             join u in context.Users
                             on t.UserId equals u.Id

                             select new TicketsDetailDto
                             {

                                 UserName = u.FirstName + " " + u.LastName,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 NumberOfTicketId = t.NumberOfTickets,
                                 UserId = u.Id,
                                 ProductId = p.ProductId

                             };
                return result.ToList();
            }
        }





    }
}
