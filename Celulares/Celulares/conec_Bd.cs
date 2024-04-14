using MySql.Data.MySqlClient;

namespace Celulares;

public class conec_Bd
{
    public int id;
    public string nombre;
    public string descripcion;
    public string marca;
    public string compania;
    public double costo;
    string connectionString = "server=127.0.0.1;user=root;password=12345;database=celulares;";
    
    public void getMarca() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "call celulares.sp_getMarcas();";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string nombre = reader.GetString("nombre");

                    Console.WriteLine($"Id: {id}, Nombre: {nombre}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al consultar marcas.");
        }
    }
    
    public void getCompania() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "call celulares.sp_getCompania();";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string nombre = reader.GetString("nombre");

                    Console.WriteLine($"Id: {id}, Nombre: {nombre}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al consultar compañias.");
        }
    }
    public void getCelulares() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "call celulares.sp_getcelulares();";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32("id");
                    nombre = reader.GetString("nombre");
                    descripcion = reader.GetString("descripcion");
                    marca = reader.GetString("marca");
                    compania = reader.GetString("compania");
                    costo = reader.GetDouble("costo");
                    
                    Console.WriteLine($"Id: {id}, Nombre: {nombre}, Descripción: {descripcion}, Marca: {marca}, Compañia: {compania}, Costo: {costo}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al consultar celulares.");
        }
    }

    public void getCelularesInactivos() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "call celulares.sp_getcelularesinactivos();";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32("id");
                    nombre = reader.GetString("nombre");
                    descripcion = reader.GetString("descripcion");
                    marca = reader.GetString("marca");
                    compania = reader.GetString("compania");
                    costo = reader.GetDouble("costo");
                    
                    Console.WriteLine($"Id: {id}, Nombre: {nombre}, Descripción: {descripcion}, Marca: {marca}, Compañia: {compania}, Costo: {costo}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al consultar celulares.");
        }
    }
    public Boolean ValidateCelular()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"select * from celular where id ='{id}'";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return true;
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al validar celular.");
            return false;
        }
        Console.WriteLine("El id que ingresaste es incorrecto");
        return false;
    }
   
    public Boolean ValidateMarca()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"select * from marca where id ='{id}'";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return true;
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al validar marca.");
            return false;
        }
        Console.WriteLine("El id que ingresaste es incorrecto");
        return false;
    }
    
    public Boolean ValidateCompania()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"select * from compania where id ='{id}'";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return true;
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al validar compania.");
            return false;
        }
        Console.WriteLine("El id que ingresaste es incorrecto");
        return false;
    }
    public void addCompania()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"insert into compania values(null,'{nombre}',{true})";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Compania registrada correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al agregar la compañia.");
        }
    }
    
    public void addMarca()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"insert into marca values(null,'{nombre}',{true})";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Marca registrada correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al agregar la marca.");
        }
    }
    
    public void addCelular()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call celulares.sp_insertCelular('{nombre}','{descripcion}',{marca},{compania},'{costo}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Celular registrado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al agregar el celular.");
        }
    }
    
    public void updateCelular()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"update celular set nombre= '{nombre}',companiaId='{compania}' where id='{id}';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Celular actualizado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al actualizar el celular.");
        }
    }
    public void inactivarCelular()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"update celular set activo= '0' where id='{id}';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Celular inactivado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al inactivar el celular.");
        }
    }
    
    public void inactivarMarca()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"update marca set activo= '0' where id='{id}';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Marca inactivada correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al inactivar el marca.");
        }
    }
    
    public void inactivarCompania()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"update compania set activo= '0' where id='{id}';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Compania inactivada correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al inactivar el compania.");
        }
    }
}