namespace JUEGOCONEJITOSMAGICOS;

public partial class MemoriaPage : ContentPage
{
    // Tablero sencillo: 2 parejas (Nala/Tambor alternados)
    private readonly string[] _parejas = { "nala1.png", "tambor1.png", "nala1.png", "tambor1.png" };
    private const string Dorso = "estrella_magica.png";

    private int _primerIndice = -1;
    private int _intentos;
    private bool _logroMostrado;

    public MemoriaPage()
    {
        InitializeComponent();
    }

    // Musica de fondo del juego de memoria
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_aventura.mp3");
    }

    private async void OnCardClicked(object? sender, EventArgs e)
    {
        if (sender is not ImageButton btn) return;
        if (!int.TryParse(btn.ClassId, out int indice)) return;
        if (indice < 0 || indice >= _parejas.Length) return;
        if (!btn.IsEnabled) return;

        // Voltea la carta mostrando al personaje
        btn.Source = _parejas[indice];
        btn.IsEnabled = false;

        if (_primerIndice == -1)
        {
            _primerIndice = indice;
            return;
        }

        // Compara con la primera carta
        _intentos++;
        LblIntentos.Text = $"Intentos: {_intentos}";
        App.Progreso.PuntosMemoria = Math.Max(0, 100 - _intentos * 5);

        int primerIndice = _primerIndice;
        _primerIndice = -1;

        if (_parejas[primerIndice] == _parejas[indice])
        {
            // Pareja encontrada
            await DisplayAlertAsync("Muy bien!", "Encontraste una pareja.", "OK");

            if (!_logroMostrado && _intentos <= 6)
            {
                _logroMostrado = true;
                App.Progreso.DesbloquearLogro("Memoria Magica");
                await DisplayAlertAsync("Logro desbloqueado!", "Conseguiste: Memoria Magica", "OK");
            }
        }
        else
        {
            // No coinciden: vuelve a ocultarlas
            await Task.Delay(800);
            var btn1 = GetButton(primerIndice);
            var btn2 = GetButton(indice);
            if (btn1 != null) { btn1.Source = Dorso; btn1.IsEnabled = true; }
            if (btn2 != null) { btn2.Source = Dorso; btn2.IsEnabled = true; }
        }
    }

    // Busca el boton por su ClassId
    private ImageButton? GetButton(int indice)
    {
        return indice switch
        {
            0 => Btn1,
            1 => Btn2,
            2 => Btn3,
            3 => Btn4,
            _ => null
        };
    }

    private async void OnVerLogrosClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(LogrosPage));
}
