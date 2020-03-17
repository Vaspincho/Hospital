/*
 * Clase con información de las consultas
*/
using System;

class Consulta : IComparable<Consulta>
{
    private string tipoConsulta;
    private PersonalHospital personaAtendio;

    public Consulta(string tipoConsulta, PersonalHospital personaAtendio)
    {
        this.TipoConsulta = tipoConsulta;
        this.PersonaAtendio = personaAtendio;
    }

    public string TipoConsulta { get => tipoConsulta; set => tipoConsulta = value; }
    public PersonalHospital PersonaAtendio { get => personaAtendio; set => personaAtendio = value; }
    public override string ToString()
    {
        return "- " + TipoConsulta + " (atendido por " + PersonaAtendio.ToString() + ")\n\n";
    }

    public int CompareTo(Consulta otraConsulta)
    {
        return TipoConsulta.CompareTo(otraConsulta.tipoConsulta);
    }

}
