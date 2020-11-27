using System;
using System.Collections.Generic;
using System.Text;
using Model.Business;

namespace Model.Data
{
    class DaoObstacle
    {
        private Dbal dbal;

        public DaoObstacle(Dbal dbal)
        {
            this.dbal = dbal;
        }
        public void AddObstacleToPartie(Obstacle o, Partie p, int position)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("obstacle", o.Id.ToString());
            val.Add("partie", p.Id.ToString());
            val.Add("position", position.ToString());
            this.dbal.Insert("obstacle_partie", val);
        }
    }
}
