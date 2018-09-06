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
using Traspaso_de_Existencias.Model;
using Traspaso_de_Existencias.Services;
using System.IO;

namespace Traspaso_de_Existencias.Views
{
    public partial class ResultForm : DevExpress.XtraEditors.XtraForm
    {
        TraspasoParameters parameters;
        TraspasoResult result;
        CONTPAQService CONTPAQService;

        internal ResultForm(TraspasoParameters parameters, TraspasoResult result)
        {
            InitializeComponent();
            this.parameters = parameters;
            this.result = result;
            CONTPAQService = CONTPAQService.Instance;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            lblImportTime.Text = result.TimeToImport.ToString();
            lblReadTime.Text = result.TimeToRead.ToString();
            foreach(string err in result.Errors)
            {
                lbxErrors.Items.Add(err);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            result.TimeToVerify = CONTPAQService.Verify(parameters, result.Verification);
            grcVerificationResult.DataSource = result.Verification;
            lblVerifyTime.Text = result.TimeToVerify.ToString();
        }

        private void btnExportResult_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "xlsx|Excel Files";
                dialog.DefaultExt = "xlsx";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    grcVerificationResult.ExportToXlsx(dialog.FileName);
                }
            }
        }

        private void btnExportErrors_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "txt|Text files";
                dialog.DefaultExt = "txt";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using(StreamWriter sw = new StreamWriter(dialog.FileName))
                    {
                        foreach(string error in result.Errors)
                        {
                            sw.WriteLine(error);
                        }
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
        }
    }
}