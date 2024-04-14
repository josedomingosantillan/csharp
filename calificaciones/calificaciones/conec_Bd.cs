using MySql.Data.MySqlClient;

namespace Calificaciones;

public class conec_Bd
{
    public int id;
    public string nombre;
    public string apellido_p;
    public string apellido_m;
    public string id_grupo;
    public double cal1;
    public double cal2;
    string connectionString = "server=127.0.0.1;user=root;password=12345;database=calificaciones;";
    
    public void getAlumnos() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "call calificaciones.getAlumnos();";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32("id");
                    nombre = reader.GetString("nombre");
                    cal1 = reader.GetDouble("cal1");
                    cal2 = reader.GetDouble("cal2");
                    double final = reader.GetDouble("final");

                    Console.WriteLine($"Id: {id}, Nombre: {nombre}, Cal. 1: {cal1}, Cal. 2: {cal2}, Final: {final}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Ocurrio un error al consultar alumnos.");
        }
    }
    
    public void getAlumnosSin() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "select * from alumno";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32("id");
                    nombre = reader.GetString("nombre") + " " + reader.GetString("apellido_p" )+ " " + reader.GetString("apellido_m");

                    Console.WriteLine($"Id: {id}, Nombre: {nombre}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Ocurrio un error al consultar alumnos.");
        }
    }
    public void getGrupos() {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "select * from grupos";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    String nombre = reader.GetString("nombre");

                    Console.WriteLine($"Id: {id}, Nombre: {nombre}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al consultar grupos sin calificaciones.");
        }
    }
    

    public Boolean ValidateAlumno()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"select * from alumno where id ='{id}'";
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
            Console.WriteLine("Ocurrio un error al validar Alumno.");
            return false;
        }
        Console.WriteLine("El id que ingresaste es incorrecto");
        return false;
    }
   

    public void addAlumno()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call calificaciones.insertAlumno('{nombre}','{apellido_p}','{apellido_m}',{id_grupo})";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Alumno registrado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al agregar alumno.");
        }
    }

    
    public void insertCalificaciones()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"insert into calificaciones values(null,'{id}','{cal1}','{cal2}','{Math.Round((cal1+cal2)/2)}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Calificación agregada correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al agregar calificación.");
        }
    }
}