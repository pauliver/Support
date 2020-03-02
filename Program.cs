using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Octokit;

namespace Support
{

    // What do we need to trigger on 
    // - New Issues
    // - Issue Edit
    // - Issue Comment
    // - Issue Close 

    class Program
    {
        private const int JsonPath_Arg_Index = 0;
        private const int Owner_Arg_Index = 1;
        private const int Repo_Arg_Index = 2;

        static async System.Threading.Tasks.Task Main(string[] args)
        {   
            bool WebJson = false;
            bool LocalJson = false;
            bool HasValidJson = false;
            
            bool OwnerAndRepo = false;
            
            bool LoggedIn = false;
            
            GitHubClient github = null;

            System.IO.FileInfo file;

            string jsonpath = "";
            var Owner = "Owner";  
            var Repo = "Repo";   

            if(args.Length < 3)
            {
                Console.WriteLine("Usage: Support.exe ./Local/Path/file.json");
                Console.WriteLine("Or");
                Console.WriteLine("Usage: Support.exe http://domain.extension/file.json");
                Console.WriteLine("Or");
                Console.WriteLine("Usage: Support.exe http://domain.extension/file.json Owner Repo");
                Console.WriteLine("Or");
                Console.WriteLine("Usage: Support.exe ./Local/Path/file.json Owner Repo");

            }
            if(args.Length < 1)
            {
                Console.WriteLine("Json file not specified");
                return;
            }
            if(args[JsonPath_Arg_Index] is string)
            {
                jsonpath = args[JsonPath_Arg_Index]
                    as string;
            }
            if(args.Length >= 3 )
            {
                bool b_owner = false;
                bool b_repo = false;
                if(args[Owner_Arg_Index] is string)
                {
                    Owner = args[Owner_Arg_Index] as string;
                    b_owner = true;
                }
                if(args[Repo_Arg_Index] is string)
                {
                    Repo = args[Repo_Arg_Index] as string;
                    b_repo = true;
                }
                if(b_owner && b_repo)
                {
                    OwnerAndRepo = true;
                }
            }
                        
            try{
                Console.WriteLine("Loading github...");
                string secretkey = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
                if(secretkey == null || secretkey == "")
                {
                    Console.WriteLine("The Secret Key is not going to work, it's Null or Empty");
                    Console.WriteLine("Exiting");
                    return;
                }
                github = new GitHubClient(new ProductHeaderValue("Pauliver-Support"))
                {
                    Credentials = new Credentials(secretkey)
                };
                LoggedIn = true; 
            }catch(System.NullReferenceException nre)
            {
                Console.WriteLine("Null Refernece Exception :  " + nre.TargetSite);
                Console.WriteLine("You likely forgot to set..");
                Console.WriteLine("  env:");
                Console.WriteLine("    GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}");
                Console.WriteLine(" in your .yml file");
                Console.WriteLine(nre.ToString());
                LoggedIn = false;
                return;
            }catch(Exception ex){
                Console.WriteLine("... Loading Failed, but nothing was null..");
                Console.WriteLine(ex.ToString());
                LoggedIn = false;
                return;
            }

            Console.WriteLine(" --- ");

            if(!LoggedIn)
            {
                Console.WriteLine("GitHub Login State unclear, Exiting");
                return;
            }
            



        }
    }
}
