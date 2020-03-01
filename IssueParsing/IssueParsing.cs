namespace Support
{
    public class IssueParsing
    {
        
        //https://github.com/pauliver/IRL-StatusReport/edit/master/StatusReport/StatusReport/IRLissue.cs
        public IRLissue(string name, string issue, string url)
        {
            EventName = name;

            string[] EachLine = issue.Split(Environment.NewLine);
            foreach(string line in EachLine)
            {
                if (line.Contains("- **Location**:"))
                {
                    location = line.Replace("- **Location**:", "").Trim();
                }
                if (line.Contains("Location:"))
                {
                    location = line.Replace("Location:", "").Replace("_","").Trim();
                }
                if (line.Contains("- **Event Name**:"))
                {
                    EventName = line.Replace("- **Event Name**:", "").Trim();
                }
                if (line.Contains("Event Name:"))
                {
                    EventName = line.Replace("Event Name:", "").Replace("_", "").Trim();
                }
                if (line.Contains("- **Start Date**:"))
                {
                    date = line.Replace("- **Start Date**:", "").Trim();
                    System.DateTime OutTime;
                    bool ValidDate = ParseDateTime(date, out OutTime);
                    if (ValidDate)
                        time = OutTime;
                }
                if (line.Contains("Start Date:"))
                {
                    date = line.Replace("Start Date:", "").Replace("_", "").Trim();
                    System.DateTime OutTime;
                    bool ValidDate = ParseDateTime(date, out OutTime);
                    if (ValidDate)
                        time = OutTime;
                }
                if (line.Contains("-days out"))
                {// |Staffing finalized |@ajjimenez  | 45-days out |✅ | | | 
                    string[] segments = line.Trim().Split("|");

                    int days = int.Parse(segments[3].Replace("-days out",""));
                    try
                    {
                        DateTime newdate = time.Subtract(TimeSpan.FromDays(days));

                        FollowUpActions.Add(new KeyValuePair<DateTime, String>(newdate, "| [" + EventName.Trim() + "](" + IRL_Link.Trim() + ") [IRL](" + url + ") " + "[DevRel]( " + GitHub_PlanningIssue.Trim() + ") | " + segments[4] + " | " + segments[1] + " | " + segments[2] + " |"));

                    }catch(Exception)
                    {
                        Console.WriteLine("[" + EventName.Trim() + "]" + " Bad data in : " + segments[1] + " ? " + time.ToString());
                    }
                }
                if(line.Contains("- **IRL link**:"))
                {//-**IRL link: **https://irl.githubapp.com/events/201 

                    IRL_Link = line.Replace("- **IRL link**:","").Trim();
                }
                if (line.Contains("- **GitHub planning issue**:"))
                {//**GitHub planning issue: https://github.com/github/developer-relations/issues/165** 

                    GitHub_PlanningIssue = line.Replace("- **GitHub planning issue**:", "").Trim();
                }
                if (line.Contains("- **Date/Time**:"))
                {// -**Date / Time: 9 / 4 8:00AM - 8:00PM, 9 / 5 9:00AM - 10:00PM, 9 / 6 9:30AM - 8:00PM * *
                                

                }
            }

    }
}