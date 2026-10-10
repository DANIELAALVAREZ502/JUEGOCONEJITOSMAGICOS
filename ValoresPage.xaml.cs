namespace JUEGOCONEJITOSMAGICOS;

public partial class ValoresPage : ContentPage
{
    public ValoresPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de la seccion "Valores"
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_bosque.mp3");
    }

    // Voz que explica los valores
    private async void OnNarrarClicked(object? sender, EventArgs e)
    {
        await App.NarrationService.PlayNarrationAsync(
            "narracion_valores.mp3",
            "Los valores magicos del bosque son la gratitud, el respeto y la solidaridad. " +
            "Agradece cada pequeno gesto, respeta a tus amigos y ayuda a quien lo necesita.");
    }

    private void OnStopClicked(object? sender, EventArgs e)
        => App.NarrationService.StopNarrationAsync();

    private async void OnAprenderClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(AprendizajePage));
}
