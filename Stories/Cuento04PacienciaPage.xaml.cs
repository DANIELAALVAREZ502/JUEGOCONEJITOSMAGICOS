namespace JUEGOCONEJITOSMAGICOS.Stories;

public partial class Cuento04PacienciaPage : ContentPage
{
    public Cuento04PacienciaPage()
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
            "narracion_paciencia.mp3",
            "Nala queria que las flores de su jardin crecieran de inmediato, pero el Sabio Buho " +
            "le recordo que las cosas mas bellas necesitan tiempo. Cada dia Nala regaba con " +
            "paciencia y, al fin, su jardin florecio lleno de color.");
    }

    private void OnStopClicked(object? sender, EventArgs e)
        => App.NarrationService.StopNarrationAsync();

    private async void OnReflexionarClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(ReflexionPage));
}
