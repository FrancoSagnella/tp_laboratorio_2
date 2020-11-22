using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace Formularios
{
    public partial class FrmABM : Form
    {
        private Electrodomestico elec;
        /// <summary>
        /// Propiedad para volver publico el atributo elec
        /// </summary>
        public Electrodomestico Elec
        {
            get
            {
                return this.elec;
            }
        }

        public FrmABM()
        {
            InitializeComponent(); 
        }
        /// <summary>
        /// Constructor con parametros para recibir datos, y 
        /// crear el Formulario con los ComboBox ya cargados
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        public FrmABM(string marca, string tipo, string modelo, string precio)
            :this()
        {
            this.cmbMarca.Text = marca;
            this.cmbTipo.Text = tipo;
            this.cmbModelo.Text = modelo;
            this.txtPrecio.Text = precio;
        }
        /// <summary>
        /// Confirma la creacion / modificacion de un electrodomestico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    switch (this.cmbTipo.Text)
                    {
                        case "Tv":

                            this.elec = new Tv(Electrodomestico.StringAMarca(cmbMarca.Text),
                                                Electrodomestico.StringAModelo(cmbModelo.Text),
                                                float.Parse(txtPrecio.Text));
                            break;
                        case "Cafetera":
                            this.elec = new Cafetera(Electrodomestico.StringAMarca(cmbMarca.Text),
                                                Electrodomestico.StringAModelo(cmbModelo.Text),
                                                float.Parse(txtPrecio.Text));
                            break;
                        default:
                            throw new ProductoInvalidoException();
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch(FormatException ex)
                {
                    throw new PrecioInvalidoException();
                }
            }
            catch(ProductoInvalidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Cancela la creacion/modificacion de un electrodomestico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
