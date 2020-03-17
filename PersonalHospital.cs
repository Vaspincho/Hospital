/*
 * Clase con el personal sanitario del hospital
 * */

public abstract class PersonalHospital
    {
        protected string dni;
        protected string nombre;

    public string Dni { get => dni; set => dni = value; }
    public string Nombre { get => nombre; set => nombre = value; }

    public PersonalHospital(string dni, string nombre)
    {
        this.Dni = dni;
        this.Nombre = nombre;
    }
    public override string ToString()
    {
        return Nombre;
    }
}
