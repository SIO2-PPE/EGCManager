using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    class DaoClient
    {
        private Dbal dbal;

        public DaoClient(Dbal dbal)
        {
            this.dbal = dbal;
        }
    }
}
