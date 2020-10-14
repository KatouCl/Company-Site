using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySite.Domain.Entities;

namespace CompanySite.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        //Выборка всех текстовых полей
        IQueryable<ServiceItem> GetTextFields();
        //Выборка поля по id
        ServiceItem GetServiceItemById(Guid id);
        //Сохранение и изменения 
        void SaveServiceItem(ServiceItem entity);
        //Удаление
        void DeleteServiceItem(Guid id);
    }
}
