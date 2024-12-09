﻿using System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using TallerDIA.Models;
using TallerDIA.Views.Dialogs;
using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ColorTextBlock.Avalonia;
using TallerDIA.Utils;
using TallerDIA.Views;
namespace TallerDIA.ViewModels;

public partial class CochesViewModel : FilterViewModel<Coche>
{
    private GarajeCoches _garaje = SharedDB.Instance.Garaje;
    public ObservableCollection<Coche> Coches => _garaje.Coches;
    

    private Coche _SelectedCar;
    public Coche SelectedCar
    {
        get => _SelectedCar;
        set
        {
            SetProperty(ref _SelectedCar, value);
        }
    }

    public CochesViewModel()
    {
        
    }

    public CochesViewModel(IEnumerable<Coche> coches)
    {
        _garaje.AddRange(coches);
    }
    

    [RelayCommand]
    public async void BorrarCocheCommand()
    {
        if(SelectedCar == null) { return; }
        
        var box = MessageBoxManager
            .GetMessageBoxStandard("Atención", "Los datos se borrarán irreversiblemente.¿Desea continuar?", ButtonEnum.OkCancel);

        var result = await box.ShowAsync();
        if (result == ButtonResult.Ok)
        {

            this.RemoveCoche(SelectedCar.Matricula);
            SelectedCar = null;

        }
        else
        {

            SelectedCar = null;
            return;
        }
    }

    [RelayCommand]
    public async void SubirCocheCommand()
    {
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
        var cocheDlg = new CocheDlg();
        await cocheDlg.ShowDialog(mainWindow);
        
        if (!cocheDlg.IsCanceled)
        {
            Cliente c = SharedDB.Instance.ConsultaClienteByDni(cocheDlg.ClientesCb.SelectedItem.ToString());
            Coche.Marcas marcaConcreta = Enum.Parse<Coche.Marcas>(cocheDlg.MarcasCb.SelectedItem.ToString());
            Coche car = new Coche(cocheDlg.MatriculaTb.Text, marcaConcreta, cocheDlg.ModeloTb.Text, c);
            this.AddCoche(car);
        }
    }

    [RelayCommand]
    public async void EditarCocheCommand()
    {
        if(SelectedCar == null) { return; }
        
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
        var cocheDlg = new CocheDlg(SelectedCar);
        cocheDlg.MarcasCb.IsEnabled = false;
        cocheDlg.ModeloTb.IsEnabled = false;
        await cocheDlg.ShowDialog(mainWindow);

        Coche antiguo = new Coche(SelectedCar.Matricula, SelectedCar.Marca, SelectedCar.Modelo, SelectedCar.Owner);

        if (!cocheDlg.IsCanceled)
        {
            Coche nuevo = new Coche(cocheDlg.MatriculaTb.Text, antiguo.Marca, antiguo.Modelo, antiguo.Owner);
            this.EditCoche(antiguo,nuevo);
        }
    }

    [RelayCommand]
    public void MostrarClienteCommand()
    {
        if (SelectedCar == null) { return; }
        
        CochesClientes(SelectedCar.Owner);
    }

    public async void CochesClientes(Cliente cli)
    {
       var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
       var ClienteDlg = new ClienteDlg(SelectedCar.Owner);
       await ClienteDlg.ShowDialog(mainWindow);
       
       if (!ClienteDlg.IsCancelled)
       {
           Cliente nuevo = new Cliente
           {
               DNI = ClienteDlg.DniTB.Text, Email = ClienteDlg.EmailTB.Text, Nombre = ClienteDlg.NombreTB.Text, IdCliente = 0
           };
           SharedDB.Instance.EditClient(SelectedCar.Owner, nuevo);
           SelectedCar.Owner = nuevo;
       }

    }

    public void AddCoche(Coche coche)
    {
        _garaje.Add(coche);
        ToString();
    }

    public void RemoveCoche(string matricula)
    {
        _garaje.RemoveMatricula(matricula);
        ToString();
    }

    public void EditCoche(Coche antiguo, Coche nuevo)
    {
        _garaje.RemoveMatricula(antiguo.Matricula);
        _garaje.Add(nuevo);
        
        ToString();
    }

    public void ToString()
    {
        Console.WriteLine(SharedDB.Instance.Garaje);
    }

    public override ObservableCollection<string> _FilterModes { get; } = new ObservableCollection<string>(["Matricula","Marca","Modelo"]);

    public override ObservableCollection<Coche> FilteredItems
    {
        get
        {
            if (FilterText != "")
            {

                switch (FilterModes[SelectedFilterMode])
                {
                    case "Matricula":
                        return new ObservableCollection<Coche>(Coches.Where(c => c.Matricula.Contains(FilterText)));
                    case "Marca":
                        return new ObservableCollection<Coche>(Coches.Where(c => c.Marca.ToString().Contains(FilterText)));
                    case "Modelo":
                        return new ObservableCollection<Coche>(Coches.Where(c => c.Modelo.Contains(FilterText)));
                    default:
                        return Coches;
                }
            }
            else
            {
                return Coches;
            }
        }
    }
}