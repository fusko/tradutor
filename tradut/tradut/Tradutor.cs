﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tradut
{
    class Tradutor
    {
        public List<Token> palavras;
        public List<Token> tolkens;
        public Dictionary<Token, string> MapTokens;
        

        public Tradutor()
        {
            palavras= new List<Token>();
            tolkens = new List<Token>();
            MapTokens = new Dictionary<Token, string>();
            popular();
            
        }
        public void popular()
        {
            Token var = new Operador();
            var.Equivalente="erer";
            var.Expressao = "^var ";
            palavras.Add(var);
        }
        public string[] Fragmentar(string codigo)
        {
           return codigo.Split(new[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None);
        }



        public List<string> Traduzir(string codigo)
        {
            string[] linhas = Fragmentar(codigo);

            List<string> traduzido= new List<string>();

            foreach (var item in linhas)
            {
                var rxg = new Regex(palavras[0].Expressao,
                RegexOptions.IgnoreCase);
                var primeiro = rxg.Match(item);
                if (primeiro.Success)
                {
                    traduzido.Add(palavras[0].Equivalente+ "\r\n");
                }
                else
                {
                    traduzido.Add("erro" + "\r\n");
                }
            }
   
            return traduzido;
        }

        public void maquinaEstado()
        {

        }
    }
}
