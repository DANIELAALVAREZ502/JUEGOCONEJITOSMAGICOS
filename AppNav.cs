using System.Windows.Input;

namespace JUEGOCONEJITOSMAGICOS;

// Comandos compartidos para los botones "Regresar" y "Avanzar"
// que aparecen en la barra inferior de todas las paginas.
public static class AppNav
{
    // Orden lineal de las pantallas para el boton "Avanzar".
    private static readonly Type[] Orden =
    {
        typeof(MainPage),
        typeof(PersonajesPage),
        typeof(AprendizajePage),
        typeof(HistoriasPage),
        typeof(Stories.Cuento01AmistadPage),
        typeof(Stories.Cuento02BuhoPage),
        typeof(Stories.Cuento03LiaPage),
        typeof(Stories.Cuento04PacienciaPage),
        typeof(Stories.Cuento05MariposasPage),
        typeof(Stories.Cuento06PerdonPage),
        typeof(Stories.Cuento07GratitudPage),
        typeof(Stories.Cuento08EscucharPage),
        typeof(Stories.Cuento09ConflictoPage),
        typeof(DecisionPage),
        typeof(ReflexionPage),
        typeof(ValoresPage),
        typeof(JuegosPage),
        typeof(AtrapaEstrellasPage),
        typeof(QuizPage),
        typeof(MemoriaPage),
        typeof(AdivinaPersonajePage),
        typeof(LogrosPage),
        typeof(MusicaPage),
        typeof(FinalPage),
    };

    // Vuelve a la pagina anterior; si no hay historial, va al inicio.
    public static ICommand Regresar { get; } = new Command(async () =>
    {
        if (Shell.Current is null) return;

        var pila = Shell.Current.Navigation.NavigationStack;
        if (pila is not null && pila.Count > 1)
            await Shell.Current.GoToAsync("..");
        else
            await Shell.Current.GoToAsync("//MainPage");
    });

    // Avanza a la siguiente pagina del recorrido.
    public static ICommand Avanzar { get; } = new Command(async () =>
    {
        if (Shell.Current?.CurrentPage is not { } actual) return;

        var indice = Array.IndexOf(Orden, actual.GetType());
        var siguiente = indice < 0
            ? typeof(MainPage)
            : Orden[(indice + 1) % Orden.Length];

        if (siguiente == typeof(MainPage))
            await Shell.Current.GoToAsync("//MainPage");
        else
            await Shell.Current.GoToAsync(siguiente.Name);
    });
}
