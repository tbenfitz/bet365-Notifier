using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using WatiN.Core;
using HtmlAgilityPack;
using TLSharp.Core;
using TLSharp.Core.Auth;
using TLSharp.Core.Utils;
using TeleSharp.TL;

namespace bet365_Notifier
{
    public partial class frmBet365 : System.Windows.Forms.Form
    {
        private EmailHelper emailHelper;
        private List<NotificationInfo> notificationInfo;
        private bool continueReporting;
        private List<League> previousLeagues;
        private List<League> currentLeagues;
        private Dictionary<string, TimeSpan> previousAlertTimeSpan;
        private string telegramCode;

        public frmBet365()
        {
            InitializeComponent();            
        }
       
        private void frmBet365_Load(object sender, EventArgs e)
        {
            emailHelper = new EmailHelper();            
            previousLeagues = new List<League>();
            currentLeagues = new List<League>();
            previousAlertTimeSpan = new Dictionary<string, TimeSpan>();
            numericUpDownNumberGoals.Value = 1;
            numericUpDownMatchTimeNotificationMins.Value = 1;
            numericUpDownMatchTimeNotificationSecs.Value = 0;
            continueReporting = true;

            this.HandleUI();

            ////WhatsAppNotifier whatsAppNotifier = new WhatsAppNotifier();

            ////whatsAppNotifier.SendMessage("TEST");
        }

        private void HandleUI()
        {
            if (this.textBoxEmail.Text.Trim().Length > 0 &&
                this.txtBoxPhone.Text.Trim().Length > 0 &&
                this.txtBoxTelegramCode.Text.Trim().Length > 0)
            {
                try
                {
                    var email = new MailAddress(this.textBoxEmail.Text.Trim());

                    this.btnBeginReporting.Enabled = true;
                    this.btnStopReporting.Enabled = true;                    

                    if (continueReporting == true)
                    {
                        this.textBoxEmail.Enabled = false;
                    }
                    else
                    {
                        this.textBoxEmail.Enabled = true;
                    }
                }
                catch (FormatException ex)
                {
                    this.btnBeginReporting.Enabled = false;
                    this.btnStopReporting.Enabled = false;
                }                  
            }
            else
            {
                this.btnBeginReporting.Enabled = false;
                this.btnStopReporting.Enabled = false;
            }
        }

