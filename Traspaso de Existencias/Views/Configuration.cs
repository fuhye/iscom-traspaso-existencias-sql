using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Traspaso_de_Existencias.Properties;
using Traspaso_de_Existencias.Services;
using Traspaso_de_Existencias.Error;

namespace Traspaso_de_Existencias.Views
{
    public partial class Configuration : DevExpress.XtraEditors.XtraForm
    {
        SQLService SQLService;
        public Configuration()
        {
            InitializeComponent();
            LoadConfiguration();

            SQLService = SQLService.Instance;
        }

        private void LoadConfiguration()
        {
            tbxServerInstance.Text = Settings.Default.ServerInstance;
            tbxUsername.Text = Settings.Default.Username;
            tbxPassword.Text = Settings.Default.Password;
            tbxUsuarioComercial.Text = Settings.Default.UsuarioComercial;
            tbxPasswordComercial.Text = Settings.Default.PasswordComercial;
            tbxUsuarioContabilidad.Text = Settings.Default.UsuarioContabilidad;
            tbxPasswordContabilidad.Text = Settings.Default.PasswordContabilidad;
            cbxContabilidad.Checked = Settings.Default.HasContabilidad;
            tbxSDKDirectory.Text = Settings.Default.SDKDirectory;
        }

        private void SetConfiguration()
        {
            Settings.Default.ServerInstance = tbxServerInstance.Text;
            Settings.Default.Username = tbxUsername.Text;
            Settings.Default.Password = tbxPassword.Text;
            Settings.Default.UsuarioComercial = tbxUsuarioComercial.Text;
            Settings.Default.PasswordComercial = tbxPasswordComercial.Text;
            Settings.Default.UsuarioContabilidad = tbxUsuarioContabilidad.Text;
            Settings.Default.PasswordContabilidad = tbxPasswordContabilidad.Text;
            Settings.Default.HasContabilidad = cbxContabilidad.Checked;
            Settings.Default.SDKDirectory = tbxSDKDirectory.Text;
            Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetConfiguration();
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SetConfiguration();
                SQLService.TestConnection();
                MessageBox.Show("Conexion completada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(TraspasoExistenciasException tee)
            {
                MessageBox.Show(tee.Message, "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxContabilidad_CheckedChanged(object sender, EventArgs e)
        {
            tbxUsuarioContabilidad.Enabled = cbxContabilidad.Checked;
            tbxPasswordContabilidad.Enabled = cbxContabilidad.Checked;
        }
    }
}