﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarUsuario.BLL
{
    public class Utilidades
    {
        public static int ToInt(string valor)
        {
            int retorno=0;

            int.TryParse(valor, out retorno);

            return retorno;
        }
    }
}
