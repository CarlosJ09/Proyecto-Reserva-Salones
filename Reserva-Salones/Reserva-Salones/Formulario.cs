//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reserva_Salones
{
    using System;
    using System.Collections.Generic;
    
    public partial class Formulario
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int IdSalon { get; set; }
        public int MaxPersonas { get; set; }
        public System.DateTime FechaReserva { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public System.TimeSpan TiempoReserva { get; set; }
        public int IdNombreSalon { get; set; }
        public string NombreSalon { get; set; }
    
        public virtual TipoSalon TipoSalon { get; set; }
    }
}
