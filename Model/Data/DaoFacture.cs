using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class DaoFacture
    {
        private Dbal _dbal;

        public DaoFacture(Dbal dbal)
        {
            this._dbal = dbal;
        }
    }
}
