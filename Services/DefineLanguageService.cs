using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StatisticCollector.Services
{
    public class DefineLanguageService
    {
        private static List<string> English = new List<string>{"i","you","he","she","it","we","they",
            "me","your","him","her","us","them","my","his","its","our","their","this","these","that",
            "those","all","every","the","any","some","other","at","between","in","on","over","under",
            "down","from","through","to","up","of","after","for","with","without","again","already",
            "also","always","enough","just","never","most","now","often","still","then","very","usually",
            "well","what","who","when","how","which","an" };

        private static List<string> Spanish = new List<string> {"despues","alrededor","en",
        "alejado","atrás","antes","entre","por","para","de","próximo","encima","fuera","con","qué",
        "cuándo","dónde","cuál","quién","cómo","ambos","diferente","cada","primero","bueno",
        "muchos","nuevo","viejo","mismo","grande","cualquier","algúnos","pocos","pequeño","largo",
        "otro","una","la","esto","también","como","pero","fin","porque","si","solamente","último",
        "mayoría","nunca","ahora","propietario","todavía","tal","qué","entonces","allí","juntos",
        "también","muy","camino","mientras"};

        private static List<string> Portuguese = new List<string> {"eu","não","de", "você",
        "ele","um","sim","isso","uma","está","bem","mas","quando","então","tudo","aqui","disse",
        "estava","fazer","vai","vamos","homem","bom","agora","coisa","quero","foi","meu","seu","só",
        "eles","posso","estou","mim","certo","os","dizer","sei","ela","vocês","sua","sabe","minha",
        "alguma","casa","muito","qualquer","estamos","até","onde","tenho","nós","tem","tinha","quê",
        "ir","pode","quer","vou","seus","dia","estão","cabeça","quem","anos","depois","sou","vez","vá",
        "fez","irmão","câmera"};

        private static List<string> French = new List<string> { "être","et","il","avoir", "je","ce","dans",
        "le","pour","pas","vous","par","sur","faire","dire","mon","lui","nous","comme","tout","avec","où",
        "sans","tu","homme","deux","mari","moi","te","femme","quand","grand","celui","notre","là","jour",
        "même","votre","petit","encore","aussi","quelque","mer","trouver","donner","temps","ça","peu",
        "sous","parler","alors","vie","yeux","passer","autre"};


        public static string GetLanguage(List<string> dictionary)
        {
            if (IsDictionaryExists(dictionary))
            {
                if (IsRussian(dictionary))
                    return "russian";
                if (IsEnglish(dictionary))
                    return "english";
                if (IsFrench(dictionary))
                    return "french";
                if (IsSpanish(dictionary))
                    return "spanish";
                if (IsPortuguese(dictionary))
                    return "portuguese";
                else throw new Exception("Problems with checking for particular language");
            }
            else throw new Exception("No dictionary to identify language");
        }
        private static bool IsDictionaryExists(List<string> dictionary) => dictionary != null;
        private static bool IsRussian(List<string> dictionary)
        {
            foreach (string word in dictionary)
            {
                if (!Regex.IsMatch(word, @"\P{IsCyrillic}"))
                    return true;
            }
            return false;

        }
        private static bool IsEnglish(List<string> dictionary)
        {
            foreach (string word in English)
            {

                if (dictionary.Any(w => w == word))
                    return true;
            }
            return false;
        }
        private static bool IsSpanish(List<string> dictionary)
        {
            foreach (string word in Spanish)
            {
                if (dictionary.Any(w => w == word))
                    return true;
            }
            return false;
        }
        private static bool IsPortuguese(List<string> dictionary)
        {
            foreach (string word in Portuguese)
            {
                if (dictionary.Any(w => w == word))
                    return true;
            }
            return false;
        }
        private static bool IsFrench(List<string> dictionary)
        {
            foreach (string word in French)
            {
                if (dictionary.Any(w => w == word))
                    return true;
            }
            return false;
        }
        public static void WorkWithReductions(string reduction, string fullForm,
            Dictionary<string, uint> dictionary)
        {
            if (reduction != null && fullForm != null && dictionary != null)
            {
                //uint local;
                if (dictionary.ContainsKey(reduction))
                {
                    // local = dictionary[reduction];
                    //dictionary.Remove(reduction);
                    dictionary.Add(fullForm, dictionary[reduction]);
                    dictionary.Remove(reduction);

                }
                else throw new Exception("Dictionary hasn't got this word");

            }
            else throw new Exception("Troubles with reductions-check input data");
        }


    }
}

