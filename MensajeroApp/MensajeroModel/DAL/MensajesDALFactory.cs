﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    //larman uml patterns
    public class MensajesDALFactory
    {
        public static IMensajesDAL CreateDal()
        {
            return MensajesDALArchivos.GetInstancia();
        }
    }
}
