﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app
{
    
        public class Elemento
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
        //prueba github repositorio

            public override string ToString()
            {
                return Descripcion;
            }
        }
    }
