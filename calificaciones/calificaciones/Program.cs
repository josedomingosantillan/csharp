using System;
using Calificaciones;

namespace calificaciones;
class Calificaciones
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
            Console.WriteLine("1- Agregar Alumno");
            Console.WriteLine("2- Consultar Alumnos");
            Console.WriteLine("3- Capturar calificaciones");
            Console.WriteLine("4- Salir");
            int opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    AddAlumnos();
                    break;
                case 2:
                    ConsultarAlumnos();
                    break;
                case 3:
                    CaputarCalificaciones();
                    break;
                case 4:
                    salir = false;
                    break;
            }
                
        } while (salir);
    }

    public static void ConsultarAlumnos()
    {
        conec_Bd conec = new conec_Bd();
        conec.getAlumnos();
    }

    public static void AddAlumnos()
    {
        conec_Bd conec = new conec_Bd();
        Console.WriteLine("Ingresa el nombre del alumno");
        conec.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido paterno del alumno");
        conec.apellido_p = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido materno del alumno");
        conec.apellido_m = Console.ReadLine();
        
        conec.getGrupos();
        Console.WriteLine("Ingresa el id del grupo");
        conec.id_grupo = Console.ReadLine();
        
        conec.addAlumno();
    }
    
    public static void CaputarCalificaciones()
    {
        conec_Bd conec = new conec_Bd();
        conec.getAlumnosSin();
        
        Console.WriteLine("Ingresa el id del alumno");
        conec.id = Convert.ToInt32(Console.ReadLine());

        if (conec.ValidateAlumno())
        {
            Console.WriteLine("Ingresa la calificación 1:");
            conec.cal1 = Convert.ToDouble(Console.ReadLine());
            if (conec.cal1>10 || conec.cal1<0)
            {
                Console.WriteLine("Calificación incorrecta");
                return;
            }
        
            Console.WriteLine("Ingresa la calificación 2:");
            conec.cal2 = Convert.ToDouble(Console.ReadLine());
            if (conec.cal2>10 || conec.cal2<0)
            {
                Console.WriteLine("Calificación incorrecta");
                return;
            }
            conec.insertCalificaciones();
        }
    }
    
}