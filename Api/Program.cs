using minimal_api;

IHostBuilder CreaterHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}

CreaterHostBuilder(args).Build().Run();