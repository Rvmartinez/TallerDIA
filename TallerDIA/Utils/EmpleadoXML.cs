﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Linq;
using TallerDIA.Models;


public class EmpleadoXML
{
    public static void GuardarEmpleados(ObservableCollection<Empleado> plantilla)
    {
        string rutaArchivo = "/home/lcuas/Documents/UNI/DIA/plantilla.xml";
        XmlDocument doc = new XmlDocument();
        XmlElement root = doc.CreateElement("PlantillaEmpleados");
        doc.AppendChild(root);

        foreach (var empleado in plantilla)
        {
            XmlElement empleadoElement = doc.CreateElement("Empleado");

            XmlElement dniElement = doc.CreateElement("DNI");
            dniElement.InnerText = empleado.Dni;
            empleadoElement.AppendChild(dniElement);

            XmlElement nombreElement = doc.CreateElement("Nombre");
            nombreElement.InnerText = empleado.Nombre;
            empleadoElement.AppendChild(nombreElement);
            
            XmlElement mailElement = doc.CreateElement("Email");
            mailElement.InnerText = empleado.Email;
            empleadoElement.AppendChild(mailElement);

            root.AppendChild(empleadoElement);
        }
        try
        {
            doc.Save(rutaArchivo);
            Console.WriteLine("Archivo XML guardado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("No se ha podido guardar el archivo");
        }
    }
    
    public static Empleado CargarDeXml(XmlElement empleadoElement)
    {
        try
        {
            string dni = empleadoElement["DNI"].InnerText;
            string nombre = empleadoElement["Nombre"].InnerText;
            string email = empleadoElement["Email"].InnerText;

            return new Empleado(dni, nombre, email);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        throw new XmlException("Error al cargar XML");
    }
}