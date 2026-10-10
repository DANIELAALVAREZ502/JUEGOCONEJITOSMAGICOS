namespace JUEGOCONEJITOSMAGICOS;

public partial class MusicaPage : ContentPage
{
    public MusicaPage()
    {
        InitializeComponent();
        SliderVolumen.Value = App.AudioService.Volumen;
        ActualizarEstado();
    }

    // Recarga el estado del boton al aparecer
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ActualizarEstado();
    }

    // Activa / desactiva la musica de fondo
    private void OnToggleMusicaClicked(object? sender, EventArgs e)
    {
        if (App.AudioService.MusicaActivada)
        {
            App.AudioService.MusicaActivada = false;
            App.AudioService.StopBackgroundMusic();
        }
        else
        {
            App.AudioService.MusicaActivada = true;
            _ = App.AudioService.PlayBackgroundMusicAsync("musica_inicio.mp3");
        }
        ActualizarEstado();
    }

    // Ajusta el volumen de la musica de fondo
    private void OnVolumenCambiado(object? sender, ValueChangedEventArgs e)
    {
        App.AudioService.AjustarVolumen(e.NewValue);
    }

    private void ActualizarEstado()
    {
        if (App.AudioService.MusicaActivada)
        {
            EstadoMusica.Text = "Musica: Activada";
            BtnMusica.Text = "Silenciar";
        }
        else
        {
            EstadoMusica.Text = "Musica: Desactivada";
            BtnMusica.Text = "Activar";
        }
    }
}
