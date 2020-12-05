using System;
using System.Collections.Generic;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoObstacle
    {
        private Dbal _dbal;

        public DaoObstacle(Dbal dbal)
        {
            _dbal = dbal;
        }
        /*public void AddObstacleToPartie(Obstacle o, Partie p, int position)
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("obstacle", o.Id);
            val.Add("partie", p.Id);
            val.Add("position", position);
            _dbal.Insert("obstacle_partie", val);
        }*/
    }
}
