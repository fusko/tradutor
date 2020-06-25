using System;
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
        public Regex regex;

        public Tradutor()
        {
           
            palavras= new List<Token>();
            tolkens = new List<Token>();
            MapTokens = new Dictionary<Token, string>();
           // popular();
            
        }

        private string _Inicio(string texto)
        {
            regex = new Regex(@"^/s*inicio/s*$", RegexOptions.Multiline);
            string resultInicio = regex.Match(texto).ToString();
            //to do criar tokens
            Inicio inicio = new Inicio();
            palavras.Add(inicio);
            resultInicio = regex.Replace(texto, "");

            string[] result= resultInicio.Split(new[]{"\r\n","\r","\n"},StringSplitOptions.None);

            foreach (string item in result)
            {
                foreach (Token token in tolkens)
                {
                    regex = new Regex(token.Expressao,RegexOptions.Multiline);
                    Match rgx = regex.Match(item);
                    if (rgx.Success)
                    {
                        //faz token
                        break;
                    }
                }
                /*
                regex = new Regex(item.Expressao);
               var _result = regex.Match(texto);
                if (_result.Success)
                {

                }
                */
            }
            return "fim";
        }

        public string _Algoritmo(string texto)
        {
            regex = new Regex(@"\A(algoritmo\s*""\w*"")\s*");        
            string result= regex.Replace(texto, "");
            Algoritmo algoritmo = new Algoritmo();
            palavras.Add(algoritmo);
            // _Var(result);
            return result;
        }

        private string _Var(string texto)
        {
            regex = new Regex(@"^\s*var\s*$(\s*([a-zA-Z_][a-zA-Z\d_]*\s*[,]\s*)*([a-zA-Z_][a-zA-Z\d_]*)\s*:\s*(vetor\s*\[(\d+..\d+\s*,)*(\d+..\d+)\]\s*de\s*){0,1}\s*(inteiro|real|caracter|logico)\s*$)*", RegexOptions.Multiline);
            string result = regex.Match(texto).ToString();           
            Var var = new Var();
            palavras.Add(var);

            string[] resultSplit = result.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string item in resultSplit)
            {
                
                regex = new Regex(@"(vetor\s*\[(\d+..\d+\s*,)*(\d+..\d+)\]\s*de\s*){0,1}\s*(inteiro|real|caracter|logico)");
                var rgx = regex.Matches(result);

                regex = new Regex(@"[a-zA-Z_][a-zA-Z\d_]");
                var rgx = regex.Matches(result);
                foreach (Match match in rgx)
                {
                    Variavel vari = new Variavel();
                }

            }

                //to do criar tokens variaveis e adicionar em tokens e em palavra
                result = regex.Replace(texto,"");
            return result;
        }

        public string TestaErros(string texto)
        {
            var regex = new Regex(@" ^(\s*fimalgoritmo\s*)", RegexOptions.IgnoreCase);
            var result = regex.Matches(texto);
            if (result.Count > 1)
                return "fimalgoritmo duplicado";
            regex = new Regex(@"^(\s*algoritmo\s*)", RegexOptions.IgnoreCase);
            result = regex.Matches(texto);
            if (result.Count > 1)
                return "algoritmo duplicado";
            regex = new Regex(@"^(\s*var\s*)", RegexOptions.IgnoreCase);
            result = regex.Matches(texto);
            if (result.Count > 1)
                return "var duplicado";
            regex = new Regex(@"^^(\s*inicio\s*)", RegexOptions.IgnoreCase);
            result = regex.Matches(texto);
            if (result.Count > 1)
                return "inicio duplicado";
            return "";
        }

        public void _fimAlgoritmo(string texto)
        {
            regex = new Regex(@"^/s*fimalgoritmo/s*$", RegexOptions.Multiline);
            Match resultInicio = regex.Match(texto);
            FimAlgoritmo fimAlgoritmo = new FimAlgoritmo();
            palavras.Add(fimAlgoritmo);
        }
        public string tiraComments(string texto)
        {
            regex = new Regex(@"\/\/\s(.*)", RegexOptions.Multiline);
            string result = regex.Replace(texto, "");
            regex = new Regex(@"^\s*", RegexOptions.Multiline);
            result = regex.Replace(result, "");
            return result;
        }
        public void popular()
        {
            Token temp = new Operador();
            temp.Equivalente = "erer";
            temp.Expressao = "^var ";
            palavras.Add(temp);
        }
    }
}
