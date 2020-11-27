using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    interface IDao
    {
        public void Insert(Object o);
        public void Update(Object o);
        public void Delete(Object o);
        public List<Object> SelectAll();
        public Object SelectById(int id);
        public Object SelectByName(string nom);
    }
}
