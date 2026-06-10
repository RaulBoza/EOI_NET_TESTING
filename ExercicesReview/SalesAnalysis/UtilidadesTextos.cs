using System;
using System.Collections.Generic;
using System.Text;

namespace SalesAnalysis
{
    static public class UtilidadesTextos
    {
        static public Dictionary<string, int> ContarPalabras(string text)
        {
            Dictionary<string, int> palabras = new Dictionary<string, int>();

            palabras = text.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(p => p.ToLower())
                .ToDictionary(g => g.Key, g => g.Count());

            return palabras;
        }

        static public string PalabraMasFrecuente(string text)
        {
            string palabraMasFrecuente = "";
            var palabras = ContarPalabras(text);

            palabraMasFrecuente = palabras.OrderByDescending(p => p.Value)
                .First().Key;

            return palabraMasFrecuente;
        }

        static public List<string> NumeroLetras(string text, int numero)
        {
            List<string> lista = new List<string>();

            lista = text.ToLower()
                .Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(p => p.Length == numero)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            return lista;
        }

        static public int NumeroVocales(string text)
        {
            int numeroVocales;

            numeroVocales = text.ToLower().
                Count(p => "aeiou".Contains(p));

            return numeroVocales;
        }
    }
}
