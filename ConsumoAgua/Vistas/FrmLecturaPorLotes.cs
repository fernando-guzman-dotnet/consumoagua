using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas
{
    public partial class FrmLecturaPorLotes : Form
    {
        public FrmLecturaPorLotes(FrmPrincipal f_Main)
        {
            InitializeComponent();
            this.f_Main = f_Main;
        }

        public FrmPrincipal f_Main;

        public EnvioMasivo envioMasivo = new EnvioMasivo();

        List<Mediciones> mediciones = new List<Mediciones>();

        int IdTipoContrato = 0;
        int IdMedidor = 0;

        private void frmLecturaPorLotes_Load(object sender, EventArgs e)
        {
            if(true)
                throw new Exception("No se pueden cargar lecturistas aún.");

            /*DataTable Lecturistas = Empleado.Empleados_SelectLecturistas();
            cmbLecturista.DataSource = Lecturistas;
            cmbLecturista.DisplayMember = "Nombre_Completo";
            cmbLecturista.ValueMember = "idEmpleado";

            cmbAnomalia.SelectedIndex = 0;
            cmbOrden.SelectedIndex = 0;*/
        }

        private void btnCuentaSelect_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DlgCuentaSelect dlg = new DlgCuentaSelect();

            //    dlg.MostrarSoloServiciosMedidos = true;

            //    dlg.Bandera = 7;

            //    if (dlg.ShowDialog() == DialogResult.OK)
            //    {
            //        txtCuenta.Text = dlg.Contrato.NoContrato.ToString("D10");
            //        mediciones = dlg.mediciones;
            //        IdTipoContrato = dlg.Contrato.IdTipoContrato;
            //        IdMedidor = dlg.Contrato.Medidor.Id;
            //        if (IdTipoContrato == 1)
            //        {
            //            MessageBox.Show("Este no es un contrato de servicio medido", "Formulario Lectura por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            txtCuenta.ResetText();
            //            return;
            //        }
            //        if (dgvCapturaPorLotes.Rows.Count > 0)
            //        {
            //            foreach (DataGridViewRow item in dgvCapturaPorLotes.Rows)
            //            {
            //                if (txtCuenta.Text.Equals(item.Cells["CuentaDGV"].Value.ToString()))
            //                {
            //                    if (MessageBox.Show("Ya hay una medición ingresada con esta cuenta, ¿desea reemplazarla?", "Formulario Lectura Por Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //                    {
            //                        dgvCapturaPorLotes.Rows.RemoveAt(item.Index);
            //                    }
            //                    else
            //                    {
            //                        txtCuenta.ResetText();
            //                        return;
            //                    }
            //                }
            //            }
            //        }
            //        if (mediciones.Count != 0)
            //            txtLecturaAnterior.Text = mediciones.Last().Litros.ToString();
            //        else
            //        {
            //            txtLecturaAnterior.Text = "0.00";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("btnCuentaSelect_Click - " + ex.Message, "Formulario frmLecturaPorLotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cmbAnomalia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnomalia.SelectedIndex == 1)
            {
                txtDescrAnomalia.Enabled = true;
            }
            else
            {
                txtDescrAnomalia.ResetText();
                txtDescrAnomalia.Enabled = false;
            }
        }

        private void txtLectura_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLectura.Text))
                {
                    txtLectura.Text = "0.00";
                }
                if (Convert.ToDecimal(txtLectura.Text) < Convert.ToDecimal(txtLecturaAnterior.Text))
                {
                    MessageBox.Show("La cantidad ingresada es menor que la cantidad anterior, revise los datos", "Formulario Lectura por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLectura.Select();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("txtLectura_Validating - " + ex.Message, "Formulario Lectura Por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLecturaPorLotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            f_Main.tabManager.TabPages.RemoveAt(f_Main.tabManager.SelectedIndex);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCuenta.Text))
                {
                    MessageBox.Show("No se ha seleccionado ninguna cuenta", "Formulario Lectura Por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal consumo = 0m;
                int Anomalia = 0;
                DateTime fechaMedicion = DateTime.Now.AddMonths(-1);
                if (dgvCapturaPorLotes.RowCount == 0)
                {
                    consumo = Convert.ToDecimal(txtLectura.Text) - Convert.ToDecimal(txtLecturaAnterior.Text);

                    if (cmbAnomalia.SelectedIndex == 0)
                    {
                        Anomalia = 0;
                    }
                    else
                    {
                        Anomalia = 1;
                    }

                    dgvCapturaPorLotes.Rows.Add(txtCuenta.Text, txtLectura.Text, txtLecturaAnterior.Text, DateTime.Now, consumo, "Medición Mes " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(fechaMedicion.ToString("MMMM")), DateTime.Now.Month - 1, DateTime.Now.Year, IdMedidor, 0, Anomalia, txtDescrAnomalia.Text, Convert.ToInt32(cmbLecturista.SelectedValue));
                }
                else
                {
                    consumo = Convert.ToDecimal(txtLectura.Text) - Convert.ToDecimal(txtLecturaAnterior.Text);
                    if (cmbAnomalia.SelectedIndex == 0)
                    {
                        Anomalia = 0;
                    }
                    else
                    {
                        Anomalia = 1;
                    }
                    dgvCapturaPorLotes.Rows.Add(txtCuenta.Text, txtLectura.Text, txtLecturaAnterior.Text, DateTime.Now, consumo, "Medición Mes " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(fechaMedicion.ToString("MMMM")), DateTime.Now.Month - 1, DateTime.Now.Year, IdMedidor, 0, Anomalia, txtDescrAnomalia.Text, Convert.ToInt32(cmbLecturista.SelectedValue));
                }
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregar_Click - " + ex.Message, "Formulario Lectura Por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            try
            {
                txtCuenta.ResetText();
                txtLectura.Text = "0.00";
                txtLecturaAnterior.Text = "0.00";
                cmbAnomalia.SelectedIndex = 0;
                txtDescrAnomalia.ResetText();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Limpiar -" + ex.Message, "Formulario Lectura Por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private const char SignoDecimal = '.';
        private void txtLectura_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if (e.KeyChar == SignoDecimal)
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            f_Main.tabManager.TabPages.RemoveAt(f_Main.tabManager.SelectedIndex);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCapturaPorLotes.RowCount > 0)
                {
                    DataTable LecturasTemp = new DataTable();
                    LecturasTemp.Columns.Add("NoContrato", typeof(int));
                    LecturasTemp.Columns.Add("Litros", typeof(decimal));
                    LecturasTemp.Columns.Add("Fecha", typeof(DateTime));
                    LecturasTemp.Columns.Add("Cantidad", typeof(decimal));
                    LecturasTemp.Columns.Add("Descripcion", typeof(string));
                    LecturasTemp.Columns.Add("MesQueSePaga", typeof(int));
                    LecturasTemp.Columns.Add("AñoQueSePaga", typeof(int));
                    LecturasTemp.Columns.Add("IdMedidor", typeof(int));
                    LecturasTemp.Columns.Add("Pagada", typeof(int));
                    LecturasTemp.Columns.Add("Anomalia", typeof(int));
                    LecturasTemp.Columns.Add("DescAnomalia", typeof(string));
                    LecturasTemp.Columns.Add("IdLecturista", typeof(int));

                    for (int i = 0; i < dgvCapturaPorLotes.RowCount; i++)
                    {
                        DataRow newRow = LecturasTemp.NewRow();
                        newRow["NoContrato"] = dgvCapturaPorLotes.Rows[i].Cells["CuentaDGV"].Value.ToString();
                        newRow["Litros"] = dgvCapturaPorLotes.Rows[i].Cells["LecturaDGV"].Value.ToString();
                        newRow["Fecha"] = dgvCapturaPorLotes.Rows[i].Cells["FechaDGV"].Value.ToString();
                        newRow["Cantidad"] = dgvCapturaPorLotes.Rows[i].Cells["ConsumoDGV"].Value.ToString();
                        newRow["Descripcion"] = dgvCapturaPorLotes.Rows[i].Cells["DescripcionDGV"].Value.ToString();
                        newRow["MesQueSePaga"] = dgvCapturaPorLotes.Rows[i].Cells["MesQueSePagaDGV"].Value.ToString();
                        newRow["AñoQueSePaga"] = dgvCapturaPorLotes.Rows[i].Cells["AñoQueSePagaDGV"].Value.ToString();
                        newRow["IdMedidor"] = dgvCapturaPorLotes.Rows[i].Cells["IdMedidorDGV"].Value.ToString();
                        newRow["Pagada"] = dgvCapturaPorLotes.Rows[i].Cells["PagadaDGV"].Value.ToString();
                        newRow["Anomalia"] = dgvCapturaPorLotes.Rows[i].Cells["BitAnomaliaDGV"].Value.ToString();
                        newRow["DescAnomalia"] = dgvCapturaPorLotes.Rows[i].Cells["AnomaliaDGV"].Value.ToString();
                        newRow["IdLecturista"] = dgvCapturaPorLotes.Rows[i].Cells["IdLecturistaDGV"].Value.ToString();
                        LecturasTemp.Rows.InsertAt(newRow, i);
                    }
                    Mediciones.MedicionesTempDelete();
                    EnvioMasivo.InsertTabuladorMasivo(LecturasTemp, "Mediciones_Temp");
                    if (Mediciones.MedicionesTempToMediciones() > 0)
                    {
                        MessageBox.Show("Mediciones agregadas correctamente", "Formulario Lectura Por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        dgvCapturaPorLotes.Columns.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("No hay Lecturas por capturar", "Formulario Lectura Por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnAplicar_Click - " + ex.Message, "Formulario frmLecturaPorLotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

