using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,ReCapContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from c in context.OperationClaims
                    join p in context.UserOperationClaims
                        on c.Id equals p.OperationClaimID
                    where user.UserId == p.UserId
                    select new OperationClaim() {Id = c.Id, Name = c.Name};
                return result.ToList();
            }
        }
    }
}
