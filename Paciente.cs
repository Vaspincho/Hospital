/*
 * Clase con información de los pacientes
*/
using System.Collections.Generic;

class Paciente
{
    private string dni;
    private string nombre;
    private List<Consulta> consultasRealizadas;

    public Paciente(string dni, string nombre)
    {
        this.Dni = dni;
        this.Nombre = nombre;
        consultasRealizadas = new List<Consulta>();
    }

    public string Dni { get => dni; set => dni = value; }
    public string Nombre { get => nombre; set => nombre = value; }

    public void NuevaConsulta(string t, PersonalHospital p)
    {
        consultasRealizadas.Add(new Consulta(t, p));
        consultasRealizadas.Sort();
    }

    //Comprueba la existencia de una consulta en el paciente
    public bool ExisteConsulta(string t)
    {
        
        for (int i = 0; i < consultasRealizadas.Count; i++)
        {
            if (consultasRealizadas[i].TipoConsulta.Equals(t))
            {
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        string imprimeConsulta = "\nPaciente: " + Nombre + ". DNI: " + Dni +
            "\n\nCosultas realizadas: \n\n";
        if (consultasRealizadas.Count == 0)
        {
            return imprimeConsulta += "\nEl paciente no tiene consultas almacenadas";
        }
   
        consultasRealizadas.ForEach(consulta => imprimeConsulta += consulta.ToString());

        return imprimeConsulta;
    }
}


