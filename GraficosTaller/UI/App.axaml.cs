using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GraficosTaller.Corefake;

namespace GraficosTaller.UI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new DesgloseWindow(InicializarReparaciones(), new ConfigChart(){Anno = 2024, FechaFin = true, Cliente = "A", Modo = ConfigChart.ModoVision.Mensual});
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    
        private Reparaciones InicializarReparaciones()
        {
            Reparaciones toret = new Reparaciones();
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 01, 02), FechaFin = new DateTime(2023, 02, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 03, 10), FechaFin = new DateTime(2023, 03, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 04, 15), FechaFin = new DateTime(2023, 05, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 06, 05), FechaFin = new DateTime(2023, 06, 18)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 07, 21), FechaFin = new DateTime(2023, 08, 12)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 09, 15), FechaFin = new DateTime(2023, 10, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 11, 08), FechaFin = new DateTime(2023, 11, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 12, 02), FechaFin = new DateTime(2023, 12, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 01, 10), FechaFin = new DateTime(2024, 01, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 02, 05), FechaFin = new DateTime(2024, 02, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 03, 08), FechaFin = new DateTime(2024, 03, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 04, 12), FechaFin = null});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 05, 17), FechaFin = new DateTime(2024, 06, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 06, 07), FechaFin = new DateTime(2024, 06, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 07, 19), FechaFin = new DateTime(2024, 08, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 08, 23), FechaFin = new DateTime(2024, 09, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 09, 15), FechaFin = new DateTime(2024, 10, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 10, 19), FechaFin = new DateTime(2024, 11, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 11, 10), FechaFin = new DateTime(2024, 11, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 12, 01), FechaFin = new DateTime(2024, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 01, 10), FechaFin = new DateTime(2024, 01, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 02, 05), FechaFin = new DateTime(2024, 02, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 03, 08), FechaFin = new DateTime(2024, 03, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 04, 12), FechaFin = new DateTime(2024, 04, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 05, 17), FechaFin = new DateTime(2024, 06, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 06, 07), FechaFin = new DateTime(2024, 06, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 07, 19), FechaFin = new DateTime(2024, 08, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 08, 23), FechaFin = new DateTime(2024, 09, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 09, 15), FechaFin = new DateTime(2024, 10, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 10, 19), FechaFin = new DateTime(2024, 11, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 11, 10), FechaFin = new DateTime(2024, 11, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 12, 01), FechaFin = new DateTime(2024, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2023, 01, 10), FechaFin = new DateTime(2024, 01, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 02, 05), FechaFin = new DateTime(2024, 02, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 03, 08), FechaFin = new DateTime(2024, 03, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 04, 12), FechaFin = new DateTime(2024, 04, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 05, 17), FechaFin = new DateTime(2024, 06, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 06, 07), FechaFin = new DateTime(2024, 06, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 07, 19), FechaFin = new DateTime(2024, 08, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 08, 23), FechaFin = new DateTime(2024, 09, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 09, 15), FechaFin = new DateTime(2024, 10, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 10, 19), FechaFin = null});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 11, 10), FechaFin = new DateTime(2024, 11, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2024, 12, 01), FechaFin = new DateTime(2024, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 01, 10), FechaFin = new DateTime(2016, 01, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 02, 05), FechaFin = new DateTime(2016, 02, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 03, 08), FechaFin = new DateTime(2016, 03, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 04, 12), FechaFin = new DateTime(2016, 04, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 05, 17), FechaFin = new DateTime(2016, 06, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 06, 07), FechaFin = new DateTime(2016, 06, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 07, 19), FechaFin = new DateTime(2016, 08, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 08, 23), FechaFin = new DateTime(2016, 09, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 09, 15), FechaFin = new DateTime(2016, 10, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 10, 19), FechaFin = new DateTime(2016, 11, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 11, 10), FechaFin = new DateTime(2016, 11, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 12, 01), FechaFin = new DateTime(2016, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 05, 10), FechaFin = new DateTime(2017, 01, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 05, 05), FechaFin = new DateTime(2017, 02, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 05, 08), FechaFin = new DateTime(2017, 03, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 05, 12), FechaFin = new DateTime(2020, 04, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 05, 17), FechaFin = new DateTime(2020, 06, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 05, 07), FechaFin = new DateTime(2020, 06, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 05, 19), FechaFin = new DateTime(2020, 08, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 08, 23), FechaFin = new DateTime(2020, 09, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 09, 15), FechaFin = new DateTime(2020, 10, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 10, 19), FechaFin = new DateTime(2020, 11, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 11, 10), FechaFin = new DateTime(2020, 11, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 12, 01), FechaFin = new DateTime(2020, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 01, 10), FechaFin = new DateTime(2020, 01, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 02, 05), FechaFin = new DateTime(2020, 02, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 03, 08), FechaFin = new DateTime(2020, 03, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2020, 04, 12), FechaFin = new DateTime(2020, 04, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 05, 17), FechaFin = new DateTime(2020, 06, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 06, 07), FechaFin = new DateTime(2020, 06, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 07, 19), FechaFin = new DateTime(2020, 08, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 08, 23), FechaFin = new DateTime(2020, 09, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 09, 15), FechaFin = new DateTime(2020, 10, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 10, 19), FechaFin = new DateTime(2020, 11, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 11, 10), FechaFin = new DateTime(2020, 11, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 12, 01), FechaFin = new DateTime(2020, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 01, 10), FechaFin = new DateTime(2020, 01, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 02, 05), FechaFin = new DateTime(2020, 02, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 03, 08), FechaFin = new DateTime(2020, 03, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 04, 12), FechaFin = new DateTime(2020, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 05, 17), FechaFin = new DateTime(2020, 12, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 06, 07), FechaFin = new DateTime(2019, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 07, 19), FechaFin = new DateTime(2019, 12, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 08, 23), FechaFin = new DateTime(2019, 12, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 09, 15), FechaFin = new DateTime(2019, 12, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2018, 12, 19), FechaFin = new DateTime(2019, 12, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 12, 10), FechaFin = new DateTime(2019, 12, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2019, 12, 01), FechaFin = new DateTime(2019, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 12, 10), FechaFin = new DateTime(2020, 12, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 12, 05), FechaFin = new DateTime(2020, 12, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 12, 08), FechaFin = new DateTime(2020, 12, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 12, 12), FechaFin = new DateTime(2020, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 12, 17), FechaFin = new DateTime(2020, 12, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2017, 12, 07), FechaFin = new DateTime(2020, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 12, 19), FechaFin = new DateTime(2020, 12, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 12, 23), FechaFin = new DateTime(2020, 12, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 12, 15), FechaFin = new DateTime(2020, 12, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 12, 19), FechaFin = new DateTime(2020, 12, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 12, 10), FechaFin = new DateTime(2020, 12, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2016, 12, 01), FechaFin = new DateTime(2020, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 12, 10), FechaFin = new DateTime(2021, 12, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 12, 05), FechaFin = new DateTime(2021, 12, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 03, 08), FechaFin = new DateTime(2021, 12, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 04, 12), FechaFin = new DateTime(2021, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 05, 17), FechaFin = new DateTime(2021, 12, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 06, 07), FechaFin = new DateTime(2021, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 07, 19), FechaFin = new DateTime(2021, 12, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 08, 23), FechaFin = new DateTime(2021, 12, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 09, 15), FechaFin = new DateTime(2021, 12, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 10, 19), FechaFin = new DateTime(2021, 12, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 11, 10), FechaFin = new DateTime(2021, 12, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2021, 12, 01), FechaFin = new DateTime(2021, 12, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 01, 10), FechaFin = new DateTime(2022, 12, 20)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 02, 05), FechaFin = new DateTime(2022, 12, 25)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 03, 08), FechaFin = new DateTime(2022, 12, 28)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 04, 12), FechaFin = new DateTime(2022, 04, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2020, 05, 17), FechaFin = new DateTime(2022, 06, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2020, 06, 07), FechaFin = new DateTime(2022, 06, 22)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2020, 07, 19), FechaFin = new DateTime(2022, 08, 04)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2020, 08, 23), FechaFin = new DateTime(2022, 09, 07)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2020, 09, 15), FechaFin = new DateTime(2022, 10, 01)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 10, 19), FechaFin = new DateTime(2022, 11, 05)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 11, 10), FechaFin = new DateTime(2022, 11, 24)});
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2022, 12, 01), FechaFin = new DateTime(2022, 12, 22)});
            
            
            toret.AnadirReparacion(new Reparacion(){Cliente = new Cliente(), FechaInicio = new DateTime(2012, 01, 02), FechaFin = new DateTime(2014, 02, 04)});
            return toret;
        }

}