        private void CommenceReporting()
        {
            try
            {                           
                using (var browser = new IE("https://mobile.bet365.com/#type=InPlay;key=;ip=1;lng=1"))
                {
                    browser.Visible = false;
                    System.Threading.Thread.Sleep(5000);

                    while (continueReporting)
                    {
                        try
                        {                            
                            Element mapElement = browser.Element("wrapper");

                            string mapHtml = mapElement.InnerHtml;

                            // --- Iterate over areas 
                            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                            doc.LoadHtml(mapHtml);

                            try
                            {
                                List<League> daLeagues = new List<League>();

                                if (currentLeagues.Count > 0)
                                {
                                    previousLeagues.Clear();
                                    previousLeagues.AddRange(currentLeagues);
                                }

                                foreach (HtmlNode sportBaseNode in doc.DocumentNode.SelectNodes("//div[contains(@class, 'ipo-ClassificationMenuBase ') and not(contains(@class, 'ipo-Competition_EventLink'))]"))
                                {
                                    HtmlNode selectedSportNode = sportBaseNode.SelectSingleNode("//div[contains(@class, 'ipo-ClassificationMenu_Selected')]");

                                    string selectedSport = selectedSportNode.InnerText.ToLower().Trim();

                                    if (selectedSport == "soccer")
                                    {
                                        foreach (HtmlNode categoryNode in doc.DocumentNode.SelectNodes("//div[@class='ipo-CompetitionBase ']"))
                                        {
                                            try
                                            {
                                                League daLeague = new League();
                                                List<Game> daGames = new List<Game>();

                                                HtmlNode leagueNode = categoryNode.FirstChild.SelectSingleNode(".//div[@class='ipo-Competition_Name ']");

                                                if (leagueNode != null)
                                                {
                                                    daLeague.GameLeague = leagueNode.InnerText;
                                                    
                                                        foreach (HtmlNode gameTimeOuterNode in categoryNode.SelectNodes(".//div[contains(@class, 'ipo-Fixture') and contains(@class, 'ipo-Fixture_TimedFixture')]"))
                                                        {
                                                            try
                                                            {
                                                                Game daGame = new Game();

                                                                HtmlNode gameTimeNode = gameTimeOuterNode.SelectSingleNode(".//div[contains(@class, 'ipo-Fixture_GameInfo') and contains(@class, 'ipo-Fixture_Time')]");
                                                                daGame.GameTime = new TimeSpan(0, Int32.Parse(gameTimeNode.InnerText.Substring(0, gameTimeNode.InnerText.IndexOf(':'))), Int32.Parse(gameTimeNode.InnerText.Substring(gameTimeNode.InnerText.IndexOf(':') + 1)));

                                                                int teamCount = 0;

                                                                foreach (HtmlNode gameNode in gameTimeOuterNode.SelectNodes(".//div[contains(@class, 'ipo-Fixture_GameItem ')]"))
                                                                {
                                                                    int tryParseNumber;

                                                                    if (teamCount == 0)
                                                                    {
                                                                        Team team = new Team();

                                                                        HtmlNode team1Node = gameNode.FirstChild.FirstChild;
                                                                        team.TeamName = team1Node.InnerText;

                                                                        HtmlNode team1PointsNode = gameNode.FirstChild.NextSibling.FirstChild;

                                                                        if (Int32.TryParse(team1PointsNode.InnerText, out tryParseNumber))
                                                                        {
                                                                            team.TeamScore = Int32.Parse(team1PointsNode.InnerText);
                                                                        }
                                                                        else
                                                                        {
                                                                            team.TeamScore = 0;
                                                                        }

                                                                        daGame.Teams.Add(team);

                                                                        // --- Bump team count
                                                                        teamCount++;
                                                                    }
                                                                    else if (teamCount == 1)
                                                                    {
                                                                        Team team = new Team();

                                                                        HtmlNode team2NameNode = gameNode.FirstChild.FirstChild;
                                                                        team.TeamName = team2NameNode.InnerText;

                                                                        HtmlNode team2PointsNode = gameNode.FirstChild.NextSibling.FirstChild;

                                                                        if (Int32.TryParse(team2PointsNode.InnerText, out tryParseNumber))
                                                                        {
                                                                            team.TeamScore = Int32.Parse(team2PointsNode.InnerText);
                                                                        }
                                                                        else
                                                                        {
                                                                            team.TeamScore = 0;
                                                                        }

                                                                        daGame.Teams.Add(team);
                                                                        teamCount = 0;
                                                                    }
                                                                }

                                                                // --- Add the game
                                                                daLeague.Games.Add(daGame);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                var st = new StackTrace(ex, true);
                                                                var frame = st.GetFrame(0);
                                                                var line = frame.GetFileLineNumber();

                                                                // --- Report on error and continue
                                                                emailHelper.SendExceptionEmail(ex.Message + " " + line);
                                                            }
                                                        }                                                    

                                                    daLeagues.Add(daLeague);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                var st = new StackTrace(ex, true);
                                                var frame = st.GetFrame(0);
                                                var line = frame.GetFileLineNumber();

                                                // --- Report on error and continue
                                                emailHelper.SendExceptionEmail("Error going over category nodes - " + ex.Message + " " + line);
                                            }
                                        }

                                        // --- Report to master
                                        int a = 0;
                                    }
                                }

                                if (previousLeagues.Count == 0)
                                {
                                    previousLeagues.AddRange(daLeagues);
                                }
                                else
                                {
                                    currentLeagues.AddRange(daLeagues);
                                    this.ReportChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                var st = new StackTrace(ex, true);
                                var frame = st.GetFrame(0);
                                var line = frame.GetFileLineNumber();

                                // --- Report on error and continue
                                emailHelper.SendExceptionEmail("Error going over sport base nodes - " + ex.Message + " " + line);
                            }

                            // --- Check the page only ever 5 seconds
                            System.Threading.Thread.Sleep(5000);
                        }
                        catch (Exception ex)
                        {
                            var st = new StackTrace(ex, true);                            
                            var frame = st.GetFrame(0);                            
                            var line = frame.GetFileLineNumber();

                            // --- Report on error and continue
                            emailHelper.SendExceptionEmail("Error in try right after start of while loop - " + ex.Message + " " + line);
                        }
                    }
                }                                       
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();

                // --- Report on error and continue
                emailHelper.SendExceptionEmail("Error outside using - " + ex.Message + " " + line);
            }
        }

        private void ReportChanges()
        {
            try
            {
                foreach (League currentLeague in currentLeagues)
                {
                    // --- Find match in previousLeagues
                    var previousLeague =
                        previousLeagues.Where(league => league.GameLeague == currentLeague.GameLeague);

                    if (previousLeague.Count() > 0)
                    {
                        foreach (Game currentGame in currentLeague.Games)
                        {                           
                            var previousGame =
                                previousLeague.First().Games.Where(game => game.GameName == currentGame.GameName);

                            if (previousGame.Count() > 0)
                            {
                                var previousTeams = previousGame.First().Teams;

                                if (previousTeams.Count() > 0)
                                {
                                    int goalThresehold = (int)numericUpDownNumberGoals.Value;
                                    TimeSpan previousGameTime = previousGame.First().GameTime;
                                    TimeSpan currentGameTime = currentGame.GameTime;

                                    int mins = (int)numericUpDownMatchTimeNotificationMins.Value;
                                    int secs = (int)numericUpDownMatchTimeNotificationSecs.Value;

                                    TimeSpan timeAlertSetting = new TimeSpan(0, mins, secs);

                                    var previousTeam1 = previousTeams.ElementAt(0);
                                    var previousTeam2 = previousTeams.ElementAt(1);
                                    var currentTeam1 = currentGame.Teams[0];
                                    var currentTeam2 = currentGame.Teams[1];

                                    if (currentTeam1.TeamScore >= goalThresehold || currentTeam2.TeamScore >= goalThresehold)
                                    {
                                        // --- Check to see if goals have been scored before game time thresehold
                                        if (currentGameTime <= timeAlertSetting)
                                        {
                                            // --- Add to notificationInfo
                                            NotificationInfo gameInfo = new NotificationInfo();
                                            gameInfo.GameLeague = currentLeague.GameLeague;
                                            gameInfo.GameTime = currentGameTime;
                                            gameInfo.Team1 = currentTeam1;
                                            gameInfo.Team2 = currentTeam2;

                                            if (notificationInfo.Contains(gameInfo) == false)
                                            {
                                                notificationInfo.Add(gameInfo);
                                            }
                                        }
                                    }

                                    ////if (previousAlertTimeSpan.ContainsKey(previousGame.First().GameName))
                                    ////{
                                    ////    // --- Check to see if enough time has elapsed for an alert
                                    ////    TimeSpan timeDiff = currentGame.GameTime - previousAlertTimeSpan[previousGame.First().GameName];                                                                              

                                    ////    if (timeDiff >= timeAlertSetting)
                                    ////    {
                                    ////        // --- TODO --- Send Alert
                                    ////    }

                                    ////    if ()
                                    ////}
                                    else
                                    {
                                        previousAlertTimeSpan[previousGame.First().GameName] = previousGame.First().GameTime;
                                    }
                                }
                            }
                        }
                    }
                }

                if (notificationInfo.Count() > 0)
                {
                    StringBuilder emailMessage = new StringBuilder();
                    StringBuilder telegramMessage = new StringBuilder();
                    string delimiter = " <b>&mdash;</b> ";
                    bool sendNotification = false;

                    foreach (NotificationInfo info in notificationInfo)
                    {
                        if (info.NotificationSent == false)
                        {
                            emailMessage.Append("<b>");
                            emailMessage.Append(info.GameLeague);
                            emailMessage.Append("</b>");
                            emailMessage.Append(delimiter);
                            emailMessage.Append(info.GameTime.ToString());
                            emailMessage.Append(delimiter);
                            emailMessage.Append(info.Team1.TeamName);
                            emailMessage.Append(" ");
                            emailMessage.Append(info.Team1.TeamScore);
                            emailMessage.Append(delimiter);
                            emailMessage.Append(info.Team2.TeamName);
                            emailMessage.Append(" ");
                            emailMessage.Append(info.Team2.TeamScore);
                            emailMessage.Append("<br /><hr /><br />");

                            telegramMessage.Append(info.GameLeague);
                            telegramMessage.Append(" - ");
                            telegramMessage.Append(info.GameTime.ToString());
                            telegramMessage.Append("\n");
                            telegramMessage.Append(info.Team1.TeamName);
                            telegramMessage.Append(" - ");
                            telegramMessage.Append(info.Team1.TeamScore);
                            telegramMessage.Append("\n");
                            telegramMessage.Append(info.Team2.TeamName);
                            telegramMessage.Append(" - ");
                            telegramMessage.Append(info.Team2.TeamScore);
                            telegramMessage.Append("\n ----------------------------- \n");

                            info.NotificationSent = true;
                            sendNotification = true;
                        }
                    }

                    if (sendNotification == true)
                    {
                        emailHelper.SendNotificationEmail(this.textBoxEmail.Text.Trim(), "Bet 365 Notification", emailMessage.ToString());
                        this.SendTelegram(telegramMessage.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                emailHelper.SendExceptionEmail(ex.Message);
            }
        }

        private void btnBeginReporting_Click(object sender, EventArgs e)
        {            
            try
            {                
                notificationInfo = new List<NotificationInfo>();

                this.HandleUI();
                this.btnBeginReporting.Enabled = false;
                this.continueReporting = true;

                Thread workThread = new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    CommenceReporting();
                });

                workThread.ApartmentState = ApartmentState.STA;
                workThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.emailHelper.SendExceptionEmail(ex.Message);
            }
        }        

        private void btnStopReporting_Click(object sender, EventArgs e)
        {
            continueReporting = false;
            this.HandleUI();         
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxEmail.Text.Trim().Length > 0)
            {
                try
                {
                    var email = new MailAddress(this.textBoxEmail.Text.Trim());

                    this.btnBeginReporting.Enabled = true;
                    this.btnStopReporting.Enabled = true;  
                }
                catch (FormatException ex)
                {
                    this.btnBeginReporting.Enabled = false;
                    this.btnStopReporting.Enabled = false;
                }                              
            }
            else
            {
                this.btnBeginReporting.Enabled = false;
                this.btnStopReporting.Enabled = false;
            }
        }

        private async Task<int> SendTelegram(string message)
        {
            try
            {
                var client = new TelegramClient(57982, "19706860344842eadeb0cc00f28d0902");
                await client.ConnectAsync();

                var hash = await client.SendCodeRequestAsync(this.txtBoxPhone.Text.Trim());

                var code = this.txtBoxTelegramCode.Text.Trim(); // you can change code in debugger

                var user = await client.MakeAuthAsync(this.txtBoxPhone.Text.Trim(), hash, code);

                //get available contacts
                var result = await client.GetContactsAsync();

                //find recipient in contacts
                var recipient = result.users.lists
                    .Where(x => x.GetType() == typeof(TLUser))
                    .Cast<TLUser>()
                    .FirstOrDefault(x => x.phone == this.txtBoxPhone.Text.Trim());

                //send message
                await client.SendMessageAsync(new TLInputPeerUser() { user_id = recipient.id }, message);
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();

                // --- Report on error and continue
                emailHelper.SendExceptionEmail(ex.Message + " " + line);
            }

            return 1;
        }

        private void btnGetTelegramCode_Click(object sender, EventArgs e)
        {
            this.GetTelegramCode();
        }

        private async Task<int> GetTelegramCode()
        {
            try
            {
                var client = new TelegramClient(57982, "19706860344842eadeb0cc00f28d0902");
                await client.ConnectAsync();

                var hash = await client.SendCodeRequestAsync(this.txtBoxPhone.Text.Trim());
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();

                // --- Report on error and continue
                emailHelper.SendExceptionEmail(ex.Message + " " + line);
            }

            return 1;
        }
    }
}
