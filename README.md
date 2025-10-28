# Vista general del proyecto
![bb5f09ce41ba4b53d536fb55174028df.png](:/aca5f48e8296468dae0db760711673a4)
## 1. Carpetas principales y su rol
-  ``Imagenes``
	- Contiene imágenes que usa tu aplicación (portadas de libros, íconos, etc.).
	- Normalmente se agregan como Resource o Content en el proyecto.
-  ``MVVM``
	- Esta es la carpeta clave de tu patrón MVVM. Dentro tienes 3 subcarpetas:
- ``Model``
	- Aquí van tus clases de datos.
	- Por ejemplo, Libro.cs representa la entidad Libro: título, autor, precio, etc.
	- No contiene lógica de UI, solo propiedades y tal vez validaciones.
- ``ViewModel``
	- Contiene las clases que conectan la Vista (UI) con el Modelo.
	- ``LibrosViewModel.cs`` es la clase que expone datos y comandos para la vista de libros.
	- Aquí suele implementarse`` INotifyPropertyChanged`` para que la UI se actualice 
  automáticamente cuando cambian los datos.
	- También contiene comandos para botones, como agregar, eliminar o actualizar libros (usando ``RelayCommand``).
- ``Views``
	- Contiene las interfaces de usuario (XAML).
	- Cada View tiene un archivo``.xaml`` y su código detrás ``.xaml.cs.``
	- Ejemplos:
		- ``AgregarLibroView.xaml`` → ventana para agregar libros.
		- ``AutoresView.xaml`` → ventana/lista de autores.
		- ``LibrosView.xaml`` → ventana/lista de libros.

## 2. Archivos principales fuera de MVVM
### 1.  ``App.xaml / App.xaml.cs``
Punto de entrada de la aplicación.
Aquí se definen recursos globales, estilos, diccionarios de recursos y el ``StartupUri`` (la ventana inicial).
### 2.  ``MainWindow.xaml / MainWindow.xaml.cs``
Es la ventana principal de la app.
Aquí normalmente se cargan los Views dentro de algún contenedor (como un ContentControl) o se manejan menús/navegación.
### 3. ``RelayCommand.cs``
Clase que implementa ICommand.
Permite crear comandos reutilizables que se enlazan a botones en XAML.
Ejemplo: ``AgregarLibroCommand`` que ejecuta la lógica de agregar un libro cuando el usuario presiona un botón.
### 4. ``AssemblyInfo.cs``
Contiene metadatos de la aplicación (versión, autor, etc.).
Ya es menos usado en .NET Core/5+ porque muchas configuraciones se hacen en .csproj.
## 3. Flujo básico de la app
El usuario abre la app (``App.xaml`` → ``MainWindow.xaml``).
``MainWindow`` muestra la vista inicial ``(LibrosView``, por ejemplo).
La ``View`` se enlaza con un ``ViewModel`` (``LibrosViewModel``) mediante ``DataBinding``.
El ``ViewModel`` obtiene y gestiona los datos del ``Model`` (``Libro``).
Las acciones del usuario (``botones``, ``menús``) llaman a comandos (``RelayCommand``) en el ``ViewModel``.
Los ``cambios`` en el ``ViewModel`` se reflejan automáticamente en la UI gracias a ``INotifyPropertyChanged``.
