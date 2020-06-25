using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tradut
{
   public abstract class Token
    {
        public Token proximobloco;
       public string Expressao;
       public string Equivalente;
       
        public void traduzBloco()
        {

        }
    }
    public class Algoritmo:Token
    {

    public Algoritmo()
        {
            Expressao = "";
            Equivalente = "";
            
        }
    }
    public class Var: Token
    {
        public Var()
        {
            Expressao = "";
            Equivalente = "";
        }
    }
    public class Inicio: Token
    {
        public Inicio()
        {
            Expressao = "";
            Equivalente = "";
        }
    }

    public class FimAlgoritmo : Token
    {
        public FimAlgoritmo()
        {
            Expressao = "";
            Equivalente = "";
        }
    }
    public class Variavel: Token
    {
        public Variavel()
        {
            Expressao = "";
            Equivalente = "";
        }
    }
    public class Escreval : Token
    {
        public Escreval()
        {
            Expressao = "";
            Equivalente = "";
        }
    }
}
