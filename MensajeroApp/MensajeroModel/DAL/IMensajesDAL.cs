using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    public interface IMensajesDAL
    {
        //metodos necesarios para que exista un DAL por eso la interface
        void Save(Mensaje m);
        List<Mensaje> GetAll();
    }
}
