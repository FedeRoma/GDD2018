using System;

namespace FrbaHotel.ABM_de_Regimen
{
    public class Regimen
    {
        public Int64 reg_id { get; set; }
        public string reg_desc { get; set; }
        public Decimal reg_precio { get; set; }
        public bool reg_habilitado { get; set; }

        public Regimen(Int64 codigo, String descripcion, Decimal precio, bool estado)
        {
            this.reg_id = codigo;
            this.reg_desc = descripcion;
            this.reg_precio = precio;
            this.reg_habilitado = estado;
        }
    }
}
