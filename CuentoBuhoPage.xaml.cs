namespace JUEGOCONEJITOSMAGICOS;

public partial class CuentoBuhoPage : ContentPage
{
    public CuentoBuhoPage()
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
            "narracion_buho.mp3",
            "En lo alto de un arbol centenario, el Sabio Buho observaba a los animales del bosque. " +
            "Les enseno que respetar a los demas es como cuidar un jardin: cada palabra amable es una " +
            "semilla, y el respeto florece cuando todos escuchan con el corazon.");
    }

    private void OnStopClicked(object? sender, EventArgs e)
        => App.NarrationService.StopNarrationAsync();

    private async void OnReflexionarClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(ReflexionPage));
}
