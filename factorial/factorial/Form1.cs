namespace factorial;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void label1_Click(Object sender, EventArgs a)
    {
        
    }

    private void textBox1_TextChanged(Object sender, EventArgs e)
    {
        
    }

    private void button1_Click(Object sender, EventArgs e)
    {
        Factorial fac = new Factorial();
        fac.valor = Convert.ToInt32(textBox1.Text);
        Console.WriteLine(fac.calcularFactorial());
    }
}