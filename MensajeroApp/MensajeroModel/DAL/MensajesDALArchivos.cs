using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DTO;

namespace MensajeroModel.DAL
{
    public class MensajesDALArchivos : IMensajesDAL
    {
        //Singleton: una instancia de esta clase por programa
        //1. un constructor privado
        private MensajesDALArchivos()
        {
        }
        //2. una referencia estatica a si mismo
        private static IMensajesDAL instancia;
        //3. un metodo estatico que sea el unico 
        //que permite accede a la instancia
        public static IMensajesDAL GetInstancia()
        {
            if(instancia == null)           
                instancia = new MensajesDALArchivos();          
            return instancia;
        }
        
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "mensajes.csv";

        public List<Mensaje> GetAll()
        {
            List<Mensaje> mensajes = new List<Mensaje>();

            try
            {
                //sirve para recursos iClosables, para ahorrar el Close();
                using(StreamReader reader = new StreamReader(archivo))
                {
                    string texto = null;
                    do
                    {
                        texto = reader.ReadLine();//leo k no este vacio
                        if(texto != null)
                        {
                            //parsear mensaje
                            //aqui se puede generar un objeto de tipo mensaje
                            string[] textoArray = texto.Split(';');
                            Mensaje m = new Mensaje()
                            {
                                Nombre = textoArray[0],
                                Detalle = textoArray[1],
                                Tipo = textoArray[2]
                            };
                            mensajes.Add(m);
                        }
                    } while (texto != null);
                }

            }catch(IOException ex)
            {

            }
            return mensajes;
        }

        public void Save(Mensaje m)
        {
            try
            {

                //es en java: try with resources
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }
            
            }catch(IOException ex)
            {

            }

        }
    }
}
