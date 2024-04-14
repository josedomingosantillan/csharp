using MySql.Data.MySqlClient;
namespace conexion_sp;

public class connectar_bd
{
    public int id;
    public string nombre;
    public string apellido_p;
    public string apellido_m;
    public string carrera;
    public string turno;
    public string sexo;
    public string fecha_nacimiento;
    
    string connectionString = "server=127.0.0.1;user=root;password=12345;database=escuelas;";

    public void consultar()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "CALL escuelas.sp_getAllAlumnos()";
            MySqlCommand command = new MySqlCommand(query, connection);
        
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32("PersonaId");
                    nombre = reader.GetString("Alumno");
                    
                    sexo = reader.GetString("Sexo");
                    carrera= reader.GetString("carrera");
                    turno = reader.GetString("Turno");

                    Console.WriteLine($"Id: {id}, Nombre: {nombre}, Sexo: {sexo}, Carrera: {carrera}, Turno: {turno}");
                }
            }
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    public void agregar()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call escuelas.sp_insert_persona('{nombre}', '{apellido_p}','{apellido_m}', '{fecha_nacimiento}','{sexo}','{carrera}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Registro insertado correctamente");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al insertar el registro.");
            Console.WriteLine(e);
        }
    }

    public Boolean validarId()
    {
        using MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        String query = $"select * from tbl_alumnos where AlumnoId ='{id}'";
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
            Console.WriteLine(id);
            string query = $"call escuelas.sp_update_person({id}, '{nombre}', '{apellido_p}', '{apellido_m}');";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Registro actualizado correctamente");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al actualizar el registro.");
            Console.WriteLine(e);
        }
    }


    public void buscar()
    {
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = $"call escuelas.sp_getAlumnoId({id})";
            MySqlCommand command = new MySqlCommand(query, connection);
            
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32("PersonaId");
                    nombre = reader.GetString("Alumno");
                    
                    sexo = reader.GetString("Sexo");
                    carrera= reader.GetString("Grupo");
                    turno = reader.GetString("Turno");

                    Console.WriteLine($"Id: {id}, Nombre: {nombre}, Sexo: {sexo}, Carrera: {carrera}, Turno: {turno}");
                }
            }
            connection.Close();
        }
        catch (Exception e){
        Console.WriteLine("Ocurrio un error al buscar el registro.");
            Console.WriteLine(e);
        }
    }
}