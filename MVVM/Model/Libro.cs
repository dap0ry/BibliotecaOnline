using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AppLibros.MVVM.Model
{
    class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int AnioPublicacion { get; set; }
        public BitmapImage RutaPortada { get; set; }
    }
}
