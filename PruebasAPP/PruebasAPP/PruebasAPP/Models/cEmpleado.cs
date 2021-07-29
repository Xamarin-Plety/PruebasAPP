using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PruebasAPP.Models
{
    public class cSession
    {
        public int iIdEmpleado { get; set; }
        public int iPassword { get; set; }
    }
    public class cEmpleado
    {
        public int iIdFolioPersona { get; set; }
        public int iIdCentro { get; set; }
        public string Centro { get; set; }
        public int iIdEmpleado { get; set; }
        public string sNombreCompleto { get; set; }
        public decimal Vales { get; set; }
        public string sDireccion { get; set; }
        public string sColonia { get; set; }
        public string sCP { get; set; }
        public int iIdCiudad { get; set; }
        public string Ciudad { get; set; }
        public DateTime dtFechaNacimiento { get; set; }
        public string iTipoPersona { get; set; }
        public string sRFC { get; set; }
        public string sCURP { get; set; }
        public string sTelefono1 { get; set; }
        public string sTelefono2 { get; set; }
        public string sCorreoElectronico { get; set; }
        public string sEstatus { get; set; }
        public Byte[] imFotografia { get; set; }
        public DateTime dtFechaIngreso { get; set; }
        public int iIdTabPrestacion { get; set; }
        public string sDesPrestacion { get; set; }
        public string sIMSS { get; set; }
        public string sCtaBco { get; set; }
        public DateTime dtUltimaFechaAct { get; set; }
        public int iUMF { get; set; }
        public bool bIndPagHrExtra { get; set; }
        public bool bIndRegChec { get; set; }
        public bool bIndReplicaRegistro { get; set; }

        public ImageSource imgPerfil { get; set; }

        public StreamImageSource simPerfil { get; set; }

        public void SaveToDisk(string imageFileName, byte[] imageAsBase64String)
        {
            Xamarin.Essentials.Preferences.Set(imageFileName, Convert.ToBase64String(imageAsBase64String));
        }

        public Xamarin.Forms.ImageSource GetFromDisk(string imageFileName)
        {
            var imageAsBase64String = Xamarin.Essentials.Preferences.Get(imageFileName, string.Empty);

            return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(imageAsBase64String)));
        }
    }
}
