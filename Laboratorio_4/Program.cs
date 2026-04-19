using System;

namespace AcademiaPreuniversitaria
{
    // =====================================================
    // CLASE ESTUDIANTE (Encapsulamiento)
    // =====================================================
    class Estudiante
    {
        private string _codigo;
        private string _nombre;
        private double _nota1;
        private double _nota2;
        private double _nota3;

        public Estudiante(string codigo, string nombre,
                          double nota1, double nota2, double nota3)
        {
            _codigo = codigo;
            _nombre = nombre;
            _nota1 = nota1;
            _nota2 = nota2;
            _nota3 = nota3;
        }

        public string Codigo => _codigo;
        public string Nombre => _nombre;
        public double Nota1 => _nota1;
        public double Nota2 => _nota2;
        public double Nota3 => _nota3;

        public double ObtenerPromedio()
        {
            return (_nota1 + _nota2 + _nota3) / 3.0;
        }

        public string ObtenerCondicion()
        {
            double promedio = ObtenerPromedio();

            if (promedio >= 13)
                return "Aprobado";
            else if (promedio >= 10)
                return "Sustitutorio";
            else
                return "Desaprobado";
        }
    }

    // =====================================================
    // PROGRAMA PRINCIPAL
    // =====================================================
    class Program
    {
        static void Main(string[] args)
        {
            MostrarBienvenida();

            int totalEstudiantes = LeerCantidadEstudiantes();

            ProcesarEstudiantes(totalEstudiantes);

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // -------------------------------------------------
        static void MostrarBienvenida()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("  ACADEMIA PREUNIVERSITARIA");
            Console.WriteLine("  SISTEMA DE REGISTRO DE NOTAS");
            Console.WriteLine("==========================================\n");
            Console.WriteLine("Bienvenido/a al sistema de gestión de notas.");
            Console.WriteLine("Aquí podrá registrar y consultar las notas de sus estudiantes.\n");
        }

        // -------------------------------------------------
        static int LeerCantidadEstudiantes()
        {
            int cantidad;
            bool valido = false;

            do
            {
                Console.Write("¿Cuántos estudiantes desea registrar? ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out cantidad) && cantidad > 0)
                    valido = true;
                else
                    Console.WriteLine("Ingrese un número válido mayor que 0.\n");

            } while (!valido);

            return cantidad;
        }

        // =====================================================
        // Procesa estudiante por estudiante
        // =====================================================
        static void ProcesarEstudiantes(int total)
        {
            int aprobados = 0;
            int desaprobados = 0;
            double sumaPromedios = 0;

            // guardamos el reporte 
             string filasReporte =
                 "Codigo   Nombre            Nota1  Nota2  Nota3  Condicion\n" +
                "-------------------------------------------------------------\n";

            for (int i = 0; i < total; i++)
            {
                Console.WriteLine($"\n── Estudiante {i + 1} de {total} ──");

                string codigo = LeerTexto("Código : ");
                string nombre = LeerTexto("Nombre : ");
                double nota1 = LeerNota("Nota 1 : ");
                double nota2 = LeerNota("Nota 2 : ");
                double nota3 = LeerNota("Nota 3 : ");

                Estudiante est = new Estudiante(
                    codigo, nombre, nota1, nota2, nota3);

                double promedio = est.ObtenerPromedio();
                string condicion = est.ObtenerCondicion();

                if (condicion == "Aprobado")
                    aprobados++;
                else if (condicion == "Desaprobado")
                    desaprobados++;

                sumaPromedios += promedio;

                // Guardamos solo TEXTO
                    filasReporte +=
                        $"{est.Codigo,-8} " +
                        $"{est.Nombre,-16} " +
                        $"{est.Nota1,6:F1} " +
                        $"{est.Nota2,6:F1} " +
                        $"{est.Nota3,6:F1} " +
                        $"{condicion,-12}\n";
            }

            MostrarReporte(total, filasReporte,
                           aprobados, desaprobados, sumaPromedios);
        }

        // -------------------------------------------------
        static string LeerTexto(string mensaje)
        {
            string texto;

            do
            {
                Console.Write(mensaje);
                texto = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(texto))
                    Console.WriteLine("Campo obligatorio.");

            } while (string.IsNullOrEmpty(texto));

            return texto;
        }

        // -------------------------------------------------
        static double LeerNota(string mensaje)
        {
            double nota;
            bool valido = false;

            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out nota)
                    && nota >= 0 && nota <= 20)
                    valido = true;
                else
                    Console.WriteLine("Nota válida entre 0 y 20.");

            } while (!valido);

            return nota;
        }

        // =====================================================
        // REPORTE FINAL 
        // =====================================================
        static void MostrarReporte(
            int total,
            string filas,
            int aprobados,
            int desaprobados,
            double sumaPromedios)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("   REPORTE FINAL DE NOTAS POR ESTUDIANTE");
            Console.WriteLine("==========================================\n");
            Console.Write(filas);

            double promedioGeneral = sumaPromedios / total;

            Console.WriteLine("\n► Total estudiantes : " + total);
            Console.WriteLine("► Aprobados         : " + aprobados);
            Console.WriteLine("► Sustitutorio      : " + (total - aprobados - desaprobados));
            Console.WriteLine("► Desaprobados      : " + desaprobados);
            Console.WriteLine($"► Promedio general  : {promedioGeneral:F2}");
        }
    }
}