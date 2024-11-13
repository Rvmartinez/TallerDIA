using System;
using System.Xml.Linq;

namespace ProyectoTallerBruto;

public class ArchivoCochesXML
{
    private GarajeCoches garaje;
    public GarajeCoches Garaje { get => garaje; }
    
    /// <summary>
    /// Crea un objeto ArchivoCochesXML con un garaje de atributo
    /// </summary>
    /// <param name="gar"></param>
    public ArchivoCochesXML(GarajeCoches gar)
    {
        garaje = gar;
    }

    /// <summary>
    /// Guarda el garaje que esta como atributo en un archivo xml de nombre el parámetro que se le pasa.
    /// </summary>
    /// <param name="nomArch"></param>
    public void Guardar(string nomArch)
    {
        XElement raiz = garaje.ToXML();
        
        raiz.Save(nomArch);
    }

    /// <summary>
    /// Recupera del archivo xml, de nombre el parametro que se le pasa al método, todos los
    /// coches que estean en él, además de devolver el garaje con los datos.
    /// </summary>
    /// <param name="nomArch"></param>
    public static GarajeCoches Recuperar(string nomArch)
    {
        GarajeCoches garaje = new GarajeCoches();
        XElement raiz = XElement.Load(nomArch);
        
        var coches = raiz.Elements("coche");
        foreach (var coche in coches)
        {
            var mat = coche.Element("matricula");
            var marca = coche.Element("marca");
            var modelo = coche.Element("modelo");
            Coche.Marcas marc;
            if (Enum.TryParse(marca.Value, true, out marc))
            {
                Coche c = new Coche(mat.Value, marc, modelo.Value);
                garaje.Add(c);
            }
            else
            {
                Console.WriteLine("Error al parsear la marca del coche");
            }
        }

        return garaje;
    }
    
}