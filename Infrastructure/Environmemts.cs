using EPiServer.ServiceLocation;

public static class Environments
{
    private static readonly IWebHostEnvironment _webHostingEnvironment = ServiceLocator.Current.GetInstance<IWebHostEnvironment>();
    public static bool IsProd()
    {
        var webhostingEnvironment = _webHostingEnvironment;
        return webhostingEnvironment.IsProduction();
    }

    public static bool IsPrep()
    {
        var webhostingEnvironment = _webHostingEnvironment;
        return webhostingEnvironment.IsStaging();
    }

    public static bool IsDev()
    {
        var webhostingEnvironment = _webHostingEnvironment;
        return webhostingEnvironment.IsDevelopment();
    }
}
