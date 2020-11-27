using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    class DaoFacture
    {
        private Dbal dbal;

        public DaoFacture(Dbal dbal)
        {
            this.dbal = dbal;
        }
    }
}
