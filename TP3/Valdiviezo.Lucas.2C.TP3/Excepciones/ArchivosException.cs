﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base("Error de Archivo",innerException)
        {

        }
    }
}
