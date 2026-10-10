namespace JUEGOCONEJITOSMAGICOS
{
    /// <summary>
    /// Guarda el progreso del jugador durante la sesion:
    /// puntos de los juegos, logros desbloqueados y preferencias de sonido.
    /// </summary>
    public class ProgresoService
    {
        // ---- Puntos por juego ----
        public int PuntosEstrellas { get; set; }
        public int PuntosQuiz { get; set; }
        public int PuntosMemoria { get; set; }
        public int PuntosAdivina { get; set; }

        /// <summary>Suma de todos los puntos conseguidos.</summary>
        public int PuntosTotales =>
            PuntosEstrellas + PuntosQuiz + PuntosMemoria + PuntosAdivina;

        // ---- Preferencias de sonido ----
        public bool MusicaActivada { get; set; } = true;
        public double VolumenMusica { get; set; } = 0.3;

        // ---- Logros ----
        public List<string> Logros { get; } = new();

        /// <summary>Anade un logro si todavia no lo tiene el jugador.</summary>
        public void DesbloquearLogro(string nombreLogro)
        {
            if (!Logros.Contains(nombreLogro))
                Logros.Add(nombreLogro);
        }
    }
}
