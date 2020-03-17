/*
 * Sánchez Milán, Víctor Andrés
 * Práctica evaluable tema 7
 * 
 * Apartado 1 - Si
 * Apartado 2 - Si
 * Apartado 3 - Si
 * Apartado 4 - Si
 * Apartado 5.1 - Si
 * Apartado 5.2 - Si
 * Apartado 5.3 - Si
 */

using System;
using System.Collections.Generic;


class Program
{
    static int opcion;
    public static Dictionary<string, PersonalHospital> personalSanitario = new Dictionary<string, PersonalHospital>();
    public static Dictionary<string, Paciente> pacientes = new Dictionary<string, Paciente>();

    static string CheckString(string texto)
    {
        string cadena;

        do
        {
            Console.Write(texto + ": ");
            cadena = Console.ReadLine();

        } while (cadena.Length == 0);

        return cadena.ToUpper();
    }

    static void BuscaPaciente()
    {
        string pacienteBuscar;

        pacienteBuscar = CheckString("Introduce el DNI del paciente");

        if (pacientes.ContainsKey(pacienteBuscar.ToUpper()))
        {
            Console.WriteLine(pacientes[pacienteBuscar.ToUpper()]);
        }
        else
        {
            Console.WriteLine("Paciente no encontrado");
        }
        Menu();
    }
    static void PacienteTipoConsulta()
    {
        string consultaBuscar;
        int contador = 0;

        consultaBuscar = CheckString("Introduce la consulta a buscar");
        Console.WriteLine("\nPacientes que han solicitado \"" + consultaBuscar + "\":");

        foreach (KeyValuePair<string, Paciente> dato in pacientes)
        {
            if (pacientes[dato.Key].ExisteConsulta(consultaBuscar))
            {
                Console.WriteLine(pacientes[dato.Key].Dni + ": " + pacientes[dato.Key].Nombre+ "\n");
                contador++;
            }
        }

        // Sí hay un paciente usa el singular, sí hay varios el plural
        if (contador == 1)
        {
            Console.WriteLine("\nTotal " + contador + " paciente\n");
        }
        else
        {
            Console.WriteLine("\nTotal " + contador + " pacientes\n");
        }
       
        Menu();
    }

    static void NuevaConsulta()
    {
        string dniPaciente;
        string datosNuevaConsulta;
        String[] datos;

        dniPaciente = CheckString("Introduce el DNI del paciente");

        if (pacientes.ContainsKey(dniPaciente.ToUpper()))
        {

            datosNuevaConsulta = CheckString("Introduce los datos de la nueva consulta");

            datos = datosNuevaConsulta.Split(":");

            if (personalSanitario.ContainsKey(datos[1]))
            {
                pacientes[dniPaciente].NuevaConsulta(datos[0], personalSanitario[datos[1]]);
            }
            else
            {
                Console.WriteLine("Información no encontrada");
            }
        }
        else
        {
            Console.WriteLine("Información no encontrada");
        }

        Menu();

    }

    static void Menu()
    {
        do
        {
            Console.WriteLine("1.- Buscar paciente.");
            Console.WriteLine("2.- Pacientes por tipo de consulta");
            Console.WriteLine("3.- Nueva consulta a paciente");
            Console.WriteLine("0.- Salir");
            Console.Write("\nSelecciona una opción: ");
            

        } while (!Int32.TryParse(Console.ReadLine(), out opcion) ||opcion < 0 || opcion > 3);

        switch (opcion)
        {
            case 1:
                BuscaPaciente();
                break;
            case 2:
                PacienteTipoConsulta();
                break;
            case 3:
                NuevaConsulta();
                break;
            case 0:
                Console.WriteLine("Adios");
                break;
        }
    }


    static void Main(string[] args)
    {

        // Carga de datos 
        personalSanitario.Add("211A", new Medico("211A", "JUAN SUEÑO", "ANESTESISTA"));
        personalSanitario.Add("212A", new Medico("212A", "MARÍA HUESOS", "TRAUMATÓLOGO"));
        personalSanitario.Add("213A", new Medico("213A", "DOMINGO OREJAS", "OTORRINO"));
        personalSanitario.Add("214A", new Medico("214A", "CARMEN OJOS", "OFTALMÓLOGO"));
        personalSanitario.Add("215A", new Medico("215A", "FEDERICO CORAZÓN", "VASCULAR"));

        personalSanitario.Add("311A", new Enfermero("311A", "JUAN ALFONSO CAMILLA", 1));
        personalSanitario.Add("312A", new Enfermero("312A", "SEGUNDO AGUJAS", 2));
        personalSanitario.Add("313A", new Enfermero("313A", "PILAR GLUCOSA", 3));
        personalSanitario.Add("314A", new Enfermero("314A", "ROSA TIRITAS", 4));
        personalSanitario.Add("315A", new Enfermero("315A", "JUAN CARLOS PRUEBAS", 5));

        pacientes.Add("511A", new Paciente("511A", "DOLORES CABEZA"));
        pacientes.Add("512A", new Paciente("512A", "MANUEL PIES"));
        pacientes.Add("513A", new Paciente("513A", "ANDRÉS QUEJAS"));
        pacientes.Add("514A", new Paciente("514A", "MANUELA RODILLAS"));
        pacientes.Add("515A", new Paciente("515A", "GENARO HÚMERO"));

        pacientes["511A"].NuevaConsulta("UROLOGÍA", personalSanitario["212A"]);
        pacientes["511A"].NuevaConsulta("NEFROLOGÍA", personalSanitario["213A"]);
        pacientes["511A"].NuevaConsulta("TRAUMATOLOGÍA", personalSanitario["312A"]);
        pacientes["511A"].NuevaConsulta("OTORRINO", personalSanitario["314A"]);

        pacientes["512A"].NuevaConsulta("OFTALMOLOGÍA", personalSanitario["212A"]);
        pacientes["512A"].NuevaConsulta("OTORRINO", personalSanitario["215A"]);
        pacientes["512A"].NuevaConsulta("TRAUMATOLOGÍA", personalSanitario["315A"]);
        pacientes["512A"].NuevaConsulta("CIRUGÍA TORÁCICA", personalSanitario["314A"]);

        pacientes["513A"].NuevaConsulta("GINECOLOGÍA", personalSanitario["211A"]);
        pacientes["513A"].NuevaConsulta("OTORRINO", personalSanitario["213A"]);
        pacientes["513A"].NuevaConsulta("TRAUMATOLOGÍA", personalSanitario["311A"]);
        pacientes["513A"].NuevaConsulta("CIRUGÍA", personalSanitario["314A"]);

        pacientes["514A"].NuevaConsulta("CARDIOVASCULAR", personalSanitario["215A"]);
        pacientes["514A"].NuevaConsulta("OTORRINO", personalSanitario["213A"]);
        pacientes["514A"].NuevaConsulta("TRAUMATOLOGÍA", personalSanitario["315A"]);
        pacientes["514A"].NuevaConsulta("REUMATOLOGÍA", personalSanitario["314A"]);

        pacientes["515A"].NuevaConsulta("CIRUGÍA", personalSanitario["215A"]);
        pacientes["515A"].NuevaConsulta("OTORRINO", personalSanitario["213A"]);
        pacientes["515A"].NuevaConsulta("CIRUGÍA", personalSanitario["315A"]);
        pacientes["515A"].NuevaConsulta("GINECOLOGÍA", personalSanitario["314A"]);


        // Inicia el menu
        Menu();

    }
}
