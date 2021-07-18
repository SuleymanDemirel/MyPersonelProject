using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CekilisDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CekilisDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();


            }
        }

        public List<UserForRegisterDto> GetUserDetails(Expression<Func<User, bool>> filter = null)
        {
            using (CekilisDbContext context = new CekilisDbContext())
            {
                var result = from u in filter == null ? context.Users : context.Users.Where(filter)

                             select new UserForRegisterDto
                             {
                              
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 id = u.Id
                                 


                             };
                return result.ToList();
            }
        }
    }
}
