using BlazorSozluk.Projections.User;
using BlazorSozluk.Projections.User.Services;
using UserService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();


        services.AddTransient<EmailService> ();
        services.AddTransient<BlazorSozluk.Projections.User.Services.UserService>(); 


    })
    .Build();