namespace JUEGOCONEJITOSMAGICOS
{
    public partial class App : Application
    {
        // Servicios accesibles desde cualquier pagina de la app
        public static AudioService AudioService { get; private set; } = null!;
        public static NarrationService NarrationService { get; private set; } = null!;
        public static ProgresoService Progreso { get; private set; } = null!;

        public App(AudioService audioService, NarrationService narrationService, ProgresoService progresoService)
        {
            InitializeComponent();

            // Guardamos los servicios inyectados para poder usarlos en todo el programa
            AudioService = audioService;
            NarrationService = narrationService;
            Progreso = progresoService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // El proyecto arranca en la pantalla de inicio (MainPage)
            return new Window(new AppShell());
        }
    }
}
