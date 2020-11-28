using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class DaoClient
    {
        private Dbal _dbal;

        public DaoClient(Dbal dbal)
        {
            this._dbal = dbal;
        }
    }
}
