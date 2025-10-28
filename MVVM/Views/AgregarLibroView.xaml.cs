using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace AppLibros.MVVM.Views
{
    /// <summary>
    /// Lógica de interacción para AgregarLibroView.xaml
    /// </summary>
    public partial class AgregarLibroView : Page
    {
        public AgregarLibroView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if(dialog.ShowDialog() == true)
            {
                //Obtener la ruta de la imagen seleccionada
                string rutaImagen = dialog.FileName;
                //Cargar la imagen en el Image control
                BitmapImage bitmap = new BitmapImage(new Uri(rutaImagen));
                // Recuperamos el ViewModel de la propiedad DataContext
                // de nuestra vista y le asignamos la nueva ruta de portada
                var viewModel = (LibrosViewModel)this.DataContext;
                viewModel.NuevaRutaPortada = bitmap;
            }
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
                // Solo tomamos el primer archivo si se arrastraron varios
                if (archivos.Length != 0)
                {
                    string rutaImagen = archivos[0];
                    //Cargar la imagen en el Image control
                    string extension = System.IO.Path.GetExtension(rutaImagen).ToLower();
                    if(extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp" || extension == ".gif")
                    {
                        BitmapImage bitmap = new BitmapImage(new Uri(rutaImagen));
                        // Recuperamos el ViewModel de la propiedad DataContext
                        // de nuestra vista y le asignamos la nueva ruta de portada
                        var viewModel = (LibrosViewModel)this.DataContext;
                        viewModel.NuevaRutaPortada = bitmap;
                    }
                }
            }
        }
    }
}
