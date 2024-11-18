using System;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.Win32.SafeHandles;
using ProyectoTallerBruto;

namespace ProyectoTallerAvalonia;

public partial class WindowCoches : Window
{
    
    private GarajeCoches garaje;
    private string nomArch;
    
    /// <summary>
    /// Inicializa los elementos y crea un garaje vacío junto con un nombre de archivo vacío
    /// </summary>
    public WindowCoches()
    {
        InitializeComponent();
        garaje = new GarajeCoches();
        nomArch = "";
        this.CargarMenu();
    }

    /// <summary>
    /// Cierra la ventana de gestión de coches
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    public void OnClickSalir(object sender, RoutedEventArgs routedEventArgs)
    {
        this.Close();
    }

    /// <summary>
    /// Crea el menú para la carga de archivos
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    public void OnClickCargarArchivo(object sender, RoutedEventArgs routedEventArgs)
    {
        MainStack.Children.Clear();
        var menu = MainStack;
        var texto = new Label
        {
            Content = "Inserte nombre del archivo a cargar:\n",
        };
        var textbox = new TextBox
        {
            Watermark = "Nombre del archivo:"
        };
        var btnCargar = new Button
        {
            Content = "Cargar archivo",
            Width = 300,
            Height = 30
        };
        var btnSalir = new Button
        {
            Content = "Salir",
            Width = 300,
            Height = 30
        };
        
        btnCargar.Click += (o, args) => OnClickCargar(o,args,textbox);
        btnSalir.Click += (o, args) => CargarMenu();
        
        menu.Children.Add(texto);
        menu.Children.Add(textbox);
        menu.Children.Add(btnCargar);
        menu.Children.Add(btnSalir);
    }

    /// <summary>
    /// En caso de que el nombre pasado como parametro @textbox este vacío o no se encuentre el fichero con ese nombre
    /// se muestra un mensaje en el label de errores, en caso de que si exista se añade a el garaje de coches los coches que
    /// estean en el archivo y se cambia el nombre del archivo a el pasado como parametro @textbox.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    /// <param name="textbox"></param>
    public void OnClickCargar(object sender, RoutedEventArgs routedEventArgs, TextBox textbox)
    {
        if (string.IsNullOrEmpty(textbox.Text))
        {
            Errores.Content = "Ingrese un nombre de archivo";
        }
        else
        {
            try
            {
                string filePath = textbox.Text;
                
                if (!File.Exists(filePath))
                {
                    Errores.Content = "El archivo especificado no existe. Verifique la ruta.";
                }
                else
                {
                    GarajeCoches gar = ArchivoCochesXML.Recuperar(filePath);
                    garaje.AddRange(gar.Coches);
                    this.nomArch = filePath;
                    Errores.Content = "Archivo cargado correctamente";
                    CargarMenu();
                }
            }
            catch (Exception ex)
            {
                Errores.Content = $"Error al cargar el archivo: {ex.Message}";
            }
        }
    }
    
    /// <summary>
    /// Crea el menú para guardar el archivo, en caso de que ya exista un nombre de archivo
    /// porque ya se ha cargado uno se guarda directamente en este archivo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    public void OnClickGuardarArchivo(object sender, RoutedEventArgs routedEventArgs)
    {
        if (nomArch == "")
        {
            MainStack.Children.Clear();
            var menu = MainStack;
            var texto = new Label
            {
                Content = "Inserte nombre del archivo a guardar:\n",
            };
            var textbox = new TextBox
            { 
                Watermark = "Nombre del archivo:"
            };
            var btnCargar = new Button
            {
                Content = "Guardar archivo",
                Width = 300,
                Height = 30
            };
            var btnSalir = new Button
            {
                Content = "Salir",
                Width = 300,
                Height = 30
            };
                    
            btnCargar.Click += (o, args) => OnClickGuardar(o,args,textbox);
            btnSalir.Click += (o, args) => CargarMenu();
                    
            menu.Children.Add(texto);
            menu.Children.Add(textbox);
            menu.Children.Add(btnCargar);
            menu.Children.Add(btnSalir);
        }
        else
        {
            ArchivoCochesXML x = new ArchivoCochesXML(garaje);
            x.Guardar(nomArch);
            Errores.Content = "Se ha guardado el archivo";
        }
    }

    /// <summary>
    /// En caso de que no exista un nombre de archivo y no se ingrese uno, se emite un error
    /// en caso contrario se guarda el fichero con el nombre especificado.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    /// <param name="textbox"></param>
    public void OnClickGuardar(object sender, RoutedEventArgs routedEventArgs, TextBox textbox)
    {
        if (string.IsNullOrEmpty(textbox.Text))
        {
            Errores.Content = "Ingrese un nombre de archivo";
        }
        else
        {
            try
            {
                ArchivoCochesXML x = new ArchivoCochesXML(garaje);
                x.Guardar(textbox.Text);
                nomArch = textbox.Text;
                Errores.Content = "Se ha guardado el archivo";
                CargarMenu();
            }
            catch (Exception ex)
            {
                Errores.Content = $"Error al cargar el archivo: {ex.Message}";
            }
        }
    }

