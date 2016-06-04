using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Falta agregar que se consulte en función de ingreso, egreso, ambos y fechas
 */

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Cuando arranca el Form (ventana) principal
            // llenamos el DataGridView con todos los movimientos hechos
            // tanto ingresos como egresos que tenemos
            cargardgvResultados();
            // Llenamos el combobox que está en la pestaña Categorías
            // mediante un arreglo de tipo string
            string[] acciones = {"Agregar", "Modificar", "Eliminar" };
            cbAccionCategorias.DataSource = acciones;
            // Hacemos que el dtpFechaInicial inicie 7 dias antes de hoy
            dtpFechaInicial.Value = DateTime.Now.AddDays(-7).Date;
        }
        
        // Función para cargar categorias en un combobox
        public List<string> cargarCategorias()
        {
            // Creamos un objeto llamado oConexion con el que nos 
            // conectaremos a la base de datos
            miConexion oConexion = new miConexion();
            // Traer Datos nos regresa las diferentes categorías y las guardamos en una lista
            // que se llama Datos
            List<string> Datos = oConexion.TraerDatos("mostrarCategoria");
            // Después, esta lista llamada Datos la usamos para llenar el combobox
            // usaremos return para que ese dato lo tome posteriormente el combobox
            return  Datos;            
        }

        // Función para agregar una categoría
        public int agregarCategoria()
        {
            // La categoría la leemos del tbAgregarCategoria
            string _categoria = tbAgregarCategoria.Text;
            // Creamos un objeto llamado oConexion con el que nos 
            // conectaremos a la base de datos
            miConexion oConexion = new miConexion();

            // El procedure que tenemos en la base de datos nos exige
            // algunos parametros para poder insertar una categoria
            // por esa razón vamos a usar una lista de tipo SqlParameter
            // que se llamara parametros
            List<SqlParameter> parametros = new List<SqlParameter>();

            // Creamos un nuevo parametro llamado categoria
            SqlParameter Categoria = new SqlParameter()

            {
                Value = _categoria,
                ParameterName = "nombre"

            };

            // Lo agregamos a la lista llamada parametros
            parametros.Add(Categoria);

            int exito = oConexion.EjecutaNonQuery("agregarCategoria", parametros);

            return exito;

        }

        // Función para modificar una categoría
        public void modificarCategoria()
        {
            int indice = dgvResultados.CurrentRow.Index;
            // Elegimos del indice actual y la columna/celda 0
            string _viejaCategoria = dgvResultados.Rows[indice].Cells[0].Value.ToString();
            string _nuevaCategoria = tbAgregarCategoria.Text;
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cambiar " + _nuevaCategoria.ToUpper() + " por " +
                 _viejaCategoria.ToUpper(), "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            // Si la respuesta es Aceptar entonces modificamos
            // Caso contrario no hacemos nada :)
            if (respuesta == DialogResult.OK)
            {
                miConexion oConexion = new miConexion();

                List<SqlParameter> parametros = new List<SqlParameter>();

                // Parametros
                #region
                SqlParameter viejaCategoria = new SqlParameter()

                {
                    Value = _viejaCategoria,
                    ParameterName = "viejaCategoria"
                };

                parametros.Add(viejaCategoria);

                SqlParameter nuevaCategoria = new SqlParameter()

                {
                    Value = _nuevaCategoria,
                    ParameterName = "nuevaCategoria"
                };

                parametros.Add(nuevaCategoria);

                #endregion
                // EjecutaNonQuery se utiliza para actualizar, eliminar e insertar
                // en este caso vamos a insertar/agregar además le agregamos los parametros
                // que necesita el procedimiento para que se ejecute correctamente
                oConexion.EjecutaNonQuery("modificarCategoria", parametros);
                consultarCategoria();
            } // Termina if
        }

        // Función para cargar datos en el DataGridView
        public void cargardgvResultados()
        {
            miConexion oConexion = new miConexion();
            // Se entiende como movimientos los ingresos y egresos que realizamos 
            // con nuestro dinero, en esta función mediante el procedure mostrarMovimientos
            // mostramos en el dataGridView TODOS los movimientos hechos
            dgvResultados.DataSource = oConexion.ObtenerDatos("mostrarMovimientos");
        }

        // Función para agregar un Ingreso que hayamos tenido ingreso significa ganar dinero
        // el valor del parámetro TIPO será 1, lo que para nosotros represnta Ingreso
        public void agregarIngreso()
        {
            string _concepto = tbConcepto.Text;
            decimal _cantidad = Convert.ToDecimal(tbCantidad.Text); // Convertimos a decimal (dinero) 
            string _categoria = cbCategoriaRegistro.SelectedItem.ToString(); // Para leer lo que seleccionamos en el combobox
            // Cuando queremos leer de un dataGridView el valor seleccionado usamos solamente
            // esto nombreDeMiDataGridView.Value sin embargo esto nos arroja tanto la fecha como la hora
            // nosotros solamente necesitamos la fecha por eso agregamos .ToShortDateString()
            string _fecha = dtpRegistro.Value.ToShortDateString(); 

            miConexion oConexion = new miConexion();

            List<SqlParameter> parametros = new List<SqlParameter>();

            // Parametros
            #region
            SqlParameter Concepto = new SqlParameter()

            {
                Value = _concepto,
                ParameterName = "concepto"
            };

            parametros.Add(Concepto);

            SqlParameter Cantidad = new SqlParameter()

            {
                Value = _cantidad,
                ParameterName = "cantidad"               
            };

            parametros.Add(Cantidad);

            SqlParameter Categoria = new SqlParameter()

            {
                Value = _categoria,
                ParameterName = "categoria"
            };

            parametros.Add(Categoria);


            SqlParameter Tipo = new SqlParameter()

            {
                Value = 1, // 1 significa ingreso
                ParameterName = "tipo"                
            };

            parametros.Add(Tipo);


            SqlParameter Fecha = new SqlParameter()

            {
                Value = _fecha,
                ParameterName = "fecha"


            };

            parametros.Add(Fecha);
            #endregion
            // EjecutaNonQuery se utiliza para actualizar, eliminar e insertar
            // en este caso vamos a insertar/agregar además le agregamos los parametros
            // que necesita el procedimiento para que se ejecute correctamente
            oConexion.EjecutaNonQuery("agregarMovimiento", parametros);
        }

        // Función para agregar un Egreso que hayamos tenido egreso significa gastar dinero
        // el valor del parámetro TIPO será 2, lo que para nosotros represnta Egreso
        public void agregarEgreso()
        {
            string _concepto = tbConcepto.Text;
            decimal _cantidad = Convert.ToDecimal(tbCantidad.Text);
            string _categoria = cbCategoriaRegistro.SelectedItem.ToString();
            string _fecha = dtpRegistro.Value.ToShortDateString();

            miConexion oConexion = new miConexion();

            List<SqlParameter> parametros = new List<SqlParameter>();
            
            // Parametros
            #region
            SqlParameter Concepto = new SqlParameter()

            {
                Value = _concepto,
                ParameterName = "concepto"


            };

            parametros.Add(Concepto);

            SqlParameter Cantidad = new SqlParameter()

            {
                Value = _cantidad,
                ParameterName = "cantidad"


            };

            parametros.Add(Cantidad);

            SqlParameter Categoria = new SqlParameter()

            {
                Value = _categoria,
                ParameterName = "categoria"


            };

            parametros.Add(Categoria);


            SqlParameter Tipo = new SqlParameter()

            {
                Value = 2, // 2 significa egreso
                ParameterName = "tipo"


            };

            parametros.Add(Tipo);


            SqlParameter Fecha = new SqlParameter()

            {
                Value = _fecha,
                ParameterName = "fecha"


            };

            parametros.Add(Fecha);
            #endregion
            // EjecutaNonQuery se utiliza para actualizar, eliminar e insertar
            // en este caso vamos a insertar/agregar además le agregamos los parametros
            // que necesita el procedimiento para que se ejecute correctamente
            oConexion.EjecutaNonQuery("agregarMovimiento", parametros);
        }

        // Función para consultar ingresos y egresos        
        public void consultarMovimiento()
        {

            string _concepto = "";
            string _cantidad = "";
            string _tipo = "";
            string _categoria = "";
            string _fechaInicial = dtpFechaInicial.Value.ToShortDateString();
            string _fechaFinal = dtpFechaFinal.Value.ToShortDateString();

            // Validaciones para evitar errores, campos vacíos, etc
            #region
            // El procedimiento que vamos a usar para hacer consultas necesita 5 parametros que
            // son las variables declaradas arriba, por default los textbox que corresponden 
            // concepto, cantidad y el tipo de ingreso/egreso están vacios así como fecha inicial y final
            // Vamos a darle al usuario la posibilidad de buscar de todas las formas posibles 
            // En caso de que no quiera poner ni concepto, ni cantidad, ni tipo puede hacerlo
            // solamente con las fechas (estas son indispensables segun nuestro procedimiento
            // que puedes consultar en la base de datos así que no puedes dejarlas vacías)
            // Otra opción es solamente buscar con el concepto y fecha inicial-final
            // Todas las posibilidades las puedes encontrar en el procedure mostrarMovimientosSegun
            // En caso de que uno de los textbox concepto, cantidad, tipo estén vacios, nulos o 
            // estén llenos de puros espacios automáticamente mediante las siguientes validaciones
            // vamos a asignarle el valor "" el cual en nuestro procedure nos servirá para detectar
            // que el usuario NO QUIERE buscar en función de dichos datos
            // Por el contrario si el usuario ingresó en los textbox algo correcto o elige un dato
            // del combobox categoría, el procedure detectará que el usuario SÍ QUIERE buscar 
            // en función de dichos datos            

            if (rbIngreso.Checked)
                _tipo = "1";

            if (rbEgreso.Checked)
                _tipo = "2";

            if (rbAmbosConsultar.Checked)
                _tipo = "3";

            // Verificamos si está vacío o null o lleno de puros espacios el textbox 
            if (string.IsNullOrEmpty(tbConceptoConsultar.Text) || string.IsNullOrWhiteSpace(tbConceptoConsultar.Text))
            {
                // Si cumple alguno de esos casos entonces diremos que _concepto
                // tiene una cadena vacía
                _concepto = "";
                
            }
            else
            {
                // Si escribimos correctamente los datos entonces _concepto valdrá 
                // lo que hayamos escrito en el textbox
                _concepto = tbConceptoConsultar.Text;                
            }

            if (string.IsNullOrEmpty(tbCantidadConsultar.Text) || string.IsNullOrWhiteSpace(tbCantidadConsultar.Text))
            {
                // Si cumple alguno de esos casos entonces diremos que _cantidad
                // tiene una cadena vacía
                _cantidad = "";
            }

            else
            {
                // Si escribimos correctamente los datos entonces _cantidad valdrá 
                // lo que hayamos escrito en el textbox
                _cantidad = tbCantidadConsultar.Text;
            }

            if ( cbCategoriaConsultar.Items.Count <= 0)
            {
                // Si no hemos dado click en el combobox _tipo  
                // tendrá una cadena vacía
                _categoria = "";
            }
            else
            {
                // Si damos click y elegimos un dato del combobox
                // este será el valor de _tipo
                _categoria = cbCategoriaConsultar.SelectedItem.ToString();
            }
            #endregion     

            miConexion oConexion = new miConexion();

            List<SqlParameter> parametros = new List<SqlParameter>();
            
            // Parametros
            #region 
            SqlParameter Concepto = new SqlParameter()

            {
                Value = _concepto,
                ParameterName = "concepto"


            };

            parametros.Add(Concepto);

            SqlParameter Cantidad = new SqlParameter()

            {
                Value = _cantidad,
                ParameterName = "cantidad"


            };

            parametros.Add(Cantidad);

            SqlParameter Categoria = new SqlParameter()

            {
                Value = _categoria,
                ParameterName = "categoria"


            };

            parametros.Add(Categoria);

            SqlParameter Tipo = new SqlParameter()

            {
                Value = _tipo,
                ParameterName = "tipo"
            };

            parametros.Add(Tipo);

            SqlParameter FechaInicial = new SqlParameter()

            {
                Value = _fechaInicial,
                ParameterName = "fechaInicial"


            };

            parametros.Add(FechaInicial);

            SqlParameter FechaFinal = new SqlParameter()

            {
                Value = _fechaFinal,
                ParameterName = "fechaFinal"


            };

            parametros.Add(FechaFinal);
            #endregion
            
            // TraerDatosConParametros es un método para llamar a un procedure que necesite 
            // parametros y que dicho procedure sea para realizar CONSULTAS, es decir un SELECT
            dgvResultados.DataSource = oConexion.TraerDatosConParametros("mostrarMovimientosSegun", parametros);                                

        }

        // Función para consultar las categorías
        public void consultarCategoria()
        {
            miConexion oConexion = new miConexion();

            dgvResultados.DataSource = oConexion.ObtenerDatos("mostrarCategoria");
        }

        // Función para eliminar categoría 
        public void eliminarCategoria()
        {
            string _categoria = tbAgregarCategoria.Text ;
            
            miConexion oConexion = new miConexion();

            List<SqlParameter> parametros = new List<SqlParameter>();

            // Parametros
            #region 
            SqlParameter Categoria = new SqlParameter()

            {
                Value = _categoria,
                ParameterName = "nombre"
            };
            parametros.Add(Categoria);
            #endregion
            oConexion.EjecutaNonQuery("eliminarCategoria", parametros);
        }

        // Botón para registrar un ingreso/egreso
        private void btnRegistrar_Click(object sender, EventArgs e)
        {          
            // Si elegimos ingreso y Cantidad y Concepto no están vacios o lleno de espacios
            if( rbIngreso.Checked && !string.IsNullOrEmpty(tbCantidad.Text) &&
               !string.IsNullOrWhiteSpace(tbCantidad.Text) && !string.IsNullOrEmpty(tbConcepto.Text)
               && cbCategoriaRegistro.Items.Count>0 )
            {
                // Agregamos un ingreso a la base de datos
                agregarIngreso();
                // Y mostramos en el DataGridView los movimientos que traemos de la base de datos
                cargardgvResultados();
            }

            // O si elegimos egreso y Cantidad y Concepto no están vacios o lleno de espacios
            else if (rbEgreso.Checked && !string.IsNullOrEmpty(tbCantidad.Text) &&
                !string.IsNullOrWhiteSpace(tbCantidad.Text) && !string.IsNullOrEmpty(tbConcepto.Text))
            {
                // Agregamos un egreso a la base de datos
                agregarEgreso();
                // Y mostramos en el DataGridView los movimientos que traemos de la base de datos
                cargardgvResultados();
            }

            // Si alguno de los dos anteriores no se cumple mostramos un mensaje de error
            // Y por lo tanto no podremos realizar una inserción en la base de datos
            else
            {                
                MessageBox.Show("Llena todos los campos antes de registrar", "Error",MessageBoxButtons.OK , MessageBoxIcon.Error);
            }            
        }

        // EVENTO que detecta cuando una tecla es presionado en un textbox        
        // lo usaremos para evitar que el usuario introduzca datos incorrectos
        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // código para permitir en un textbox solo numeros, tecla backspace y punto decimal
            if ( !Char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {

                e.Handled = true;

                MessageBox.Show("Solo se permiten números" + e.KeyChar, "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
                        
        }

        // EVENTO que detecta cuando una tecla es presionado en un textbox        
        // lo usaremos para evitar que el usuario introduzca datos incorrectos
        private void tbConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // código para permitir en un textbox solo texto y tecla backspace  y espacio
            if (!Char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) )
            {
                e.Handled = true;
                MessageBox.Show("Solo se permite texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        // EVENTO que detecta cuando a un combobox se la ha dado Click
        // Lo usaremos para cargar las categorías desde la base de datos
        private void cbCategoriaRegistro_Click(object sender, EventArgs e)
        {
            cbCategoriaRegistro.DataSource = cargarCategorias();
        }

        // Botón para realizar una consulta de nuestros movimientos
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            // En caso de que ninguno de los radio button haya sido elegido
            if (!rbIngresoConsultar.Checked && !rbEgresoConsultar.Checked && !rbAmbosConsultar.Checked)
            {
                // No podemos realizar la consulta a la base de datos y mostramos un mensaje de error
                MessageBox.Show("Elija primero un tipo de movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {   
                // Si alguno de ellos es elegido, realizamos la consulta a la base de datos
                consultarMovimiento();
            }
        }

        // Botón para agregar una nueva categoría de ingreso/egreso
        private void btnRealizarCategoria_Click(object sender, EventArgs e)
        {

            string accion = cbAccionCategorias.SelectedItem.ToString();

            switch (accion)
            {
                case "Agregar":                    

                    if (!string.IsNullOrEmpty(tbAgregarCategoria.Text)                      
                        && !string.IsNullOrWhiteSpace(tbAgregarCategoria.Text) )
                    {
                        // Si escribimos un dato apropiado para una categoría
                        // llamamos al método agregarCategoria y este nos devuelve un 1 o 0
                        // en caso de que haya sido la inserción exitosa o fallida respectivamente
                        string lectura = "";
                        bool repetido = false;
                        string categoria = tbAgregarCategoria.Text;

                        // Verificamos si la categoría ya existe actualmente en la base de datos
                        foreach (DataGridViewRow renglon in dgvResultados.Rows)
                        {
                            lectura = Convert.ToString( renglon.Cells[0].Value );

                            // Si lo que estamos leyendo es igual a lo que escribimos en el textbox
                            if( categoria == lectura)
                            {
                                repetido = true;
                            }

                        }

                        // Si no existe
                        if (repetido == false) {

                            // La agregamos a la base de datos
                            int exito = agregarCategoria();

                            // Si fue un exito
                            if (exito == 1)
                            {
                                MessageBox.Show("Se agregó correctamente la categoría");
                                consultarCategoria();
                                tbAgregarCategoria.Text = "";
                            }
                            // Caso contrario
                            else
                            {
                                MessageBox.Show("Hubo un error y no se agregó la categoría");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Esta categoría ya existe");
                        }

                    } // Cierra if
                    // Si no hemos escrito nada aún en el tbAgregarCategoria
                    else
                    {
                        MessageBox.Show("Escriba una categoría por favor");
                    }
                    break;

                case "Modificar":
                    // Vamos a deshabilitar el textbox con el que agregamos categorías
                    // ya que vamos a poder editar el nombre después de que escojamos del DataGridView                    

                    // Aquí falta el procedure para UPDATE una categoría                    
                    modificarCategoria();           
                    break;

                case "Eliminar":

                    break;
            }                       
           
        }

        // EVENTO que detecta cuando a un combobox se la ha dado Click
        // Lo usaremos para cargar las categorías desde la base de datos
        private void cbCategoriaConsultar_Click(object sender, EventArgs e)
        {
            cbCategoriaConsultar.DataSource = cargarCategorias();
        }
        
        // EVENTO que detecta cuando una tecla es presionado en un textbox        
        // lo usaremos para evitar que el usuario introduzca datos incorrectos
        private void tbAgregarCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si tratamos de introducir algo diferente a TEXTO, tecla de Borrar y tecla de espacio
            // mostramos un error 
            if(!Char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.C ) && (e.KeyChar != (char)Keys.Space)
                && (e.KeyChar != (char)Keys.Back ) )
            {
                MessageBox.Show("Solo puede introducir texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // EVENTO de DataGridView para detectar un doble click en el header de un renglon (columna izquierda)
        // Lo usaremos para borrar columnas del DataGridView
        private void dgvResultados_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Preguntamos si está seguro que quiere eliminar al dar doble click en un header de renglon
            // Y vamos a guardar la respuesta en la variable llamada Eliminar que TIENE que ser de tipo
            // DialogResult para que podamos guardar dicha respuesta

            /*DialogResult Eliminar = MessageBox.Show("¿Está seguro que quiere eliminar?", "ALERTA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning );

            // Si dice OK entonces eliminamos, de lo contrario no hacemos nada
            if (Eliminar == DialogResult.OK) { 
            
                // Eliminamos del DataGrid el renglon seleccionado al dar doble click en él
                dgvResultados.Rows.RemoveAt(dgvResultados.CurrentRow.Index);
            } */           

            // Si estamos en la pestaña Consultar                       

            // Si estamos en la pestaña Categorías
            if( miPanelTab.SelectedTab == tabPage3 )
            {                

                if ( cbAccionCategorias.SelectedItem.ToString() == "Modificar" )
                {
                    tbAgregarCategoria.Text = dgvResultados.CurrentRow.Cells[0].Value.ToString();
                }

                else if (cbAccionCategorias.SelectedItem.ToString() == "Eliminar")
                {
                    tbAgregarCategoria.Text = dgvResultados.CurrentRow.Cells[0].Value.ToString();

                    DialogResult Eliminar = MessageBox.Show("¿Está seguro que quiere eliminar?", "ALERTA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    // Si dice OK entonces eliminamos, de lo contrario no hacemos nada
                    if (Eliminar == DialogResult.OK)
                    {                        
                        eliminarCategoria();
                        consultarCategoria();
                        // Eliminamos del DataGrid el renglon seleccionado al dar doble click en él
                        //dgvResultados.Rows.RemoveAt(dgvResultados.CurrentRow.Index);
                    }
                }
            }
        }

        // EVENTO de un combobox para detectar cuando cambiemos de un Item a otro
        // Lo usaremos para deshabilitar el textbox categoría y otras cosas
        private void cbAccionCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si elegimos Modificar
            if( cbAccionCategorias.Text.ToString() == "Modificar" )
            {
                // Mostrar todas las categorías en el DataGridView
                consultarCategoria();
                tbAgregarCategoria.Enabled = true;
            }

            else if (cbAccionCategorias.Text.ToString() == "Eliminar")
            {
                // Mostrar todas las categorías en el DataGridView
                consultarCategoria();
                tbAgregarCategoria.Enabled = false;
            }

            else
            {
                // Si el combobox elegimos Agregar
                consultarCategoria();
                tbAgregarCategoria.Enabled = true;
            }
        }

        // EVENTO de una pestañara para detectar cuando le demos click
        // Lo usaremos para consultar las categorias
        private void miPanelTab_Selected(object sender, TabControlEventArgs e)
        {
            // Si dimos click en la pestaña Consultar
            if (miPanelTab.SelectedTab == tabPage2)
            {
                // Para que el usuario SI pueda editar el DataGrid
                dgvResultados.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;             
                consultarMovimiento();
            }
            // Si dimos click en la pestaña Categoría
            if (miPanelTab.SelectedTab == tabPage3)
            {
                // Para que el usuario NO pueda editar el DataGrid
                dgvResultados.EditMode = DataGridViewEditMode.EditProgrammatically;
                consultarCategoria();
            }
        }
        private void tbConcepto_TextChanged(object sender, EventArgs e)
        {

        }

        string nombre_anterior;
        string concepto_anterior;
        decimal cantidad_anterior;
        string categoria_anterior;
        DateTime fecha_anterior;

        private void dgvResultados_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            nombre_anterior = dgvResultados.CurrentRow.Cells[0].Value.ToString();
            concepto_anterior = dgvResultados.CurrentRow.Cells[1].Value.ToString();
            cantidad_anterior = Convert.ToDecimal(dgvResultados.CurrentRow.Cells[2].Value);
            categoria_anterior = dgvResultados.CurrentRow.Cells[3].Value.ToString();
            fecha_anterior = Convert.ToDateTime(dgvResultados.CurrentRow.Cells[4].Value);

            MessageBox.Show(nombre_anterior + " "+ concepto_anterior + cantidad_anterior + categoria_anterior
                + fecha_anterior);
        }

        private void dgvResultados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

           string nombre_actual = dgvResultados.CurrentRow.Cells[0].Value.ToString();
           string concepto_actual = dgvResultados.CurrentRow.Cells[1].Value.ToString();
           decimal cantidad_actual = Convert.ToDecimal(dgvResultados.CurrentRow.Cells[2].Value);
           string categoria_actual = dgvResultados.CurrentRow.Cells[3].Value.ToString();
           DateTime fecha_actual = Convert.ToDateTime(dgvResultados.CurrentRow.Cells[4].Value);

            MessageBox.Show(nombre_actual + " " + concepto_actual);

            miConexion oConexion = new miConexion();

            List<SqlParameter> parametros = new List<SqlParameter>();

            // Parametros variable_anterior
            #region
            SqlParameter nombre_Anterior = new SqlParameter()

            {
                Value = nombre_anterior,
                ParameterName = "nombre_anterior"
            };

            parametros.Add(nombre_Anterior);

            SqlParameter concepto_Anterior = new SqlParameter()

            {
                Value = concepto_anterior,
                ParameterName = "concepto_Anterior"
            };

            parametros.Add(concepto_Anterior);

            SqlParameter cantidad_Anterior = new SqlParameter()

            {
                Value = cantidad_anterior,
                ParameterName = "cantidad_Anterior"
            };

            parametros.Add(cantidad_Anterior);

            SqlParameter categoria_Anterior = new SqlParameter()

            {
                Value = categoria_anterior,
                ParameterName = "categoria_Anterior"
            };

            parametros.Add(categoria_Anterior);

            SqlParameter fecha_Anterior = new SqlParameter()

            {
                Value = fecha_anterior,
                ParameterName = "fecha_Anterior"
            };

            parametros.Add(fecha_Anterior);

            #endregion

            // Parametros variable_actual            
            #region
            SqlParameter nombre_Actual = new SqlParameter()

            {
                Value = nombre_actual,
                ParameterName = "nombre_actual"
            };

            parametros.Add(nombre_Actual);

            SqlParameter concepto_Actual = new SqlParameter()

            {
                Value = concepto_actual,
                ParameterName = "concepto_Actual"
            };

            parametros.Add(concepto_Actual);

            SqlParameter cantidad_Actual = new SqlParameter()

            {
                Value = cantidad_actual,
                ParameterName = "cantidad_Actual"
            };

            parametros.Add(cantidad_Actual);

            SqlParameter categoria_Actual = new SqlParameter()

            {
                Value = categoria_actual,
                ParameterName = "categoria_Actual"
            };

            parametros.Add(categoria_Actual);

            SqlParameter fecha_Actual = new SqlParameter()

            {
                Value = fecha_actual,
                ParameterName = "fecha_Actual"
            };

            parametros.Add(fecha_Actual);
            #endregion
            // EjecutaNonQuery se utiliza para actualizar, eliminar e insertar
            // en este caso vamos a insertar/agregar además le agregamos los parametros
            // que necesita el procedimiento para que se ejecute correctamente
            oConexion.EjecutaNonQuery("modificarCategoria", parametros);

        }
    }
}
