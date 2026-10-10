namespace JUEGOCONEJITOSMAGICOS;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de la seccion "Inicio"
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_inicio.mp3");
    }

    // Navegacion hacia las demas secciones
    private async void OnPersonajesClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(PersonajesPage));

    private async void OnHistoriasClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(HistoriasPage));

    private async void OnValoresClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(ValoresPage));

    private async void OnJuegosClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(JuegosPage));

    private async void OnLogrosClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(LogrosPage));

    private async void OnSonidoClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(MusicaPage));

    private async void OnCreditosClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(FinalPage));
}
