using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bet365_Notifier
{
    public class Game
    {
        public const string NO_TEAMS_CODE = "NoTeamsForGame";

        public Game()
        {
            this.Teams = new List<Team>();
        }
        
        public TimeSpan GameTime { get; set; }

        public List<Team> Teams { get; set; }

        public string GameName 
        { 
            get 
            {
                if (this.Teams.Count == 2)
                {
                    return this.Teams[0].TeamName + "|" + this.Teams[1].TeamName;
                }
                else
                {
                    return NO_TEAMS_CODE;
                }
            }
        }
    }
}
