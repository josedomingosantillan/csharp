using MySql.Data.MySqlClient;

namespace proyecto_2do_par;

public class conect_BD
{
    public String usuario;
    public String passw;
    public String nombre;
    public String ape_p;
    public String ape_m;
    public String id_user;
    public String id_producto;
    public int cantidad;
    public double precio;
    string connectionString = "server=127.0.0.1;user=root;password=12345;database=tienda;";
    
    
    public String Login() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"select * from users where username= '{usuario}' and passw='{passw}'";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return $"{reader.GetInt32("id")}|{reader.GetString("nombre")}|{reader.GetString("apellido_p")}|{reader.GetString("apellido_m")}|{reader.GetInt32("user_type_id")}";
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al iniciar sesión.");
            return "";
        }
        Console.WriteLine("El usuario y/o la contraseña son incorrectos.");
        return "";
    }
    
    public void getUsers() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call getUsers()";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader.GetInt32("id")}, Nombre: {reader.GetString("nombre")} {reader.GetString("apellido_p")} {reader.GetString("apellido_m")}, Tipo de usuario: {reader.GetString("tipo")}, Usuario: {reader.GetString("username")}, Contraseña: {reader.GetString("passw")}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al iniciar sesión.");
        }
    }
    
    public Boolean ValidarExistencia() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"select * from productos where id = {id_producto}";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetInt32("cantidad")>=cantidad)
                    {
                        return true;
                    }
                }
                
            }

            
            connection.Close();
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al iniciar sesión.");
            return false;
        }
    }
    
    public void getProductos() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call getProductos()";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader.GetInt32("id")}, Nombre: {reader.GetString("nombre")}, Cantidad: {reader.GetInt32("cantidad")}, Precio: {reader.GetDouble("precio")}, Usuario que lo agrego: {reader.GetString("username")}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al iniciar sesión.");
        }
    }
    
    public void getProductosVender() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call getProductos()";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetInt32("cantidad") >0)
                    {
                        Console.WriteLine($"Id: {reader.GetInt32("id")}, Nombre: {reader.GetString("nombre")}, Cantidad: {reader.GetInt32("cantidad")}");
                    }
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al iniciar sesión.");
        }
    }
    
    public void getTypeUsers() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call getTipodeUuarios()";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader.GetInt32("id")}, Nombre: {reader.GetString("nombre")}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al iniciar sesión.");
        }
    }
    
    public void addUsers() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call insertUser('{nombre}','{ape_p}','{ape_m}',{id_user},'{usuario}','{passw}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Usuario registrado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al insertar usuario");
        }
    }
    
    public void addProductos() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            if (cantidad <0 || precio <0)
            {
                Console.WriteLine("El precio o la cantidad no pueden ser menor que 0");
                return;
            }
            string query = $"call insertProductos('{nombre}',{cantidad},{precio}, {id_user})";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Producto registrado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al insertar producto");
        }
    }
    
    public void upddateProductos() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"update productos set cantidad= cantidad - {cantidad} where id= {id_producto}";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Producto vendido correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al vender producto");
        }
    }
}