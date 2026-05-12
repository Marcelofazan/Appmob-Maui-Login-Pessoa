using Microsoft.Extensions.Logging;

namespace AppMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            // 3. Registrar Páginas (necessário para DI no construtor)
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<Cadastrar>();
            builder.Services.AddTransient<Confirmado>();
            builder.Services.AddTransient<EnvioEmail>();
            builder.Services.AddTransient<Menu>();
            builder.Services.AddTransient<RecuperarSenha>();

#endif

            return builder.Build();
        }
    }
}
