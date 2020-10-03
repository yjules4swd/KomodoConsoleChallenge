using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public class ClaimsRepository
    {
        public List<string> queue = new List<string>();
        public string[] queuearray = new string[3];
        

        public bool ValueFound(string parm)
        {
            bool Check = false;

            if (queue.IndexOf(parm) >-1)
            {
                Check = true;
            }

            return Check;
        }

        public void AddToQueu(string parm)
        {
            queue.Add(parm);
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        
    }
}
