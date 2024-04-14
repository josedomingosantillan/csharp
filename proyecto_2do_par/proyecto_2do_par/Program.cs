namespace proyecto_2do_par;

public class Principal
{
    
    public static void Main()
    {
        try
        {
            Boolean logueado = false;

            String datos = "", rol="";

            do
            {
                datos = login();
            } while (datos=="");
            if (datos!="")
            {
                logueado = true;
                rol=datos.Split('|')[4];
            }
            do
            {
                
                if (rol=="1")
                {
                    logueado=menuAdministrador();
                }else if (rol == "2")
                {
                    logueado=menuAlmacenista(datos.Split('|')[0]);
                }
                else if(rol=="3")
                {
                    logueado=menuVendedor();
                }
            } while (logueado);
            Main();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static String login()
    {
        conect_BD conectar = new conect_BD();
        Console.WriteLine("Bienvenido");
        Console.WriteLine("Ingresa tu usuario");
        conectar.usuario = Console.ReadLine();
        Console.WriteLine("Ingresa tu contraseña");
        conectar.passw = Console.ReadLine();

        return conectar.Login();
    }
    public static Boolean menuAdministrador()
    {
        Boolean salir = true;
        do
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1- Consultar");
            Console.WriteLine("2- Agregar");
            Console.WriteLine("3- Salir");
            int opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    consultarUsuarios();
                    break;
                case 2:
                    agregarUsuarios();
                    break;
                case 3:
                    salir = false;
                    break;
            }

            return salir;
        } while (salir);

        return salir;
    }
    
    public static Boolean menuAlmacenista(String id_usuario)
    {
        Boolean salir = true;
        do
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1- Consultar");
            Console.WriteLine("2- Agregar");
            Console.WriteLine("3- Salir");
            int opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    consultarProductos();                    
                    break;
                case 2:
                    agregarProducto(id_usuario);
                    break;
                case 3:
                    salir = false;
                    break;
            }
                return salir;
        } while (salir);
    }
    
    public static Boolean menuVendedor()
    {
        Boolean salir = true;
        do
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1- Vender");
            Console.WriteLine("2- Salir");
            int opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    venderProducto();
                    break;
                case 2:
                    salir = false;
                    break;
            }

            return salir;
        } while (salir);
    }

    public static void consultarUsuarios()
    {
        conect_BD conectar = new conect_BD();
        conectar.getUsers();
    }
    
    public static void agregarUsuarios()
    {
        conect_BD conectar = new conect_BD();
        
        Console.WriteLine("Ingresa el nombre");
        conectar.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa el apellido paterno");
        conectar.ape_p= Console.ReadLine();
        Console.WriteLine("Ingresa el apellido materno");
        conectar.ape_m= Console.ReadLine();
        conectar.getTypeUsers();
        Console.WriteLine("Ingresa el id del tipo de usuario");
        conectar.id_user = Console.ReadLine();
        Console.WriteLine("Ingresa el usuario");
        conectar.usuario= Console.ReadLine();
        Console.WriteLine("Ingresa la contraseña");
        conectar.passw= Console.ReadLine();
        conectar.addUsers();
    }
    
    public static void consultarProductos()
    {
        conect_BD conectar = new conect_BD();
        conectar.getProductos();
    }
    
    public static void agregarProducto(String id_usuario)
    {
        conect_BD conectar = new conect_BD();
        
        Console.WriteLine("Ingresa el nombre");
        conectar.nombre = Console.ReadLine();
        Console.WriteLine("Ingresa la cantidad");
        conectar.cantidad= Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingresa el precio");
        conectar.precio= Convert.ToDouble(Console.ReadLine());
        conectar.id_user = id_usuario;
        conectar.addProductos();
    }
    
    public static void venderProducto()
    {
        conect_BD conectar = new conect_BD();
        conectar.getProductosVender();
        Console.WriteLine("Ingresa el id del producto");
        conectar.id_producto = Console.ReadLine();
        Console.WriteLine("Ingresa la cantidad");
        conectar.cantidad= Convert.ToInt32(Console.ReadLine());

        if (conectar.ValidarExistencia())
        {
            conectar.upddateProductos();
        }
        else
        {
            Console.WriteLine("No se realizo la venta");
        }
        
    }
}