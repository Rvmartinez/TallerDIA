using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ProyectoTallerAvalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void OnClickEmpezar(object sender, RoutedEventArgs e)
    {
        var ventanaShow = new WindowCoches();
        ventanaShow.Show();
    }
}