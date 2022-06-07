using System;
using System.IO;

class IndexadorDeCarpetas {
    static void Main() {
        Console.WriteLine("Ingrese la ruta de la cual quiere listar sus archivos:");
        string directorioAListar = Console.ReadLine();

        if(directorioAListar.Length > 0) {
            List<string> archivos = Directory.GetFiles(directorioAListar).ToList();
            List<string> lineasCSV = new List<string>();
            
            int indiceRegitro = 0;
            archivos.ForEach(archivo => {
                lineasCSV.Add(getLineaCSV(indiceRegitro, archivo));
                indiceRegitro++;
            });

            File.WriteAllLines(@".\archivos.csv", lineasCSV);
        }
    }

    static string getLineaCSV(int index, string pathArchivo) {
        string lineaCSV = "";
        lineaCSV += index + ",";
        lineaCSV += Path.GetFileNameWithoutExtension(pathArchivo) + ",";
        lineaCSV += Path.GetExtension(pathArchivo) + ",";
        return lineaCSV;
    }
}