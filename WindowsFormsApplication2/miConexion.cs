using System;
using System.Collections.Generic;
using System.Data; // Agregamos por que no viene por default
using System.Data.SqlClient; // Agregamos por que no viene por default
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class miConexion
    {
        string _connectionString = "Data Source= LAPTOP-EQUIPO\\SQLEXPRESS; initial catalog= ControlGastos; integrated Security= true";
        SqlConnection oCon;
        SqlCommand oCmd;
        SqlDataAdapter oAdapter;
        SqlDataReader oDr;
        DataTable oTable;

        public miConexion()
        {
            oCon = new SqlConnection(_connectionString);
        }
        public void Abrir()
        {
            oCon.Open();
        }
        public void Cerrar()
        {
            oCon.Close();
        }

        // Paul

        /// <summary>
        /// Método utilizado para insertar, modificar o eliminar datos de una base de datos
        /// </summary>
        /// <param name="StoreProcedure">Nombre del Procedimiento que se ejecutará en la base de datos</param>
        /// <param name="parametros">Listado de parametros</param>
        /// <returns>Número de registros insertados, alterados o eleminados de la base de datos</returns>
        public int EjecutaNonQuery(string StoreProcedure, List<SqlParameter> parametros)
        {
            int _correcto = 0;
            try
            {
                oCon.Open();
                oCmd = new SqlCommand();
                oCmd.Connection = oCon;
                oCmd.CommandText = StoreProcedure;
                oCmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in parametros)
                {
                    oCmd.Parameters.Add(param);
                }
                _correcto = oCmd.ExecuteNonQuery(); // arroja 1 ó 0 si se ejecuto correctamente 
            }

            /*
                Cuando se produce una excepción, Common Language Runtime (CLR) busca la 
                instrucción catch que controla esta excepción.Si el método que se ejecuta 
                actualmente no contiene un bloque catch, CLR busca el método que llamó el método actual,
                y así sucesivamente hasta la pila de llamadas.Si no existe ningún bloque catch, CLR muestra
                al usuario un mensaje de excepción no controlada y detiene la ejecución del programa.
            */

            catch (Exception ex) // Para checar si hay alguna excepcion 
            {                    // le apodamos ex nomas por poner un nombre de variable
                throw;
            }
            finally
            { /*
                Un uso común de catch y finally consiste en obtener y 
                utilizar recursos en un bloque try, tratar circunstancias excepcionales 
                en el bloque catch y liberar los recursos en el bloque finally.
                */
                oCon.Close(); // si todo sale bien 
            }
                return _correcto;
        }

        /// <summary>
        /// Método utilizado para obtener datos que serán visualizados dentro de un componente
        /// </summary>
        /// <param name="StoreProcedure">Nombre del procedimiento</param>
        /// <returns></returns>
        public DataTable ObtenerDatos(string StoreProcedure)
        {
            oTable = new DataTable();
            try
            {
                oCon.Open();
                oCmd = new SqlCommand();
                oCmd.Connection = oCon;
                oCmd.CommandText = StoreProcedure;
                oCmd.CommandType = CommandType.StoredProcedure;

                oAdapter = new SqlDataAdapter(oCmd);
                oAdapter.Fill(oTable);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                oCon.Close();
            }

            return oTable;
        }

        /// <summary>
        /// Método utilizado para llenar un DataGridView
        /// </summary>
        /// <param name="StoreProcedure">Nombre del procedure</param>
        /// <param name="Parametros">Nombre del procedimiento</param>
        /// <returns></returns>
        public DataTable TraerDatosConParametros(string StoreProcedure, List<SqlParameter> parametros)
        {
            oTable = new DataTable();            
            try
            {
                oCon.Open();
                oCmd = new SqlCommand();
                oCmd.Connection = oCon;
                oCmd.CommandText = StoreProcedure;
                oCmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in parametros)
                {
                    oCmd.Parameters.Add(param);
                }

                oAdapter = new SqlDataAdapter(oCmd);
                oAdapter.Fill(oTable);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                oCon.Close();
            }

            return oTable;
        }

        /// <summary>
        /// Método utilizado para traer una columna de la base de datos
        /// </summary>
        /// <param name="StoreProcedure">Nombre del procedure</param>
        /// <returns></returns>
        public List<string> TraerDatos(string StoreProcedure)
        {
            List<string> Datos = new List<string>();//ES PARA HACER LISTAS CON UN PARAMETRO
            try
            {
                oCon.Open();
                oCmd = new SqlCommand();
                oCmd.Connection = oCon;
                oCmd.CommandText = StoreProcedure;
                oCmd.CommandType = CommandType.StoredProcedure;
                oDr = oCmd.ExecuteReader();
                while (oDr.Read())
                {
                    Datos.Add(oDr[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                oCon.Close();
            }

            return Datos;
        }
        
        /// <summary>
        /// Método utilizado para traer una columna de la base de datos
        /// </summary>
        /// <param name="StoreProcedure">Nombre del procedure</param>
        /// <returns></returns>
        ///                 
        public string ObtenerDato(string StoreProcedure, List<SqlParameter> parametros)
        {
            string Dato = "";
            try
            {
                oCon.Open();
                oCmd = new SqlCommand();
                oCmd.Connection = oCon;
                oCmd.CommandText = StoreProcedure;
                oCmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in parametros)
                {
                    oCmd.Parameters.Add(param);
                }

                oDr = oCmd.ExecuteReader();

                if (oDr.Read())
                {
                    Dato = oDr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                oCon.Close();
            }

            return Dato;
        }

    }
}
