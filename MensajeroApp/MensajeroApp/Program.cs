using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    class Program
    {
        static IMensajesDAL dal = MensajesDALFactory.CreateDal();

        static void IngresarMensajes()
        {
            String nombre, detalle;
            do
            {
                Console.WriteLine("Ingresar Nombre");
                nombre = Console.ReadLine().Trim();
            } while (nombre == String.Empty);
            do
            {
                Console.WriteLine("Ingrese mensaje");
                detalle = Console.ReadLine().Trim();
            } while (detalle == string.Empty || detalle.Length > 140);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle ,  
                Tipo = "Aplicacion"
            };
            dal.Save(m);
        }


        static void MostraMensajes()
        {
            List<Mensaje> mensajes = dal.GetAll();
            mensajes.ForEach(m =>
            {
                Console.WriteLine("Nombre:{0} Detalle:{1} Tipo:{2}"
                    , m.Nombre, m.Detalle, m.Tipo);

            });

        }

       static Boolean Menu()
       { 
            bool continuar = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Ingresar un mensaje");
            Console.WriteLine("2. Mostrar mensajes");
            Console.WriteLine("0. Salir");
            String resp = Console.ReadLine().Trim();
            switch (resp)
            {
                case "1": IngresarMensajes();
                        break;
                case "2": MostraMensajes();
                    break;
                case "0": continuar = false;
                    break;
                default : Console.WriteLine("Oiga Yapo");
                    break;
            }
            return continuar;
       }

        static void Main(string[] args)
        {
            while (Menu());
        }
    }
}
