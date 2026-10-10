namespace JUEGOCONEJITOSMAGICOS;

public partial class AprendizajePage : ContentPage
{
    public AprendizajePage()
    {
        InitializeComponent();
    }

    // Musica de fondo de la seccion de aprendizaje
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_reflexion.mp3");
    }

    private async void OnCreditosClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(FinalPage));
}
