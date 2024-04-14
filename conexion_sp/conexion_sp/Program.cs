using System;

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
            Console.WriteLine("1- Consultar");
            Console.WriteLine("2- Agregar");
            Console.WriteLine("3- Editar");
            Console.WriteLine("4- Buscar");
            Console.WriteLine("5- Salir");
            int opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 1:
                Consultar();
                    break;
                case 2:
                    Agregar();
                    break;
                case 3:
                    Actualizar();
                    break;
                case 4:
                    BuscarUsuario();
                    break;
                case 5:
                    salir = false;
                    break;
            }
                
        } while (salir);
    }

    public static void Consultar()
    {
        connectar_bd con = new connectar_bd();
        con.consultar();
    }
    
    public static void Agregar()
    {
        connectar_bd con = new connectar_bd();
        Console.WriteLine("Ingresa el nombre del alumno:");
        con.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido paterno del alumno:");
        con.apellido_p = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido materno del alumno:");
        con.apellido_m = Console.ReadLine();
        Console.WriteLine("Ingresa la fecha de nacimiento YYYY-MM-DD:");
        con.fecha_nacimiento = Console.ReadLine();
        Console.WriteLine("Ingresa el grupo del alumno ISC301-V / ISC301-M / ISC301-S:");
        con.carrera = Console.ReadLine();
        Console.WriteLine("Ingresa el sexo del alumno Masculino/Femenino:");
        con.sexo = Console.ReadLine();
        con.agregar();
    }

    public static void Actualizar()
    {
        connectar_bd con = new connectar_bd();
        Console.WriteLine("Ingresa el Id que quieres modificar");
        int id = Convert.ToInt32(Console.ReadLine());
        con.id = id;
        if (con.validarId())
        {
            update(id);
        }
        else
        {
            Console.WriteLine("El id ingresado no se encontro");
        }
    }

    public static void update(int id)
    {
        connectar_bd con = new connectar_bd();
        con.id = id;
        Console.WriteLine("Ingresa el nombre del alumno:");
        con.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido paterno del alumno:");
        con.apellido_p = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido materno del alumno:");
        con.apellido_m = Console.ReadLine();

        con.update();
    }
    
    public static void BuscarUsuario()
    {
        connectar_bd con = new connectar_bd();
        Console.WriteLine("Ingresa el Id que quieres buscar");
        int id = Convert.ToInt32(Console.ReadLine());
        con.id = id;
        if (con.validarId())
        {
            buscar(id);
        }
        else
        {
            Console.WriteLine("El id ingresado no se encontro");
        }
    }
    public static void buscar(int id)
    {
        connectar_bd con = new connectar_bd();
        con.id = id;

        con.buscar();
    }
}