namespace APIHotel.Modelo
{
    public class ReservaHabitacionMOD
    {
        public long ReservaHabitacionID { get; set; }
        public long ClienteID { get; set; }
        public long HabitacionID { get; set; }
        public long EmpleadoID { get; set; }
        public long AgenciaID { get; set; }
        public long EstatusReservaID { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}
