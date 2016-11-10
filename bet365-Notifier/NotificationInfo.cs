using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bet365_Notifier
{
    public class NotificationInfo : IEquatable<NotificationInfo>
    {
        public string GameLeague { get; set; }
        public TimeSpan GameTime { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public bool NotificationSent { get; set; }

        public bool Equals(NotificationInfo other)
        {
            if (other == null)
            {
                return false;
            }
            else if (other.GameLeague == this.GameLeague && 
                     other.Team1.TeamName == this.Team1.TeamName &&
                     other.Team2.TeamName == this.Team2.TeamName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
