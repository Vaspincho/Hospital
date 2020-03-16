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


    static string checkString(string texto)
    {
        string cadena;

        do
        {
            Console.Write(texto + ": ");
            cadena = Console.ReadLine();

        } while (cadena.Length == 0);

        return cadena;
    }

    static void BuscaPaciente()
    {
        string pacienteBuscar;

        pacienteBuscar = checkString("Introduce el DNI del paciente");

        if (pacientes.ContainsKey(pacienteBuscar))
        {
            Console.WriteLine(pacientes[pacienteBuscar]);
        }
        else
        {
            Console.WriteLine("Paciente no encontrado");
        }

        menu();

    }
    static void PacienteTipoConsulta()
    {
        string consultaBuscar;
        int contador = 0;

        consultaBuscar = checkString("Introduce la consulta a buscar");
        Console.WriteLine("\nPacientes que han solicitado \"" + consultaBuscar + "\":");

        foreach (KeyValuePair<string, Paciente> dato in pacientes)
        {
            if (pacientes[dato.Key].ExisteConsulta(consultaBuscar))
            {
                Console.WriteLine(pacientes[dato.Key].Dni + ": " + pacientes[dato.Key].Nombre);
                contador++;
            }
        }
        Console.WriteLine("\nTotal " + contador + " pacientes\n");
        menu();
    }

    static void NuevaConsulta()
    {
        string dniPaciente;
        string datosNuevaConsulta;
        String[] datos;

        dniPaciente = checkString("Introduce el DNI del paciente");

        if (pacientes.ContainsKey(dniPaciente))
        {

            datosNuevaConsulta = checkString("Introduce los datos de la nueva consulta");

             datos = datosNuevaConsulta.Split(":");
           
            if (personalSanitario.ContainsKey(datos[1]))
            {
                
                pacientes[dniPaciente].NuevaConsulta(datos[0], personalSanitario[datos[1]]);
                
            } else
            {
                Console.WriteLine("Información no encontrada");
            }

        } else {
            Console.WriteLine("Información no encontrada");
        }

        menu();

}

    static void menu()
    {
        do
        {
            Console.WriteLine("1.- Buscar paciente.");
            Console.WriteLine("2.- Pacientes por tipo de consulta");
            Console.WriteLine("3.- Nueva consulta a paciente");
            Console.WriteLine("0.- Salir");
            Int32.TryParse(Console.ReadLine(), out opcion);

        } while (opcion < 0 || opcion > 3);

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
        personalSanitario.Add("211A", new Medico("211A", "Primer médico", "Anestesista"));
        personalSanitario.Add("212A", new Medico("212A", "Segundo médico", "Trauma"));
        personalSanitario.Add("213A", new Medico("213A", "Tercer médico", "Otorrino"));
        personalSanitario.Add("214A", new Medico("214A", "Cuarto médico", "Oftalmólogo"));
        personalSanitario.Add("215A", new Medico("215A", "Quinto médico", "Vascular"));
        
        personalSanitario.Add("311A", new Enfermero("311A", "Primer Enfermero", 1));
        personalSanitario.Add("312A", new Enfermero("312A", "Segundo Enfermero", 2));
        personalSanitario.Add("313A", new Enfermero("313A", "Tercer Enfermero", 3));
        personalSanitario.Add("314A", new Enfermero("314A", "Cuarto Enfermero", 4));
        personalSanitario.Add("315A", new Enfermero("315A", "Quinto Enfermero", 5));

        pacientes.Add("511A", new Paciente("511A", "Paciente Uno"));
        pacientes.Add("512A", new Paciente("512A", "Paciente Dos"));
        pacientes.Add("513A", new Paciente("513A", "Paciente Tres"));
        pacientes.Add("514A", new Paciente("514A", "Paciente Cuatro"));
        pacientes.Add("515A", new Paciente("515A", "Paciente Cinco"));

        pacientes["511A"].NuevaConsulta("a", personalSanitario["212A"]);
        pacientes["511A"].NuevaConsulta("Nefrología", personalSanitario["213A"]);
        pacientes["511A"].NuevaConsulta("Traumatología", personalSanitario["312A"]);
        pacientes["511A"].NuevaConsulta("Otorrino", personalSanitario["314A"]);

        pacientes["512A"].NuevaConsulta("a", personalSanitario["212A"]);
        pacientes["512A"].NuevaConsulta("Otorrino", personalSanitario["215A"]);
        pacientes["512A"].NuevaConsulta("Traumatología", personalSanitario["315A"]);
        pacientes["512A"].NuevaConsulta("a", personalSanitario["314A"]);

        pacientes["513A"].NuevaConsulta("b", personalSanitario["211A"]);
        pacientes["513A"].NuevaConsulta("Otorrino", personalSanitario["213A"]);
        pacientes["513A"].NuevaConsulta("Traumatología", personalSanitario["311A"]);
        pacientes["513A"].NuevaConsulta("Cirugía", personalSanitario["314A"]);

        pacientes["514A"].NuevaConsulta("b", personalSanitario["215A"]);
        pacientes["514A"].NuevaConsulta("Otorrino", personalSanitario["213A"]);
        pacientes["514A"].NuevaConsulta("Traumatología", personalSanitario["315A"]);
        pacientes["514A"].NuevaConsulta("Reumatología", personalSanitario["314A"]);
        
        pacientes["515A"].NuevaConsulta("c", personalSanitario["215A"]);
        pacientes["515A"].NuevaConsulta("Otorrino", personalSanitario["213A"]);
        pacientes["515A"].NuevaConsulta("Cirugía", personalSanitario["315A"]);
        pacientes["515A"].NuevaConsulta("Ginecología", personalSanitario["314A"]);


        // Inicia el menu
        menu();

    }
    }

