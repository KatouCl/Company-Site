using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySite.Domain.Entities;

namespace CompanySite.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        //Выборка всех текстовых полей
        IQueryable<TextField> GetTextFields();
        //Выборка поля по id
        TextField GetTextFieldById(Guid id);
        //Выборка по кодовому слову
        TextField GetTextFieldByCodeWord(string codeWord);
        //Сохранение и изменения 
        void SaveTextField(TextField entity);
        //Удаление
        void DeleteTextField(Guid id);
    }
}
