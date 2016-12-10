using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromFile = File.ReadAllText("string_for_test.txt");
            Console.WriteLine(newFunction(fromFile));
            Console.ReadKey();
        }

        private static string newFunction(string text)
        {
            var xml = XElement.Parse(text);
            var counter = new KeyValueList<string, int>();
            AddDistinctChildrenCount(counter, xml, 0, 3);
            return counter.OrderByDescending(c => c.Value).First().Key;
        }

        private static void AddDistinctChildrenCount(KeyValueList<string, int> counter, XElement element, int level, int maxlevel)
        {

            if (level > 0)
                counter.Add(element.Name.LocalName,
                            element.Elements().Select(d => d.Name.LocalName)
                            .Distinct()
                            .Count());
            foreach (var child in element.Elements())
            {
                if (level < maxlevel)
                {
                    AddDistinctChildrenCount(counter, child, level + 1, maxlevel);
                }
            }
        }

        private static string afunction(string h)
        {
            var xml = XElement.Parse(h);
            var counter = new KeyValueList<string, int>();
            if (xml.HasElements)
                foreach (var element0 in xml.Elements())
                {
                    counter.Add(
                    element0.Name.LocalName,
                    element0.Elements().Select(d => d.Name.LocalName)
                    .Distinct()
                    .Count());
                    if (element0.HasElements)
                        foreach (var element1 in element0.Elements())
                        {
                            counter.Add(element1.Name.LocalName,
                            element1.Elements().Select(e => e.Name.LocalName)
                            .Distinct()
                            .Count());
                            if (element1.HasElements)
                                foreach (var element2 in element1.Elements())
                                {
                                    counter.Add(element2.Name.LocalName,
                                    element2.Elements().Select(f => f.Name.LocalName)
                                    .Distinct()
                                    .Count());
                                    if (element2.HasElements)
                                        foreach (var element3 in element2.Elements())
                                        {
                                            counter.Add(element3.Name.LocalName,
                                            element3.Elements().Select(g =>
                                            g.Name.LocalName)
                                            .Distinct()
                                            .Count());
                                        }
                                }
                        }
                }

            return counter.OrderByDescending(c => c.Value).First().Key;
        }
    }
}
