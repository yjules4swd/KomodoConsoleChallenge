using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{
    public class BadgesRepository
    {
        public Dictionary<int, List<string>> Badges = new Dictionary<int, List<string>>();
        public int Key = 1000;
        List<string> m = new List<string>();

        public bool CheckKey(int param)
        {
            Badges.Add(param, m);
            bool value = false;
            if (Badges.ContainsKey(param))
            {
                value = true;
            }
            return value;
        }
    }
}
