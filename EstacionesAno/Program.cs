using System;
class Program
{
    static void Main()
    {
        string mes = IngresoMes(); //siempre es necesario declarar el tipo de dato de la variable
        string estacion = Estacion(mes);
        Console.WriteLine($"El mes de {mes} corresponde a la estación de {estacion}");
    }

    static string IngresoMes()
    {
        //se crea una lista con los meses del año
        string[] meses = {"enero", "febrero", "marzo", "abril", "mayo", "junio", "julio","agosto", "setiembre", "octubre", "noviembre", "diciembre"};
        bool mesValido = false;
        string mes = "";
        //al tener una lista de los meses, es más fácil la validación, ya que se puede verificar si el mes ingresado por el usuario se encuentra en la lista de meses. Si el mes es válido, se asigna a la variable "mes" y se sale del ciclo. Si el mes no es válido, se muestra un mensaje de error y se vuelve a solicitar al usuario que ingrese un mes.
        do
        {
            Console.Write("Ingrese cualquier mes del año (Enero a Diciembre): ");
            mes = (Console.ReadLine() ?? "").ToLower();
            if (meses.Contains(mes)) {
                mesValido = true;
            }
            else
            {
                Console.WriteLine("Mes no válido.");
            }
        }
        while (!mesValido);
        return mes;
    }
    static string Estacion(string mes)
    {
        //el switch siempre requiere para su buen funcionamiento un default, el cual se ejecuta cuando ninguna de las opciones anteriores se cumple. En este caso, el default se utiliza para manejar el caso en el que el mes ingresado por el usuario no sea válido, es decir, no se encuentre en la lista de meses. Si el mes no es válido, se lanza una excepción con un mensaje de error indicando que el mes es inválido.
        switch (mes)
        {
            case "enero":
            case "febrero":
            case "marzo":
                return "verano";
            case "abril":
            case "mayo":
            case "junio":
                return "otoño";
            case "julio":
            case "agosto":
            case "setiembre":
                return "invierno";
            case "octubre":
            case "noviembre":
            case "diciembre":
                return "primavera";
            default:
                throw new ArgumentException("Mes inválido", nameof(mes));
        }
    } 
}