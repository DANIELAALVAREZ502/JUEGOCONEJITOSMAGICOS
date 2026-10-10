namespace JUEGOCONEJITOSMAGICOS;

public partial class JuegosPage : ContentPage
{
    public JuegosPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de la zona de juegos
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_aventura.mp3");
    }

    private async void OnAtrapaClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(AtrapaEstrellasPage));

    private async void OnQuizClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(QuizPage));

    private async void OnMemoriaClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(MemoriaPage));

    private async void OnAdivinaClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(AdivinaPersonajePage));
}
