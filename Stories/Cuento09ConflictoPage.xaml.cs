namespace JUEGOCONEJITOSMAGICOS.Stories;

public partial class Cuento09ConflictoPage : ContentPage
{
    public Cuento09ConflictoPage()
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
            "narracion_conflicto.mp3",
            "Dos amiguitos del bosque querian el mismo juguete y empezaron a discutir. Tambor " +
            "les propuso hablar con calma y encontrar una solucion juntos. Descubrieron que " +
            "hablando con respeto todos pueden estar contentos.");
    }

    private void OnStopClicked(object? sender, EventArgs e)
        => App.NarrationService.StopNarrationAsync();

    private async void OnReflexionarClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(ReflexionPage));
}