    /// <summary>
    /// Crea el menu para añadir un coche al garaje
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    public void OnClickAnhadirMenu(object sender, RoutedEventArgs routedEventArgs)
    {
        MainStack.Children.Clear();
        var menu = MainStack;
        
        var tit = new Label
        {
            Content = "Seleccione la marca:",
        };
        var opciones = Enum.GetValues(typeof(Coche.Marcas)).Cast<Coche.Marcas>().ToList();
        var marca = new ComboBox
        {
            Width = 200,
            ItemsSource = opciones,
        };
        var modelo = new TextBox
        {
            Watermark = "Modelo:",
        };
        var matricula = new TextBox
        {
            Watermark = "Matricula:",
        };
        
        var btnGuardar = new Button
        {
            Content = "Guardar coche",
            Width = 300,
            Height = 30
        };
        
        var btnSalir = new Button
        {
            Content = "Salir",
            Width = 300,
            Height = 30
        };
        
        btnSalir.Click += (o, args) => CargarMenu();
        btnGuardar.Click += (o, args) => OnClickGuardarCoche(marca.SelectedItem, modelo.Text, matricula.Text);
        
        menu.Children.Add(tit);
        menu.Children.Add(marca);
        menu.Children.Add(modelo);
        menu.Children.Add(matricula);
        menu.Children.Add(btnGuardar);
        menu.Children.Add(btnSalir);

    }
    
    /// <summary>
    /// Comprueba que los parametros no estean vacíos al crear un nuevo coche, si lo están muestra
    /// un mensaje de error en el label de errores, en caso de que no estean vacíos, crea el coche y lo
    /// añade al garaje.
    /// </summary>
    /// <param name="marca"></param>
    /// <param name="modelo"></param>
    /// <param name="matricula"></param>
    public void OnClickGuardarCoche(Object marca, string modelo, string matricula)
    {
        if (marca == null || modelo == "" || modelo == null || matricula == "" || matricula == null)
        {
            Errores.Content = "Por favor rellene todos los campos";
        }
        else
        {
            Coche.Marcas marcConcreta = Enum.Parse<Coche.Marcas>(marca.ToString());
            Coche c = new Coche(matricula , marcConcreta, modelo);
            this.garaje.Add(c);
            CargarMenu();
        }
    }
    
    
    /// <summary>
    /// Comprueba que el campo de la matricula a eliminar no estea vacío, si lo esta muestra un mensaje de error,
    /// en caso de que la matricula no este entre la lista de coches tambien muestra un mensaje de error, y si esta
    /// está entre los coches, elimina el coche y muestra el menu principal.
    /// </summary>
    /// <param name="matricula"></param>
    public void OnClickEliminarCoche(String matricula)
    {
        if (matricula == "" || matricula == null)
        {
            Errores.Content = "La matricula a eliminar no puede estar vacía";
        }
        else
        {
            bool eliminado = garaje.RemoveMatricula(matricula);
            if (eliminado == true)
            {
                CargarMenu();
            }
            else
            {
                Errores.Content = "La matricula no se encuentra en los coches del garaje";
            }
        }
    }
    
    /// <summary>
    /// Carga el menu necesario para la eliminación de un coche según su matricula
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    public void OnClickEliminar(object sender, RoutedEventArgs routedEventArgs)
    {
        MainStack.Children.Clear();
        var menu = MainStack;

        var label = new Label
        {
            Content = "Matricula a eliminar: ",
        };
        var matr = new TextBox
        {
            Watermark = "Matricula:",
        };
        
        var btnEliminar = new Button
        {
            Content = "Eliminar coche",
            Width = 300,
            Height = 30
        };
        
        var btnSalir = new Button
        {
            Content = "Salir",
            Width = 300,
            Height = 30
        };
        
        btnEliminar.Click += (o, args) => OnClickEliminarCoche(matr.Text);
        btnSalir.Click += (o, args) => CargarMenu();
        
        menu.Children.Add(label);
        menu.Children.Add(matr);
        menu.Children.Add(btnEliminar);
        menu.Children.Add(btnSalir);
        
    }

    /// <summary>
    /// Muestra un menu donde introducir la matricula del coche a modificar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    public void OnClickModificar(object sender, RoutedEventArgs routedEventArgs)
    {
        MainStack.Children.Clear();
        var menu = MainStack;

        var label = new Label
        {
            Content = "Matricula del coche a modificar: ",
        };
        var matr = new TextBox
        {
            Watermark = "Matricula:",
        };
        
        var btnModificar = new Button
        {
            Content = "Modificar coche",
            Width = 300,
            Height = 30
        };
        
        var btnSalir = new Button
        {
            Content = "Salir",
            Width = 300,
            Height = 30
        };
        
        btnModificar.Click += (o, args) => OnClickModificarCoche(matr.Text);
        btnSalir.Click += (o, args) => CargarMenu();
        
        menu.Children.Add(label);
        menu.Children.Add(matr);
        menu.Children.Add(btnModificar);
        menu.Children.Add(btnSalir);
    }

