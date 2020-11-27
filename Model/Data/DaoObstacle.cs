using System;
using System.Collections.Generic;
using System.Text;
using Model.Business;

namespace Model.Data
{
    class DaoObstacle
    {
        private Dbal _dbal;

        public DaoObstacle(Dbal dbal)
        {
            this._dbal = dbal;
        }
        public void AddObstacleToPartie(Obstacle o, Partie p, int position)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("obstacle", o.Id.ToString());
            val.Add("partie", p.Id.ToString());
            val.Add("position", position.ToString());
            this._dbal.Insert("obstacle_partie", val);
        }
    }
}
