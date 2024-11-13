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
        garajeCoches = garaje;
        iniciarDatagrid();
    }


    public void iniciarDatagrid()
    {
        this.DatagridCoches.ItemsSource = garajeCoches.Coches;
        ErroresDatagrid.Content = garajeCoches.ToString();
    }

    private void cerrarVentana(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}