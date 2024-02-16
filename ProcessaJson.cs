using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorvetesPinguin
{
    internal class ProcessaJson
    {
        public static void ArmazenaLista(string arquivo, object lista)
        {
            //Transforma a lista de produtos em um JSON
            string lista_json = JsonConvert.SerializeObject(lista, Formatting.Indented);

            // Escreve o JSON dentro do Arquivo de texto
            File.WriteAllText(arquivo, lista_json, Encoding.UTF8);
        }

        public static List<Produto> CarregaLista()
        {
            // Faz a leitura do arquivo json
            if (File.Exists("./meuarquivojson.json"))
            {
                string arquivo_json = File.ReadAllText("./meuarquivojson.json");
                return JsonConvert.DeserializeObject<List<Produto>>(arquivo_json);
            }
            else
            {
                return new List<Produto>();
            }

            // Retorna o arquivo em forma de lista de produtos
        }
    }
}

