using CompanySite.Domain.Entities;
using CompanySite.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySite.Domain.Repositories.EntityFramework
{
    public class EFFeedBackRepository : IFeedBackRepository
    {
        private readonly AppDbContext context;
        public EFFeedBackRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void SaveFeedBack(FeedBack entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }
    }
}
