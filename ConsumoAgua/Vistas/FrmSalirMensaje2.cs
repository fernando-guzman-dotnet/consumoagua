using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SAPA.Vistas
{
    public partial class frmSalirMensaje2 : Form
    {
        public frmSalirMensaje2()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void frmSalirMensaje_Load(object sender, EventArgs e)
        {

        }
    }
}

