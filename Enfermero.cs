/*
 * Clase Enfermero, que hereda de PersonalHospital
 * */

public class Enfermero: PersonalHospital
{
    int numero;

    public Enfermero(string dni, string nombre, int numero): base(dni,nombre)
    {
        this.Numero = numero;
    }

    public int Numero { get => numero; set => numero = value; }

    public override string ToString()
    {
        return "enfermero/a " + base.ToString();
    }
}
