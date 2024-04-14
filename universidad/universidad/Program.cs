using System;

namespace universidad;
class Universidad
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
            Console.WriteLine("4- Eliminar");
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
                    Eliminar();
                    break;
                case 5:
                    salir = false;
                    break;
            }
                
        } while (salir);
    }

    public static void Consultar()
    {
        conect_bd con = new conect_bd();
        con.consultar();
    }
    
    public static void Agregar()
    {
        conect_bd con = new conect_bd();
        Console.WriteLine("Ingresa el nombre del alumno:");
        con.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido paterno del alumno:");
        con.apellido_p = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido materno del alumno:");
        con.apellido_m = Console.ReadLine();
        Console.WriteLine("Ingresa la carrera del alumno:");
        con.carrera = Console.ReadLine();
        Console.WriteLine("Ingresa el turno del alumno:");
        con.turno = Console.ReadLine();
        con.agregar();
    }

    public static void Actualizar()
    {
        conect_bd con = new conect_bd();
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
        conect_bd con = new conect_bd();
        con.id = id;
        Console.WriteLine("Ingresa el nombre del alumno:");
        con.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido paterno del alumno:");
        con.apellido_p = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido materno del alumno:");
        con.apellido_m = Console.ReadLine();
        Console.WriteLine("Ingresa la carrera del alumno:");
        con.carrera = Console.ReadLine();
        Console.WriteLine("Ingresa el turno del alumno:");
        con.turno = Console.ReadLine();
        
        con.update();
    }
    
    public static void Eliminar()
    {
        conect_bd con = new conect_bd();
        Console.WriteLine("Ingresa el Id que quieres modificar");
        int id = Convert.ToInt32(Console.ReadLine());
        con.id = id;
        if (con.validarId())
        {
            delete(id);
        }
        else
        {
            Console.WriteLine("El id ingresado no se encontro");
        }
    }
    public static void delete(int id)
    {
        conect_bd con = new conect_bd();
        con.id = id;

        con.delete();
    }
}