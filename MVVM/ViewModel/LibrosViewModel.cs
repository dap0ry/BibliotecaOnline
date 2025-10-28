using AppLibros.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AppLibros.MVVM
{
    class LibrosViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Libro> Libros { get; set; }

        private Libro _libroSeleccionado;

        private string _nuevoTitulo;
        private string _nuevoAutor;
        private string _nuevoGenero;
        private string _nuevoAnioPublicacion;
        private BitmapImage _nuevaRutaPortada;

        public ICommand AgregarLibroCommand { get; }

        public LibrosViewModel()
        {
            Libros = new ObservableCollection<Libro>
            {
                new Libro { Titulo = "Cien Años de Soledad", Autor = "Gabriel García Márquez", Genero = "Realismo Mágico", AnioPublicacion = 1967, RutaPortada = new BitmapImage(new Uri("/Imagenes/portada_cien_anos_de_soledad.jpg",UriKind.Relative)) },
                new Libro { Titulo = "1984", Autor = "George Orwell", Genero = "Distopía", AnioPublicacion = 1949, RutaPortada = new BitmapImage(new Uri("/Imagenes/1984.jpg",UriKind.Relative)) },
                new Libro { Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", Genero = "Fantasía", AnioPublicacion = 1943, RutaPortada = new BitmapImage(new Uri("/Imagenes/el-principito.jpg",UriKind.Relative)) },
                new Libro { Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", Genero = "Aventura", AnioPublicacion = 1605, RutaPortada = new BitmapImage(new Uri("/Imagenes/don-quijote.jpg", UriKind.Relative)) },
                new Libro { Titulo = "La Sombra del Viento", Autor = "Carlos Ruiz Zafón", Genero = "Misterio", AnioPublicacion = 2001, RutaPortada = new BitmapImage(new Uri("/Imagenes/lasombradelviento.jpg", UriKind.Relative)) },
                new Libro { Titulo = "Fahrenheit 451", Autor = "Ray Bradbury", Genero = "Ciencia Ficción", AnioPublicacion = 1953, RutaPortada = new BitmapImage(new Uri("/Imagenes/fahrenheit451.jpg", UriKind.Relative)) },
                new Libro { Titulo = "Orgullo y Prejuicio", Autor = "Jane Austen", Genero = "Romance", AnioPublicacion = 1813, RutaPortada = new BitmapImage(new Uri("/Imagenes/orgulloyprejuicio.jpg", UriKind.Relative)) },
                new Libro { Titulo = "El Alquimista", Autor = "Paulo Coelho", Genero = "Filosofía", AnioPublicacion = 1988, RutaPortada = new BitmapImage(new Uri("/Imagenes/elalquimista.jpg", UriKind.Relative)) }
            };
            //Agregamos nuestra funcion de agregar libro al comando
            //Para que el boton lo pueda usar
            AgregarLibroCommand = new RelayCommand(AgregarLibro);
        }

        public List<string> Autores
        {
            get
            {
                //FORMA RAPIDA CON LINQ, SELECCIONANDO LOS AUTORES DISTINTOS
                //Select 
                return Libros.Select(libro => libro.Autor).Distinct().ToList();
                //FORMA TRADICIONAL
                List<string> autores = new List<string>();
                foreach (var libro in Libros)
                {
                    if (!autores.Contains(libro.Autor))
                    {
                        autores.Add(libro.Autor);
                    }
                }
                return autores;
                
            }
        }

        public Libro LibroSeleccionado
        {
            get { return _libroSeleccionado; }
            set
            {
                _libroSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public String NuevoTitulo
        {
            get { return _nuevoTitulo; }
            set
            {
                _nuevoTitulo = value;
                OnPropertyChanged();
            }
        }

        public String NuevoAutor
        {
            get { return _nuevoAutor; }
            set
            {
                _nuevoAutor = value;
                OnPropertyChanged();
            }
        }

        public String NuevoGenero
        {
            get { return _nuevoGenero; }
            set
            {
                _nuevoGenero = value;
                OnPropertyChanged();
            }
        }

        public string NuevoAnioPublicacion
        {
            get { return _nuevoAnioPublicacion; }
            set
            {
                _nuevoAnioPublicacion = value;
                OnPropertyChanged();
            }
        }

        public BitmapImage NuevaRutaPortada
        {
            get { return _nuevaRutaPortada; }
            set
            {
                _nuevaRutaPortada = value;
                OnPropertyChanged();
            }
        }

        public void AgregarLibro(object parameter)
        {
            Libro nuevoLibro = new Libro
            {
                Titulo = NuevoTitulo,
                Autor = NuevoAutor,
                Genero = NuevoGenero,
                AnioPublicacion = int.Parse(NuevoAnioPublicacion),
                RutaPortada = NuevaRutaPortada
            };
            Libros.Add(nuevoLibro);
            NuevoAnioPublicacion = string.Empty;
            NuevoAutor = string.Empty;
            NuevoGenero = string.Empty;
            NuevoTitulo = string.Empty;
            NuevaRutaPortada = null;
            OnPropertyChanged();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
