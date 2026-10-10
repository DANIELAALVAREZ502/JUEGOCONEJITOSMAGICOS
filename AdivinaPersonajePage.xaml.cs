namespace JUEGOCONEJITOSMAGICOS;

public partial class AdivinaPersonajePage : ContentPage
{
    private bool _acertado;

    public AdivinaPersonajePage()
    {
        InitializeComponent();
    }

    // Musica de fondo del juego
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_aventura.mp3");
    }

    // Comprueba si la opcion elegida es la correcta
    private async void OnOpcionClicked(object? sender, EventArgs e)
    {
        if (_acertado) return;
        if (sender is not Button btn) return;

        if (btn.Text == "Sabio Buho")
        {
            _acertado = true;
            App.Progreso.PuntosAdivina += 30;
            App.Progreso.DesbloquearLogro("Detective del Bosque");
            await DisplayAlertAsync("Correcto!", "El Sabio Buho es quien guarda la sabiduria del bosque.", "Genial");
        }
        else
        {
            await DisplayAlertAsync("No es correcto", "Sigue pensando... mira la pista con atencion.", "Intentar de nuevo");
        }
    }

    private async void OnVerLogrosClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(LogrosPage));
}
