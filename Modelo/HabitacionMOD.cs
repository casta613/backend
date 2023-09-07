

namespace APIHotel.Modelo
{
    public class HabitacionMOD 
    {
        public long? HabitacionID { get; set; }
        public string Ubicacion { get; set; }
        public decimal? Precio { get; set; }
        public string? Descripcion { get; set; }
        public long? TipoHabitacionID { get; set; }
        public long? EstatusHabitacionID { get; set; }
    }
}
