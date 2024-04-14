using System;
using Celulares;

namespace conexion_sp;
class ConexionSp
{
    public static void Main()
    {
        try
        {
            menu();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void menu()
    {
        Boolean salir = true;
        do
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1- Consultar Celulares Activos");
            Console.WriteLine("2- Consultar Celulares Inactivos");
            Console.WriteLine("3- Agregar Celular");
            Console.WriteLine("4- Inactivar Celular");
            Console.WriteLine("5- Modificar Celular");
            Console.WriteLine("6- Agregar Marca");
            Console.WriteLine("7- Inactivar Marca");
            Console.WriteLine("8- Agregar Compañia");
            Console.WriteLine("9- Inactivar Compañia");
            Console.WriteLine("10- Salir");
            int opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 1:
                ConsultarCelulares();
                    break;
                case 2:
                    ConsultarCelularesInactivos();
                    break;
                case 3:
                    AgregarCelular();
                    break;
                case 4:
                    EliminarCelular();
                    break;
                case 5:
                    Modificar_Celular();
                    break;
                case 6:
                    AgregarMarca();
                    break;
                case 7:
                    EliminarMarca();
                    break;
                case 8:
                    Agregarcompania();
                    break;
                case 9:
                    EliminarCompania();
                    break;
                case 10:
                    salir = false;
                    break;
            }
                
        } while (salir);
    }

    public static void ConsultarCelulares()
    {
        conec_Bd con = new conec_Bd();
        con.getCelulares();
    }
    public static void ConsultarCelularesInactivos()
    {
        conec_Bd con = new conec_Bd();
        con.getCelularesInactivos();
    }

    public static void AgregarCelular()
    {
        conec_Bd con = new conec_Bd();
        Console.WriteLine("Ingresa el nombre:");
        con.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa la descripción:");
        con.descripcion = Console.ReadLine();
        Console.WriteLine("Ingresa el id de la marca:");
        con.getMarca();
        con.marca = Console.ReadLine();
        Console.WriteLine("Ingresa el id de la compañia:");
        con.getCompania();
        con.compania = Console.ReadLine();
        Console.WriteLine("Ingresa el costo:");
        con.costo = Convert.ToDouble(Console.ReadLine());
        con.addCelular();
    }

    public static void EliminarCelular()
    {
        conec_Bd con = new conec_Bd();
        con.getCelulares();
        Console.WriteLine("Ingresa el id que 1quieres inactivar:");
        con.id = Convert.ToInt32(Console.ReadLine());

        if (con.ValidateCelular())
        {
            con.inactivarCelular();
        }
    }

    public static void Modificar_Celular()
    {
        
        conec_Bd con = new conec_Bd();
        con.getCelulares();
        Console.WriteLine("Ingresa el id que quieres modificar:");
        con.id = Convert.ToInt32(Console.ReadLine());

        if (con.ValidateCelular())
        {
            Console.WriteLine("Ingresa el nombre:");
            con.nombre= Console.ReadLine();
            con.getCompania();
            Console.WriteLine("Ingresa el id de la compañia:");
            con.compania= Console.ReadLine();
            con.updateCelular();
        }
    }

    public static void AgregarMarca()
    {
        conec_Bd con = new conec_Bd();
        Console.WriteLine("Ingresa el nombre de la marca:");
        con.nombre = Console.ReadLine();
        con.addMarca();
    }

    public static void EliminarMarca()
    {
        conec_Bd con = new conec_Bd();
        con.getMarca();
        Console.WriteLine("Ingresa el id que quieres inactivar:");
        con.id = Convert.ToInt32(Console.ReadLine());

        if (con.ValidateMarca())
        {
            con.inactivarMarca();
        }
    }

    public static void Agregarcompania()
    {
        conec_Bd con = new conec_Bd();
        Console.WriteLine("Ingresa el nombre de la compañia:");
        con.nombre = Console.ReadLine();
        con.addCompania();
    }

    public static void EliminarCompania()
    {
        conec_Bd con = new conec_Bd();
        con.getCompania();
        Console.WriteLine("Ingresa el id que quieres inactivar:");
        con.id = Convert.ToInt32(Console.ReadLine());

        if (con.ValidateCompania())
        {
            con.inactivarCompania();
        }
    }
}