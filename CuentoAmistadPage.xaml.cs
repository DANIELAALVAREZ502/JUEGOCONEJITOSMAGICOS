namespace JUEGOCONEJITOSMAGICOS;

public partial class CuentoAmistadPage : ContentPage
{
    public CuentoAmistadPage()
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
            "narracion_amistad.mp3",
            "Una tarde, Nala encontro un sendero lleno de flores brillantes. " +
            "Tambor, su mejor amigo, tenia miedo de cruzar el rio. Nala lo tomo de la mano " +
            "y le dijo: juntos podemos con todo. Atravesaron el bosque cantando y demostraron " +
            "que la amistad hace mas liviano cualquier camino.");
    }

    private void OnStopClicked(object? sender, EventArgs e)
        => App.NarrationService.StopNarrationAsync();

    private async void OnReflexionarClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(ReflexionPage));
}
