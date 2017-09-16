using Nancy.Configuration;

public class Bootstrapper : Nancy.DefaultNancyBootstrapper 
{
    public override void Configure(INancyEnvironment environment)
    {
        var config = new Nancy.TraceConfiguration(enabled: true, displayErrorTraces: true);
        environment.AddValue(config);
    }
}