using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestsQueue
{
    public static class FileHandling
    {
        //número de solicitud, nombre de cliente, descripción del problema, nivel de urgencia

        public static void Createfile() 
        {
            TextWriter tw = new StreamWriter("C:\\Users\\avira\\Source\\Repos\\RequestsQueue\\ColaSolicitudes\\data.txt", false);


            List<string> nombres = new List<string>
            {
            "Juan", "Ana", "Luis", "Maria", "Carlos", "Sofia", "Pedro", "Laura",
            "Diego", "Isabella", "Fernando", "Valentina", "Andres", "Camila", "Alejandro", "Lucia",
            "Gabriel", "Valeria", "Javier", "Mariana", "Manuel", "Natalia", "Daniel", "Gabriela",
            "Jose", "Emma", "Mateo", "Sara", "David", "Luna", "Julian", "Olivia",
            "Luisa", "Samuel", "Catalina", "Sebastian", "Antonia", "Santiago", "Victoria", "Nicolas",
            "Isabel", "Esteban", "Eva", "Felipe", "Paula", "Adrian", "Alicia", "Alex", "Diana",
            "Pablo", "Emily", "Rodrigo", "Julia", "Mateo", "Josefina", "Camilo", "Daniela",
            "Ricardo", "Isidora", "Miguel", "Antonella", "Max", "Florencia", "Eduardo", "Isabelle",
            "Cristian", "Ximena", "Emanuel", "Renata", "Leonardo", "Elisa", "Hector", "Carmen",
            "Alberto", "Clara", "Vicente", "Constanza", "Raul", "Irene", "Felix", "Paola",
            "Ignacio", "Valerie", "Alvaro", "Rocio", "Oscar", "Josefa", "Ramon", "Beatriz",
            "Rafael", "Marina", "Alonso", "Gloria", "Sergio", "Rosa", "Eduardo", "Juana",
            "Lorenzo", "Virginia", "Juan Pablo", "Celeste"
            };


            Random random = new Random();

            for (int i = 1; i < 10001; i++)
            {
                int randomName = random.Next(0, 101);
                int randomUrgencyNumber = random.Next(1, 16); 

                string data = Convert.ToString(i) + "," + nombres[randomName] + "," + "Description...," + Convert.ToString(randomUrgencyNumber); // 
                tw.WriteLine(data);

            }
            tw.Close();

        }


        public static List<string> ReadFile(String filePath)
        {
            List<String> stringRequests = new List<String>();
            StreamReader reader = new StreamReader(filePath);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                stringRequests.Add(line);
            }

            return stringRequests;
        }
        


    }
}
