﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSport.DAO.Model
{
    public class Operacao
    {
        public Operacao()
        {

        }

        public Operacao(string nome)
        {
            this.Nome = nome;
            this.IsAtivo = true;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
