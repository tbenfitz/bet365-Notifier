using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bet365_Notifier
{
    public class League
    {
        public League()
        {
            this.Games = new List<Game>();
        }

        public string GameLeague { get; set; }
        public List<Game> Games { get; set; }
    }
}
