using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesSoprteTecnico
{
    public class SoporteTecnico
    {
        static PriorityQueue<SolicitudSoporteTecnico> Solicitud = new PriorityQueue<SolicitudSoporteTecnico>((x, y) => y.Urgencia.CompareTo(x.Urgencia));
        private static int i = 1;

        public void AgregarSolicitud()
        {
            Console.WriteLine();
            Console.WriteLine("Ingrese los datos de la solicitud:");
            Console.WriteLine($"Número de solicitud: {i}");

            Console.Write("Nombre del cliente: ");
            string nombre = Console.ReadLine();

            Console.Write("Descripción del problema: ");
            string descripcion = Console.ReadLine();

            Console.Write("Nivel de urgencia: ");
            int urgencia = int.Parse(Console.ReadLine());

            SolicitudSoporteTecnico solicitud = new SolicitudSoporteTecnico
            {
                NumersoSolicitud = i,
                Nombre = nombre,
                Descripcion = descripcion,
                Urgencia = urgencia
            };

            Solicitud.Enqueue(solicitud);
            Console.WriteLine();
            Console.WriteLine("Solicitud agregada correctamente.");
            i++;
            Console.WriteLine();
        }

        public void AtenderSolicitud()
        {
            Console.WriteLine();
            if (Solicitud.Count > 0)
            {
                SolicitudSoporteTecnico solicitud = Solicitud.Dequeue();
                Console.WriteLine("Atendiendo solicitud de mayor urgencia:");
                Console.WriteLine($"Número de solicitud: {solicitud.NumersoSolicitud}");
                Console.WriteLine($"Nombre del cliente: {solicitud.Nombre}");
                Console.WriteLine($"Descripción del problema: {solicitud.Descripcion}");
                Console.WriteLine($"Nivel de urgencia: {solicitud.Urgencia}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No hay solicitudes pendientes para atender");
                Console.WriteLine();
            }
        }

        public void VisualizarSolicitudes()
        {
            Console.WriteLine();
            if (Solicitud.Count > 0)
            {
                Console.WriteLine("Lista de solicitudes pendientes en orden de prioridad:");
                Console.WriteLine();

                IEnumerable<SolicitudSoporteTecnico> elementos = Solicitud.GetElements();
                // Crear una copia de la cola con el mismo comparador
                var copiaSolicitud = new PriorityQueue<SolicitudSoporteTecnico>(Solicitud.comparison);

                // Agregar elementos de la cola original a la nueva cola (sin quitarlos)
                foreach (var solicitud in elementos)
                {
                    copiaSolicitud.Enqueue(solicitud);
                }
                foreach (var solicitud in copiaSolicitud.GetElements())
                {
                    Console.WriteLine($"Número de solicitud: {solicitud.NumersoSolicitud}");
                    Console.WriteLine($"Nombre del cliente: {solicitud.Nombre}");
                    Console.WriteLine($"Descripción del problema: {solicitud.Descripcion}");
                    Console.WriteLine($"Nivel de urgencia: {solicitud.Urgencia}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No hay solicitudes pendientes para visualizar.");
                Console.WriteLine();
            }
        }

        public void ActualizarUrgencia()
        {
            Console.WriteLine();
            if (Solicitud.Count > 0)
            {
                Console.Write("Ingrese el número de solicitud que desea actualizar: ");
                Console.WriteLine();
                if (int.TryParse(Console.ReadLine(), out int numeroSolicitud))
                {
                    // Buscamos la solicitud con el número especificado en la cola
                    SolicitudSoporteTecnico solicitudExistente = null;
                    foreach (var solicitud in Solicitud.GetElements())
                    {
                        if (solicitud.NumersoSolicitud == numeroSolicitud)
                        {
                            solicitudExistente = solicitud;
                            break;
                        }
                    }

                    if (solicitudExistente != null)
                    {
                        Console.Write($"La urgencia actual de la solicitud {numeroSolicitud} es {solicitudExistente.Urgencia}.\n");
                        Console.Write("Ingrese la nueva urgencia (un valor entero): ");
                        if (int.TryParse(Console.ReadLine(), out int nuevaUrgencia))
                        {
                            // Actualizamos la urgencia de la solicitud
                            solicitudExistente.Urgencia = nuevaUrgencia;
                            Console.WriteLine($"Urgencia actualizada correctamente para la solicitud {numeroSolicitud}.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("La entrada no es válida. La urgencia debe ser un valor entero.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ninguna solicitud con el número {numeroSolicitud}.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("La entrada no es válida. El número de solicitud debe ser un valor entero.");
                    Console.WriteLine();

                }
            }
            else
            {
                Console.WriteLine("No hay solicitudes para actualizar");
                Console.WriteLine();
            }
        }

        public void CargarArchivo(string filePath)
        {
            try
            {
                using (StreamReader lector = new StreamReader(filePath))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(',');
                        if (partes.Length == 4)
                        {
                            int numeroSolicitud;
                            if (int.TryParse(partes[0], out numeroSolicitud))
                            {
                                string nombre = partes[1];
                                string descripcion = partes[2];
                                int urgencia;
                                if (int.TryParse(partes[3], out urgencia))
                                {
                                    SolicitudSoporteTecnico solicitud = new SolicitudSoporteTecnico
                                    {
                                        NumersoSolicitud = numeroSolicitud,
                                        Nombre = nombre,
                                        Descripcion = descripcion,
                                        Urgencia = urgencia
                                    };

                                    Solicitud.Enqueue(solicitud);
                                    Console.WriteLine($"Solicitud {numeroSolicitud} cargada desde el archivo.");
                                }
                                else
                                {
                                    Console.WriteLine($"Error en la línea: {linea}. La urgencia debe ser un valor entero.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Error en la línea: {linea}. El número de solicitud debe ser un valor entero.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error en la línea: {linea}. El formato de la línea no es válido.");
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El archivo '{filePath}' no se encontró.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el archivo: {ex.Message}");
            }
        }

        public void CompararComplejidades()
        {
            int[] Tamanhos = { 10, 100, 1000, 10000, 100000, 1000000 }; // Tamaños de prueba
            foreach (int tamanho in Tamanhos)
            {
                Console.WriteLine($"Comparación de complejidades para {tamanho} solicitudes:");
                Console.WriteLine();

                // Medir el tiempo de encolar y desencolar solicitudes
                RealizarPruebas(tamanho);

                Console.WriteLine();
            }
        }

        public void RealizarPruebas(int numeroSolicitudes)
        {
            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();

            // Crear un conjunto de prueba con solicitudes aleatorias
            List<SolicitudSoporteTecnico> Prueba = new List<SolicitudSoporteTecnico>();
            for (int i = 0; i < numeroSolicitudes; i++)
            {
                SolicitudSoporteTecnico solicitud = new SolicitudSoporteTecnico
                {
                    NumersoSolicitud = i + 1,
                    Nombre = "Cliente" + i,
                    Descripcion = "Problema #" + i,
                    Urgencia = random.Next(1, 11) // Niveles de urgencia aleatorios del 1 al 10
                };
                Prueba.Add(solicitud);
            }

            // Medir el tiempo de encolar las solicitudes
            stopwatch.Start();
            foreach (var solicitud in Prueba)
            {
                Solicitud.Enqueue(solicitud);
            }
            stopwatch.Stop();
            Console.WriteLine($"Tiempo de encolar {numeroSolicitudes} solicitudes: {stopwatch.ElapsedMilliseconds} ms");

            // Medir el tiempo de desencolar las solicitudes
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < numeroSolicitudes; i++)
            {
                SolicitudSoporteTecnico solitud = Solicitud.Dequeue();
            }
            stopwatch.Stop();
            Console.WriteLine($"Tiempo de desencolar {numeroSolicitudes} solicitudes: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
    

}
