﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CommunityToolkit.Mvvm.Input;
using TallerDIA.Models;
using TallerDIA.Views.Dialogs;

namespace TallerDIA.Utils
{
    public class SharedDB
    {
        private static SharedDB _instance;
        public static SharedDB Instance => _instance ??= new SharedDB();
        public CarteraClientes CarteraClientes { get; }

        private SharedDB()
        {
            CarteraClientes = new CarteraClientes(LoadClientesFromXml());
        }

        public ObservableCollection<Cliente> LoadClientesFromXml(string filePath = "")
        {
            return new ObservableCollection<Cliente>
            {
                new Cliente { DNI = "12345678", Nombre = "Juan Perez", Email = "juan.perez@example.com", IdCliente = 1 },
                new Cliente { DNI = "87654321", Nombre = "Ana Lopez", Email = "ana.lopez@example.com", IdCliente = 2 },
                new Cliente { DNI = "11223344", Nombre = "Carlos Garcia", Email = "carlos.garcia@example.com", IdCliente = 3 }
            };
        }


        private bool CanAddCliente(Cliente cliente)
        {

            Cliente aux = CarteraClientes.Clientes.Where(c => c.DNI.ToLower() == cliente.DNI.ToLower() || c.Email.ToLower() == cliente.Email.ToLower()).First();

            return  aux == null;
        }

        public void BajaCliente(Cliente cliente)
        {
            CarteraClientes.RemoveCliente(cliente);
        }

        public void BajaClienteByDNI(string dni)
        {
            CarteraClientes.RemoveCliente(ConsultaClienteByDni(dni));
        }

        public Cliente ConsultaCliente(int clienteId) => CarteraClientes.Clientes.FirstOrDefault(c => c.IdCliente == clienteId);
        public Cliente ConsultaClienteByDni(string dni) => CarteraClientes.Clientes.FirstOrDefault(c => c.DNI.Trim().ToUpper() == dni.Trim().ToUpper());
        private int GetLastClientId()
        {
            return CarteraClientes.Clientes.OrderByDescending(c => c.IdCliente).FirstOrDefault().IdCliente;
        }


        public bool EditClient(Cliente cliente,Cliente updated)
        {
            Cliente toupdate = CarteraClientes.Clientes.Where(c => c.IdCliente == cliente.IdCliente).FirstOrDefault();

            if (toupdate == null) return false;

            toupdate.DNI = updated.DNI;
            toupdate.Nombre = updated.Nombre;
            toupdate.Email = updated.Email;

            return true;
        }

        public bool AddClient(Cliente c)
        {
            if(!CanAddCliente(c)) 
                return false;
           
            c.IdCliente = GetLastClientId()+1;
            CarteraClientes.Add(c);

            return true;
        }
    }
}
