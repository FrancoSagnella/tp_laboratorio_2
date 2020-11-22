using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;

namespace Formularios
{
    public partial class FrmComercio : Form
    {
        /// <summary>
        /// Evento para poder agregar items al carrito de compra
        /// </summary>
        public AgregarAlCarritoDelegado agregarAlCarritoEvento;
        public FrmCarrito carrito;

        public ManejadorSql manejadorBD;
        public DataTable dt;

        Thread hilo;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FrmComercio()
        {
            InitializeComponent();
            this.manejadorBD = new ManejadorSql();
            ConfigurarDataTable();
            ConfigurarGrilla();

            //instancio el hilo y lo asocio con el metodo MostrarPublicidad para que lo invoque
            this.hilo = new Thread(this.MostrarPublicidad);
        }
        /// <summary>
        /// En el load del formulario, se comienza a ejecutar el hilo secundario,
        /// Los datos cargados en el DataTable los muestra la grilla,
        /// y se ejecuta el Metodo Fill del SqlDataAdapter, para cargar el stock 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmComercio_Load(object sender, EventArgs e)
        {
            this.hilo.Start();
            this.grillaInventario.DataSource = dt;
            this.manejadorBD.da.Fill(dt);
        }
        /// <summary>
        /// Configura el control DataGridViewer
        /// </summary>
        public void ConfigurarGrilla()
        {
            this.grillaInventario.MultiSelect = false;
            this.grillaInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.grillaInventario.AllowUserToAddRows = false;
            this.grillaInventario.AllowUserToDeleteRows = false;
            this.grillaInventario.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        /// <summary>
        /// Configura el atributo DataTable, para poder manejar los datos de 
        /// las filas
        /// </summary>
        public void ConfigurarDataTable()
        {
            this.dt = new DataTable("Inventario");

            this.dt.Columns.Add("ID", typeof(int));
            this.dt.Columns.Add("Marca", typeof(string));
            this.dt.Columns.Add("Modelo", typeof(string));
            this.dt.Columns.Add("Precio", typeof(float));
            this.dt.Columns.Add("Tipo", typeof(string));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }

        /// <summary>
        /// Permite modificar los datos del item seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = this.grillaInventario.CurrentRow.Index;

                FrmABM frm = new FrmABM(this.dt.Rows[indice]["Marca"].ToString(),
                                        this.dt.Rows[indice]["tipo"].ToString(),
                                        this.dt.Rows[indice]["Modelo"].ToString(),
                                        this.dt.Rows[indice]["Precio"].ToString());

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.dt.Rows[indice]["Marca"] = frm.Elec.Marca;
                    this.dt.Rows[indice]["Modelo"] = frm.Elec.Modelo;
                    this.dt.Rows[indice]["Precio"] = frm.Elec.Precio;
                    this.dt.Rows[indice]["Tipo"] = frm.Elec.GetType().Name;
                }
            }
            catch(ModeloException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Permite agregar un item a la tabla del stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmABM frm = new FrmABM();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow fila = this.dt.NewRow();

                    fila["Marca"] = frm.Elec.Marca;
                    fila["Modelo"] = frm.Elec.Modelo;
                    fila["Precio"] = frm.Elec.Precio;
                    fila["Tipo"] = frm.Elec.GetType().Name;

                    this.dt.Rows.Add(fila);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Se intentaron agregar valores nulos");
            }
            catch (ModeloException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Permite eliminar un item del stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = this.grillaInventario.CurrentRow.Index;
            this.dt.Rows[indice].Delete();
        }
        /// <summary>
        /// Crea y abre un form con el carrito de compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrearCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (carrito == null)
                {
                    this.carrito = new FrmCarrito();
                    this.carrito.Show(this);
                }
                else
                {
                    throw new CarritoAbiertoException();
                }
            }
            catch(CarritoAbiertoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Permite añadir el item seleccionado del stock, al carrito de compra,
        /// Asocia el manejador de eventos "AgregarProducto" al evento agregarAlCarritoEvento
        /// y lo invoca pasandole los datos de la fila seleccionada para que el formulario del
        /// carrito los pueda agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.carrito == null)
                {
                    throw new CarritoAbiertoException("No hay un carrito abierto");
                }

                //Asocio el manejador
                this.agregarAlCarritoEvento += new AgregarAlCarritoDelegado(carrito.AgregarProdutco);

                //Llamo al manejador de eventos que agrega las filas al carrito
                //Y le paso la fila seleccionada
                DataRow fila = this.dt.Rows[this.grillaInventario.CurrentRow.Index];
                this.agregarAlCarritoEvento(fila);

                //Desasocio el manejador, asi la proxima vez no se invoca varias veces
                this.agregarAlCarritoEvento -= new AgregarAlCarritoDelegado(carrito.AgregarProdutco);
            }
            catch(ProductoRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
                //En caso de que se lance una excepcion, tambien desasocio el manejador
                this.agregarAlCarritoEvento -= new AgregarAlCarritoDelegado(carrito.AgregarProdutco);
            }
            catch(CarritoAbiertoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Abre una instancia de FrmTicket, que imprime el contenido
        /// de un archivo de texto mostrando el historial de ventas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTicket ticket = new FrmTicket(Ticketeadora<Electrodomestico>.Leer("Ticket_Ventas.log"));
                ticket.ShowDialog();
            }
            catch(ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// En el cierre del formulario, los datos de la tabla se sincronizan con 
        /// la base de datos y se aborta el hilo secundario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmComercio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.hilo.Abort();
            this.manejadorBD.da.Update(dt);
        }
        /// <summary>
        /// Metodo que se ejecuta en el hilo secundario para mostrar
        /// un array con imagenes que va cambiando en el tiempo
        /// </summary>
        /// <param name="param"></param>
        private void MostrarPublicidad(object param)
        {
            if (this.imgPublicidad.InvokeRequired)
            {
                int imagenPos = 0;

                DelegadoThreadConParam delegado = new DelegadoThreadConParam(this.MostrarPublicidad);

                object[] imagen = new object[4];

                imagen[0] = "Philips_Logo.png";
                imagen[1] = "Philips_tv.jpg";
                imagen[2] = "Oster_Logo.jpg";
                imagen[3] = "Cafetera_Oster.jpg";

                do
                {
                    object[] parametro = new object[] { imagen[imagenPos] };

                    switch(imagenPos)
                    {
                        case 0:
                            imagenPos = 1;
                            break;
                        case 1:
                            imagenPos = 2;
                            break;
                        case 2:
                            imagenPos = 3;
                            break;
                        case 3:
                            imagenPos = 0;
                            break;
                    }

                    this.Invoke(delegado, (object)parametro);

                    Thread.Sleep(3000);

                } while(true);
            }
            else
            {
                this.imgPublicidad.ImageLocation = ((object[])param)[0].ToString();
            }
        }
    }
}
