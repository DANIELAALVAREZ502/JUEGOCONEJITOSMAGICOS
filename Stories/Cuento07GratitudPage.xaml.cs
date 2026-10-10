namespace JUEGOCONEJITOSMAGICOS.Stories;

public partial class Cuento07GratitudPage : ContentPage
{
    public Cuento07GratitudPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de los cuentos
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_bosque.mp3");
    }

    // Reproduce la narracion del cuento (mp3 o voz IA del dispositivo)
    private async void OnNarrarClicked(object? sender, EventArgs e)
    {
        await App.NarrationService.PlayNarrationAsync(
            "narracion_gratitud.mp3",
            "Mila aprendio a dar las gracias por las pequenas cosas: el sol, las flores y la " +
            "compania de sus amigos. Cada noche pensaba en algo bueno del dia. Descubrio que la " +
            "gratitud llena el corazon de alegria.");
    }

    private void OnStopClicked(object? sender, EventArgs e)
        => App.NarrationService.StopNarrationAsync();

    private async void OnReflexionarClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(ReflexionPage));
}
