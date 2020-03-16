public class Medico: PersonalHospital
{
    private string especialidad;

    public string Especialidad { get => especialidad; set => especialidad = value; }


    public Medico(string dni, string nombre, string especialidad) :
            base(dni, nombre)
    {
        this.Especialidad = especialidad;
    }


    public override string ToString()
        {
            return base.ToString();
        }
    }

