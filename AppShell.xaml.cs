namespace JUEGOCONEJITOSMAGICOS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // ------------------------------------------------------------
            // RUTAS DE NAVEGACION
            // Todas las paginas se abren con
            // Shell.Current.GoToAsync(nameof(Pagina)) y se puede volver
            // con los botones Regresar/Avanzar (ver AppNav).
            // ------------------------------------------------------------
            Routing.RegisterRoute(nameof(PersonajesPage), typeof(PersonajesPage));
            Routing.RegisterRoute(nameof(HistoriasPage), typeof(HistoriasPage));
            Routing.RegisterRoute(nameof(ValoresPage), typeof(ValoresPage));
            Routing.RegisterRoute(nameof(JuegosPage), typeof(JuegosPage));

            Routing.RegisterRoute(nameof(Stories.Cuento01AmistadPage), typeof(Stories.Cuento01AmistadPage));
            Routing.RegisterRoute(nameof(Stories.Cuento02BuhoPage), typeof(Stories.Cuento02BuhoPage));
            Routing.RegisterRoute(nameof(Stories.Cuento03LiaPage), typeof(Stories.Cuento03LiaPage));
            Routing.RegisterRoute(nameof(Stories.Cuento04PacienciaPage), typeof(Stories.Cuento04PacienciaPage));
            Routing.RegisterRoute(nameof(Stories.Cuento05MariposasPage), typeof(Stories.Cuento05MariposasPage));
            Routing.RegisterRoute(nameof(Stories.Cuento06PerdonPage), typeof(Stories.Cuento06PerdonPage));
            Routing.RegisterRoute(nameof(Stories.Cuento07GratitudPage), typeof(Stories.Cuento07GratitudPage));
            Routing.RegisterRoute(nameof(Stories.Cuento08EscucharPage), typeof(Stories.Cuento08EscucharPage));
            Routing.RegisterRoute(nameof(Stories.Cuento09ConflictoPage), typeof(Stories.Cuento09ConflictoPage));
            Routing.RegisterRoute(nameof(DecisionPage), typeof(DecisionPage));
            Routing.RegisterRoute(nameof(ReflexionPage), typeof(ReflexionPage));
            Routing.RegisterRoute(nameof(AprendizajePage), typeof(AprendizajePage));
            Routing.RegisterRoute(nameof(AtrapaEstrellasPage), typeof(AtrapaEstrellasPage));
            Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage));
            Routing.RegisterRoute(nameof(MemoriaPage), typeof(MemoriaPage));
            Routing.RegisterRoute(nameof(AdivinaPersonajePage), typeof(AdivinaPersonajePage));
            Routing.RegisterRoute(nameof(LogrosPage), typeof(LogrosPage));
            Routing.RegisterRoute(nameof(MusicaPage), typeof(MusicaPage));
            Routing.RegisterRoute(nameof(FinalPage), typeof(FinalPage));
        }
    }
}
