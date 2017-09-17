namespace nancy_test
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => {
                return View["index", new {}];
            });
        }
    }
}
