using CompanySite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySite.Domain.Repositories.Abstract
{
    public interface IFeedBackRepository
    {
        void SaveFeedBack(FeedBack entity);
    }
}
