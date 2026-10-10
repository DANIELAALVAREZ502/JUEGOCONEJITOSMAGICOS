namespace JUEGOCONEJITOSMAGICOS;

public partial class QuizPage : ContentPage
{
    private int _aciertos;
    private bool _logroMostrado;

    public QuizPage()
    {
        InitializeComponent();
        _aciertos = 0;
        LblAciertos.Text = $"Aciertos: {_aciertos}";
    }

    // Musica de fondo del quiz
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_aventura.mp3");
    }

    // Respuestas correctas
    private async void OnCorrect1(object? sender, EventArgs e)
        => await ResponderCorrecto(sender, "Dar las gracias es una muestra de gratitud.", "Siguiente");

    private async void OnCorrect2(object? sender, EventArgs e)
        => await ResponderCorrecto(sender, "Ayudar demuestra carino y solidaridad.", "Siguiente");

    private async void OnCorrect3(object? sender, EventArgs e)
        => await ResponderCorrecto(sender, "Compartir es una gran muestra de amabilidad.", "Finalizar");

    // Marca una respuesta correcta evitando contar dos veces la misma pregunta
    private async Task ResponderCorrecto(object? sender, string mensaje, string botonCerrar)
    {
        if (sender is Button boton)
        {
            if (!boton.IsEnabled) return;
            boton.IsEnabled = false;
        }

        _aciertos++;
        App.Progreso.PuntosQuiz = _aciertos * 20;
        LblAciertos.Text = $"Aciertos: {_aciertos}";

        await DisplayAlertAsync("Correcto!", mensaje, botonCerrar);

        if (!_logroMostrado && _aciertos >= 2)
        {
            _logroMostrado = true;
            App.Progreso.DesbloquearLogro("Genio de los Valores");
            await DisplayAlertAsync("Logro desbloqueado!", "Conseguiste: Genio de los Valores", "OK");
        }
    }

    // Respuesta incorrecta
    private async void OnWrong(object? sender, EventArgs e)
    {
        await DisplayAlertAsync("Intenta de nuevo", "Esa respuesta no es correcta. Piensa en los valores del bosque.", "OK");
    }

    private async void OnVerLogrosClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(LogrosPage));
}
