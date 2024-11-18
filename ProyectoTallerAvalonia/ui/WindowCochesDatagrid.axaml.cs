using System;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.Win32.SafeHandles;
using ProyectoTallerBruto;

namespace ProyectoTallerAvalonia;

public partial class WindowCochesDatagrid : Window
{
    GarajeCoches garajeCoches;
    
    /// <summary>
    /// Inicializa los elementos y crea un garaje vacío junto con un nombre de archivo vacío
    /// </summary>
    public WindowCochesDatagrid(GarajeCoches garaje)
    {
        InitializeComponent();
        DataContext = garaje;
        garajeCoches = garaje;
        iniciarDatagrid();
    }


    /// <summary>
    /// Inicializa el datagrid con los datos a mostrar
    /// </summary>
    public void iniciarDatagrid()
    {
        this.DatagridCoches.ItemsSource = garajeCoches.Coches;
    }

    /// <summary>
    /// Cierra la ventana de visualización de instancias de coches
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cerrarVentana(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}