using Plugin.Maui.Audio;

namespace JUEGOCONEJITOSMAGICOS
{
    /// <summary>
    /// Controla la musica de fondo del juego.
    /// Permite reproducir pistas en bucle, cambiar de pista al navegar
    /// entre secciones, silenciar todo y ajustar el volumen.
    /// </summary>
    public class AudioService
    {
        private readonly IAudioManager _audioManager;
        private IAudioPlayer? _bgmPlayer;
        private string? _pistaActual;

        /// <summary>Si esta en falso, ninguna musica de fondo se reproduce.</summary>
        public bool MusicaActivada { get; set; } = true;

        /// <summary>Volumen de la musica de fondo (0.0 a 1.0).</summary>
        public double Volumen { get; set; } = 0.3;

        public AudioService(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        /// <summary>
        /// Reproduce una pista en bucle. Si la pista indicada ya se esta
        /// reproduciendo, no hace nada (evita reiniciar la musica).
        /// </summary>
        public async Task PlayBackgroundMusicAsync(string fileName)
        {
            if (!MusicaActivada) return;
            if (_pistaActual == fileName && _bgmPlayer?.IsPlaying == true) return;

            try
            {
                _bgmPlayer?.Stop();
                var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
                _bgmPlayer = _audioManager.CreatePlayer(stream);
                _bgmPlayer.Loop = true;
                _bgmPlayer.Volume = Volumen;
                _bgmPlayer.Play();
                _pistaActual = fileName;
            }
            catch (FileNotFoundException)
            {
                // La pista no existe en Resources\Raw; no rompemos la app.
            }
        }

        /// <summary>Detiene la musica de fondo actual.</summary>
        public void StopBackgroundMusic()
        {
            _bgmPlayer?.Stop();
            _pistaActual = null;
        }

        /// <summary>Cambia el volumen en tiempo real y lo recuerda.</summary>
        public void AjustarVolumen(double nuevoVolumen)
        {
            Volumen = Math.Clamp(nuevoVolumen, 0.0, 1.0);
            if (_bgmPlayer != null)
                _bgmPlayer.Volume = Volumen;
        }
    }
}
