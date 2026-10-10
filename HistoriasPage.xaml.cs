namespace JUEGOCONEJITOSMAGICOS;

public partial class HistoriasPage : ContentPage
{
    public HistoriasPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de la seccion "Historias"
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_bosque.mp3");
    }

    // Abre cada cuento narrado
    private async void OnCuento1Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento01AmistadPage));

    private async void OnCuento2Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento02BuhoPage));

    private async void OnCuento3Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento03LiaPage));

    private async void OnCuento4Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento04PacienciaPage));

    private async void OnCuento5Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento05MariposasPage));

    private async void OnCuento6Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento06PerdonPage));

    private async void OnCuento7Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento07GratitudPage));

    private async void OnCuento8Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento08EscucharPage));

    private async void OnCuento9Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(Stories.Cuento09ConflictoPage));
}
