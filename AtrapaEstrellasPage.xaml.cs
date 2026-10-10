namespace JUEGOCONEJITOSMAGICOS;

public partial class AtrapaEstrellasPage : ContentPage
{
    private bool _logroMostrado;

    public AtrapaEstrellasPage()
    {
        InitializeComponent();
    }

    // Musica de fondo del juego
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_aventura.mp3");
    }

    // Cada clic suma 10 puntos y actualiza el marcador
    private async void OnEstrellaClicked(object? sender, EventArgs e)
    {
        App.Progreso.PuntosEstrellas += 10;
        LblPuntos.Text = $"Puntos: {App.Progreso.PuntosEstrellas}";

        // Logro al llegar a 50 puntos (se muestra una sola vez)
        if (!_logroMostrado && App.Progreso.PuntosEstrellas >= 50)
        {
            _logroMostrado = true;
            App.Progreso.DesbloquearLogro("Cazador de Estrellas");
            await DisplayAlertAsync("Logro desbloqueado!", "Conseguiste el logro: Cazador de Estrellas", "OK");
        }
    }

    private async void OnVerLogrosClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(LogrosPage));
}