    /// <summary>
    /// Comprueba que la matricula a modificar no estea vacía o se nula, en caso de que lo sea muestra un error,
    /// en caso contrario carga el formulario para modificar el coche con esa matricula.
    /// </summary>
    /// <param name="matricula"></param>
    public void OnClickModificarCoche(String matricula)
    {
        
        if (matricula == "" || matricula == null)
        {
            Errores.Content = "La matricula no puede estar vacía";
        }
        else
        {
            if (garaje.GetMatricula(matricula) == null)
            {
                Errores.Content = "No existe un coche con dicha matricula";
            }
            else
            {
                FormModificarMatricula(matricula);
            }
        }
        
    }

    /// <summary>
    /// Carga el menu necesario para modificar una matricula
    /// </summary>
    /// <param name="matricula"></param>
    public void FormModificarMatricula(String matricula)
    {
        MainStack.Children.Clear();
        var menu = MainStack;
        
        Coche c = garaje.GetMatricula(matricula);
        
        var matr = new TextBox
        {
            Watermark = c.Matricula,
        };
        
        var btnMod = new Button
        {
            Content = "Modificar matricula",
            Width = 300,
            Height = 30
        };
        
        var btnSalir = new Button
        {
            Content = "Salir",
            Width = 300,
            Height = 30
        };
        
        btnMod.Click += (o, args) => OnClickModCoche(matr.Text, matricula);
        btnSalir.Click += (o, args) => CargarMenu();
        
        menu.Children.Add(matr);
        menu.Children.Add(btnMod);
        menu.Children.Add(btnSalir);
    }

    /// <summary>
    /// Comprueba que la matricula nueva no sea vacía para ca,biarla por la anterior
    /// </summary>
    /// <param name="matNueva"></param>
    /// <param name="matAnt"></param>
    public void OnClickModCoche(String matNueva, String matAnt)
    {
        if (matNueva == "" || matNueva == null)
        {
            Errores.Content = "Ingrese la nueva matricula";
        }
        else
        {
            if (garaje.ModificarMatricula(matAnt, matNueva))
            {
                CargarMenu();
            }
            else
            {
                Errores.Content = "Error al modificar la matricula";
            }
        }
 
    }
    
    /// <summary>
    /// Crea la nnueva ventana donde se mostrara la información de los coches
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="routedEventArgs"></param>
    public async void OnClickMostrar(object sender, RoutedEventArgs routedEventArgs)
    {
        var data = new WindowCochesDatagrid(this.garaje);
        await data.ShowDialog(this);
    }
    
    /// <summary>
    /// Crea el menu base de gestion de coches
    /// </summary>
    public void CargarMenu()
    {
        Errores.Content = "";
        MainStack.Children.Clear();
        var menu = MainStack;
        var titulo = new Label
        {
            Content = "Gestión del garaje de vehículos:\n",
        };
        menu.Children.Add(titulo);
        
        var btnAñadir = new Button
        {
            Content = "Añadir un coche al garaje",
            Width = 350,
            Height = 30
        };
        
        var btnEliminarMatricula = new Button
        {
            Content = "Eliminar un coche del garaje",
            Width = 350,
            Height = 30
        };
        
        var btnModificarMatricula = new Button
        {
            Content = "Modificar la matricula de un coche",
            Width = 350,
            Height = 30
        };
        
        var btnGuardar = new Button
        {
            Content = "Guardar la información de los coches",
            Width = 350,
            Height = 30
        };
        
        var btnRecuperar = new Button
        {
            Content = "Recuperar la información de un archivo",
            Width = 350,
            Height = 30
        };
        
        var btnMostrar = new Button
        {
            Content = "Mostrar coches del garaje",
            Width = 350,
            Height = 30
        };
        
        var btnCancelar = new Button
        {
            Content = "Salir (se perderán los cambios no guardados)",
            Width = 350,
            Height = 30
        };
        
        btnAñadir.Click += (o, args) => OnClickAnhadirMenu(o, args);
        btnEliminarMatricula.Click += (o, args) => OnClickEliminar(o, args);
        btnModificarMatricula.Click += (o, args) => OnClickModificar(o, args);
        btnMostrar.Click += (o, args) => OnClickMostrar(o, args);
        btnCancelar.Click += (o, args) => OnClickSalir(o,args);
        btnRecuperar.Click += (o, args) => OnClickCargarArchivo(o, args);
        btnGuardar.Click += (o, args) => OnClickGuardarArchivo(o, args);
        
        
        
        menu.Children.Add(btnAñadir);
        menu.Children.Add(btnEliminarMatricula);
        menu.Children.Add(btnModificarMatricula);
        menu.Children.Add(btnMostrar);
        menu.Children.Add(btnGuardar);
        menu.Children.Add(btnRecuperar);
        menu.Children.Add(btnCancelar);
        
    }
    
}