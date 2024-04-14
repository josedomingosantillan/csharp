using MySql.Data.MySqlClient;
namespace universidad;

public class conect_bd
{
    public int id;
    public string nombre;
    public string apellido_p;
    public string apellido_m;
    public string carrera;
    public string turno;
    string connectionString = "server=127.0.0.1;user=root;password=12345;database=escuela;";

    public void consultar()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM tbl_alumnos";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32("id");
                    nombre = reader.GetString("nombre");
                    apellido_p = reader.GetString("apellido_p");
                    apellido_m = reader.GetString("appelido_m");
                    carrera= reader.GetString("carrera");
                    turno = reader.GetString("turno");

                    Console.WriteLine($"Id: {id}, Nombre: {nombre} {apellido_p} {apellido_m}, Carrera: {carrera}, Turno: {turno}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void agregar()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"insert into tbl_alumnos values(null, '{nombre}','{apellido_p}','{apellido_m}','{carrera}','{turno}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Registro insertado correctamente");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al insertar el registro.");
            Console.WriteLine(e);
            throw;
        }
    }

    public Boolean validarId()
    {
        using MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        String query = $"select * from tbl_alumnos where id='{id}'";
        MySqlCommand command = new MySqlCommand(query, connection);
        
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                return true;
            }
        }
        connection.Close();
        return false;
    }

    public void update()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"UPDATE tbl_alumnos set nombre='{nombre}',apellido_p='{apellido_p}',appelido_m='{apellido_m}',carrera='{carrera}',turno='{turno}' where id='{id}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Registro actualizado correctamente");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al actualizar el registro.");
            Console.WriteLine(e);
            throw;
        }
    }


    public void delete()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"delete from tbl_alumnos where id='{id}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Registro eliminado correctamente");
            connection.Close();
        }
        catch (Exception e){
        Console.WriteLine("Ocurrio un error al elimar el registro.");
            Console.WriteLine(e);
            throw;
        }
    }
}