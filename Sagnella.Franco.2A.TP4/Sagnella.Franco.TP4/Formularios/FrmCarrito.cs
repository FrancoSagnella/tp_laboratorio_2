using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Archivos;
using MetodosExtension;

namespace Formularios
{
    public partial class FrmCarrito : Form
    {
        private DataTable dt;
        private ListaElectrodomesticos listaElectrodomesticos = new ListaElectrodomesticos();

        /// <summary>
        /// Constructor por defecto, configura el datatable y el datagridview 
        /// </summary>
        public FrmCarrito()
        {
            InitializeComponent();

            this.dt = new DataTable("Carrito");

            this.dt.Columns.Add("ID", typeof(int));
            this.dt.Columns.Add("Marca", typeof(string));
            this.dt.Columns.Add("Modelo", typeof(string));
            this.dt.Columns.Add("Precio", typeof(float));
            this.dt.Columns.Add("Tipo", typeof(string));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;

            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.dataGridView1.DataSource = this.dt;
        }
        /// <summary>
        /// Al realizar la compra, se muestra en pantalla un FrmTicket mostrando
        /// el resumen de la compra (imprime los datos de todos los electrodomesticos que forman parte de la lista
        /// de electrodomesticos), ademas imprime estos datos en el archivo que guarda el historial de
        /// ventas, despues se cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string resumenVenta = "";

                Ticketeadora<Electrodomestico> t = new Ticketeadora<Electrodomestico>();

                foreach (Electrodomestico item in this.listaElectrodomesticos.Lista)
                {
                    Ticketeadora<Electrodomestico>.imprimirHistorialVentas(item, "Ticket_Ventas.log");
                    resumenVenta += t.ObtenerResumenVenta(item);
                }
                FrmTicket ticket = new FrmTicket(resumenVenta);
                ticket.ShowDialog();
            }
            catch(ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        /// <summary>
        /// Cierra el formulario sin realizar ningun cambio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Elimina la fila seleccionada, y remueve el electrodomestico que corresponde a 
        /// esa fila de la lista de electrodomesticos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            int indice = this.dataGridView1.CurrentRow.Index;
            DataRow fila = this.dt.Rows[indice];

            listaElectrodomesticos -= fila;

            fila.Delete();
        }
        /// <summary>
        /// Manejador de eventos para el evento agregarAlCarritoEvento del formComercio,
        /// crea una nueva fila con los datos de la fila que recibe como parametro
        /// y lo guarda en la lista de electrodomesticos
        /// </summary>
        /// <param name="fila"></param>
        public void AgregarProdutco(DataRow fila)
        {
            try
            {
                DataRow filaNueva = this.dt.NewRow();

                filaNueva.ItemArray = fila.ItemArray;

                this.dt.Rows.Add(filaNueva);

                listaElectrodomesticos += filaNueva;
            }
            catch(Exception e)
            {
                throw new ProductoRepetidoException();
            }
        }
        /// <summary>
        /// Al cerrar el formulario, la instancia carrito del formulario Owner
        /// se vuelve null, para permitir que se puede abrir un nuevo carrito despues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCarrito_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmComercio padre = (FrmComercio)this.Owner;
            padre.carrito = null;
            this.Dispose();
        }
    }
}
