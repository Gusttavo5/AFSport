﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSport.Service.Model
{
    public class Estoque
    {
        public Estoque(int quantidade, Produto produto)
        {
            this.Quantidade = quantidade;
            this.Produto = produto;
        }

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }

        public void Incrementa(int quantidade)
        {
            this.Quantidade += quantidade;
        }

        public void Decrementa(int quantidade)
        {
            this.Quantidade += quantidade;
        }
    }
}
