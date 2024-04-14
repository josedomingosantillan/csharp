namespace factorial;

public class Factorial
{

    public int valor;
    private int resultado=1;
    public int calcularFactorial()
    {
        for (int i = 1; i <= valor; i++)
        {
            resultado = valor * i;
        }
        return resultado;
    }
}