
using System.Text;
using EdiFact.Serialization;
using EdiFact.Models;
using System;
using System.IO;
using Newtonsoft.Json;
using EdiFact;
using EdiFact.Classes;

string rutaArchivo = @"C:\Users\mbermudez\OneDrive - JAPDEVA\Escritorio\ProjectBaplie\EdiFact\BAPLIE_Export.EDI";
        string rutaJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BAPLIE_Export.json");

        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("El archivo EDI no existe.");
            return;
        }
         

        try
        {
            var grammar = EdiGrammar.NewEdiFact();
            var interchange = default(Interchange);
            using (var stream = new StreamReader(@"C:\Users\mbermudez\OneDrive - JAPDEVA\Escritorio\ProjectBaplie\EdiFact\BAPLIE_Export.EDI")) {
                interchange = new EdiSerializer().Deserialize<Interchange>(stream, grammar);
            }

            // Convertir el objeto a JSON
            string jsonResultado = JsonConvert.SerializeObject(interchange, Newtonsoft.Json.Formatting.Indented);

            // **Guardar el JSON en la misma carpeta del proyecto**
            File.WriteAllText(rutaJson, jsonResultado);

            Console.WriteLine($"Archivo JSON generado en: {rutaJson}");
    
            Console.WriteLine($"Archivo JSON generado con éxito en: {rutaJson}");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al procesar el archivo EDI: " + ex.ToString());
        }