using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //esta es una referencia al conector de MySQL para NET que debe descargarse e instalarse con anterioridad

namespace MySQLAC
{
    class Conexion
    {
        private MySqlConnection connection; //la conexion en si
        private string server; //el servidor, usualmente localhost
        private string database; //el nombre de la base de datos
        private string uid; //el nombre del usuario accediendo a la bd
        private string password; // la constrasenia del usuario accediendo a la bd

        private MySqlCommand command; // para hacer queries no-select
        private MySqlDataReader reader; //para hacer queries de select


        public Conexion()
        {
            Initialize();
        }


        private void Initialize()
        {
            server = "localhost";
            database = "baseDePrueba";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("No se puede conectar con el servidor. Contacete al administrador");
                        break;

                    case 1045:
                        MessageBox.Show("Usuario o clave invalidos, reintente");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public DataTable Ejecutar(String query)
        {
            Console.WriteLine("QUERY=" + query);
            DataTable dt = null;

            this.OpenConnection();
            command = new MySqlCommand(query,connection);

            if (query.ToLower().Contains("select"))
            {
                reader = command.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
            }
            else
            {
                command.ExecuteNonQuery();
            }
            this.CloseConnection();
            return dt;
        }




    }
}
