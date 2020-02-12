using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CS_LR1
{
    class Program
    {
        static string ReadFile(string path)
        {
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }
        static List<double> Probability(string path)
        {
            string text = ReadFile(path);
            List<char> symbol = new List<char>();
            List<int> count = new List<int>();
            foreach (var ch in text)
            {
                if (symbol.Contains(ch))
                    count[symbol.IndexOf(ch)]++;
                else
                {
                    symbol.Add(ch);
                    count.Add(1);
                }
            }
            List<double> probability = new List<double>();
            double length = text.Length;
            foreach (var ch in count)
            {
                probability.Add(ch / length);
            }
            for (int i = 0; i < symbol.Count; i++)
            {
                Console.WriteLine("{0,-3} його частота {1}", symbol[i], probability[i]);
            }
            return probability;
        }
        static double Enthropy(List<double> probability)
        {
            double enthropy = 0;
            for (int i = 0; i < probability.Count; i++)
            {
                if (probability[i] > 0)
                {
                    enthropy += (probability[i] * Math.Log2(1.0/probability[i]));
                }
            }
            Console.WriteLine("\nСередня ентропія нерівноймовірного алфавіту - {0} \n", enthropy);
            return enthropy;
        }
        static double Information(double enthropy, string path)
        {
            string text = ReadFile(path);
            int allsymbol = text.Length;
            return enthropy * allsymbol;
        }
        static void OutputData(string path)
        {
            Console.WriteLine("Відносна частота появи символу:");
            List<double> probability = Probability(path);
            double enthropy = Enthropy(probability);
            double information = Information(enthropy, path);
            FileInfo file = new FileInfo(path);
            double sizefile = file.Length;
            Console.WriteLine("Кількість інформації в тексті - {0} байт\nРозмір файлу - {1} байт\nРозмір файлу в - {2} рази більший за кількість інформації", information / 8, sizefile, sizefile / (information / 8));
        }
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);
            string path1 = @"C:\CS Lab\text1_base64.txt_base64.txt";
            string path2 = @"C:\CS Lab\text2_base64.txt_base64.txt";
            string path3 = @"C:\CS Lab\text3_base64.txt_base64.txt";
            OutputData(path1);
            OutputData(path2);
            OutputData(path3);
        }
    }
}
