using CommunityToolkit.Maui;
using Plugin.Maui.Audio;

namespace JUEGOCONEJITOSMAGICOS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // ------------------------------------------------------------
            // SERVICIOS DE LA APP (se crean una sola vez para toda la sesion)
            // - AudioManager: paquete Plugin.Maui.Audio (reproduce mp3)
            // - AudioService: musica de fondo
            // - NarrationService: voz de los cuentos (mp3 o voz del sistema)
            // - ProgresoService: puntos, logros y preferencias del jugador
            // ------------------------------------------------------------
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddSingleton<AudioService>();
            builder.Services.AddSingleton<NarrationService>();
            builder.Services.AddSingleton<ProgresoService>();

            return builder.Build();
        }
    }
}
