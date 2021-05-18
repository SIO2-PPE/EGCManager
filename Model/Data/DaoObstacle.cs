using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Obstacle> GetAllObstacle()
        {
            List<Obstacle> lst = new List<Obstacle>();
            DataTable tab = _dbal.Select("obstacle");
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Obstacle(row));
            }
            return lst;
        }

        public Obstacle New(Obstacle obstacle)
        {
            _dbal.Insert("obstacle", obstacle.ToArray());
            return new Obstacle(_dbal.Select("obstacle", "nom = '" + obstacle.Nom + "'").Rows[0]);
        }

        public void Delete(Obstacle obstacle)
        {
            _dbal.Delete("obstacle", "id = " + obstacle.Id);
        }

        public bool IsNotUse(Obstacle obstacle)
        {
            DataTable tab = _dbal.Select("obstacle_partie");
            bool r = true;
            foreach (DataRow row in tab.Rows)
            {
                if ((int)row["obstacle"] == obstacle.Id)
                {
                    r = false;
                }
            }
            return r;
        }
    }
}
