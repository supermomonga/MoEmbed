#addin "Cake.Http"

var target = Argument("target", "Default");

Task("Default")
    .Does(() =>
            {
                Information("Hello World!");
            });

Task("TwitterSetup")
    .Does(() =>
            {
                Information("Twitter bearer token setup");
                Console.WriteLine("Twitter API Key");
                Console.Write("=> ");
                var apiKey = Console.ReadLine();
                Console.WriteLine("Twitter API Secret");
                Console.Write("=> ");
                var apiSecret = Console.ReadLine();
                var credentialBase = $"{ apiKey }:{ apiSecret }";
                var bs = System.Text.Encoding.UTF8.GetBytes(credentialBase);
                var credential = Convert.ToBase64String(bs);
                string responseBody = HttpPost("https://api.twitter.com/oauth2/token", settings => {
                    settings.AppendHeader("Authorization", $"Basic { credential }");
                    settings.AppendHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
                    var formData = new Dictionary<string, string>
                    {
                        { "grant_type", "client_credentials" }
                    };
                    settings.SetFormUrlEncodedRequestBody(formData);
                });
                Information(responseBody);
            });

RunTarget(target);
