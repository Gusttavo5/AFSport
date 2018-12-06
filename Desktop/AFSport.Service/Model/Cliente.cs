﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSport.Service.Model
{
    public class Cliente : Pessoa
    {
        public Cliente() : base()
        {
            IsAtivo = true;
        }

        public Cliente(string nome, string logradouro, string bairro, int numero, int idCidade) : base(nome)
        {
            this.Logradouro = logradouro;
            this.Bairro = bairro;
            this.Numero = numero;
            this.IdCidade = idCidade;
            IsAtivo = true;
        }

        public int IdCliente { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public int IdCidade { get; set; }
        public Cidade Cidade { get; set; }
        public bool IsAtivo { get; set; }
    }
}
