using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesSoprteTecnico
{
    public class Menu
    {
        private SoporteTecnico soporteTecnico = new SoporteTecnico();

        public void MostrarMenu()
        {
            bool salir = false;

            do
            {
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Agregar solicitud de soporte");
                Console.WriteLine("2. Atender solicitud de mayor urgencia");
                Console.WriteLine("3. Visualizar solicitudes pendientes");
                Console.WriteLine("4. Actualizar urgencia de una solicitud");
                Console.WriteLine("5. Cargar solicitudes desde archivo");
                Console.WriteLine("6. Comparación de complejidades");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            soporteTecnico.AgregarSolicitud();
                            break;
                        case 2:
                            soporteTecnico.AtenderSolicitud();
                            break;
                        case 3:
                            soporteTecnico.VisualizarSolicitudes();
                            break;
                        case 4:
                            soporteTecnico.ActualizarUrgencia();
                            break;
                        case 5:
                            Console.Write("Ingrese la ruta del archivo TXT: ");
                            string filePath = Console.ReadLine();
                            soporteTecnico.CargarArchivo(filePath);
                            Console.WriteLine("Solicitudes cargadas desde el archivo.");
                            break;
                        case 6:
                            soporteTecnico.CompararComplejidades();
                            break;
                        case 7:
                            salir = true;
                            Console.WriteLine("¡Gracias por usar el programa!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida");
                }
            } while (!salir);
        }
    }

}
