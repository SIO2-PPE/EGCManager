using System.Collections.Generic;

namespace Model.Business
{
    public interface IHydrate
    {
        public void Hydrate(Dictionary<string, dynamic> val);
        public Dictionary<string, dynamic> ToArray();
    }
}