﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giusti.Restaurante.Model
{
    public class Categoria
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public IList<Prato> Pratos { get; set; }
    }
}
