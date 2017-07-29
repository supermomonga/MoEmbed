
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
            });

RunTarget(target);
