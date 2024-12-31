using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

namespace csvFileHandling
{
    internal class ProgramJson
    {
        //static void Main(string[] args)
        //{
        //    string csvFilePath = @"C:\Users\Hp\source\repos\FileHanding\FileHanding\csvFiles.csv";
        //    string jsonFilePath = @"C:\Users\Hp\source\repos\FileHanding\JsonDemo.json";

            
        //    var list = new List<PersonJson>
        //    {
        //        new PersonJson { Id = 1, Name = "Abdul", Age = 20 },
        //        new PersonJson { Id = 2, Name = "Ram", Age = 21 },
        //        new PersonJson { Id = 3, Name = "Jenita", Age = 22 }
        //    };

            
        //    WriteJson(jsonFilePath, list);

            
        //    WriteToCsv(csvFilePath, list);
        //}

        public static void WriteJson(string path, List<PersonJson> list)
        {
            try
            {
                
                string jsonData = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(path, jsonData);
                Console.WriteLine("Data added to JSON file");

                
                string jsonRead = File.ReadAllText(path);
                var deserializedData = JsonConvert.DeserializeObject<List<PersonJson>>(jsonRead);
                Console.WriteLine("Data read from JSON file");
                foreach (var person in deserializedData)
                {
                    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteToCsv(string filePath, List<PersonJson> list)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (var writer = new StreamWriter(filePath))
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(list);
                    }
                    Console.WriteLine("Data added to CSV file successfully.");
                }
                else
                {
                    Console.WriteLine("CSV file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while handling CSV: {ex.Message}");
            }
        }

        public class PersonJson
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
