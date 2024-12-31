using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using CsvHelper;

namespace csvFileHandling
{
    internal class ProgramCsv
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Hp\source\repos\FileHanding\FileHanding\csvFiles.csv";


            var list = new List<Person>
            {
                new Person { Id = 1, Name = "Abdul", Age = 20 },
                new Person { Id = 2, Name = "Ram", Age = 21 },
                new Person { Id = 3, Name = "Jenita", Age = 22 }
            };

            try
            {

                if (File.Exists(filePath))
                {

                    using (var writer = new StreamWriter(filePath))
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(list);
                    }
                    Console.WriteLine("Data added.");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            
        }

        public static void csvFile()
        {
            string path = @"C:\Users\Hp\source\repos\FileHanding";
            File.Create(path);
        }
    }


    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
