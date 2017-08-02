using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new VerbsFactory();
            var lines = File.ReadAllLines(@"d:\verbs.txt");

            var res = new List<string>();
            foreach (var l in lines)
            {
                var words = l.Split(';');
                if (words.Length == 2)
                    res.AddRange(factory.GetForms(words[0].Trim(), words[1].Trim()));
            }

            File.WriteAllLines(@"d:\verbs1.txt", res);
            foreach (var v in res)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine(res.Count);
            Console.ReadLine();
        }
    }
}
