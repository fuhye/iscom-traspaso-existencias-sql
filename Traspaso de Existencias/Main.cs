using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Traspaso_de_Existencias.Error;
using Traspaso_de_Existencias.Model;
using Traspaso_de_Existencias.Services;
using Traspaso_de_Existencias.Views;

namespace Traspaso_de_Existencias
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        CONTPAQService CONTPAQService;
        TraspasoParameters Params;
        public Main()
        {
            InitializeComponent();
            CONTPAQService = CONTPAQService.Instance;
            Params = new TraspasoParameters();
            LoadCompanies();
        }

        private void LoadCompanies()
        {
            try
            {
                Company[] companies = CONTPAQService.GetCompanies().ToArray();
                cbxSourceCompany.Properties.DataSource = companies;
                cbxDestinationCompany.Properties.DataSource = companies;
            }
            catch(TraspasoExistenciasException tee)
            {
                DialogResult resp = MessageBox.Show("Ocurrio un error al cargar las empresas, desea ver la configuración?", "Error al iniciar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(resp == DialogResult.Yes)
                {
                    if(ShowConfigurationForm() == DialogResult.OK)
                    {
                        LoadCompanies();
                    }
                    else
                    {
                        MessageBox.Show("No fue posible cargar las empresas al sistema, por favor verifique su configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private DialogResult ShowConfigurationForm()
        {
            using (Configuration frm = new Configuration())
            {
                return frm.ShowDialog();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if(ShowConfigurationForm() == DialogResult.OK)
            {
                LoadCompanies();
            }
        }

        private void cbxSourceCompany_EditValueChanged(object sender, EventArgs e)
        {
            Params.Source = cbxSourceCompany.EditValue as Company;
            cbxWarehouses.Properties.DataSource = CONTPAQService.GetWarehouses(Params.Source);
            List<Product> products = CONTPAQService.GetProducts(Params.Source);
            cbxProducts.Properties.Items.Clear();
            foreach (Product p in products)
            {
                cbxProducts.Properties.Items.Add(p, CheckState.Checked, true);
            }
        }

        private List<Product> GetSelectedProducts()
        {
            return cbxProducts.Properties.Items.Where(x => x.CheckState == CheckState.Checked).Select(x => x.Value as Product).ToList();
        }

        private List<Warehouse> GetSelectedWarehouses()
        {
            return cbxWarehouses.Properties.Items.Where(x => x.CheckState == CheckState.Checked).Select(x => x.Value as Warehouse).ToList();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Params.Products = GetSelectedProducts();
            Params.Warehouses = GetSelectedWarehouses();

            if(ReferenceEquals(Params.Source, null))
            {
                MessageBox.Show("Debe especificar la empresa de donde se tomaran las existencias", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ReferenceEquals(Params.DestinationDb, null))
            {
                MessageBox.Show("Debe especificar la empresa a donde se moveran las existencias", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ReferenceEquals(Params.DestinationDb, Params.Source))
            {
                MessageBox.Show("La empresa origen y la empresa destino no pueden ser la misma", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(Params.Products.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un producto", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Params.Warehouses.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un almacen", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    TraspasoResult result = CONTPAQService.TraspasoExistencias(Params);
                    using(ResultForm frm = new ResultForm(Params, result))
                    {
                        frm.ShowDialog();
                    }
                }
                catch(TraspasoExistenciasException tee)
                {
                    MessageBox.Show("Ocurrio un error al generar el traspaso, detalles: " + tee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbxDestinationCompany_EditValueChanged(object sender, EventArgs e)
        {
            Params.DestinationDb = cbxDestinationCompany.EditValue as Company;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            Params.Products = GetSelectedProducts();
            Params.Warehouses = GetSelectedWarehouses();

            if (ReferenceEquals(Params.Source, null))
            {
                MessageBox.Show("Debe especificar la empresa de donde se tomaran las existencias", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ReferenceEquals(Params.DestinationDb, null))
            {
                MessageBox.Show("Debe especificar la empresa a donde se moveran las existencias", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ReferenceEquals(Params.DestinationDb, Params.Source))
            {
                MessageBox.Show("La empresa origen y la empresa destino no pueden ser la misma", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Params.Products.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un producto", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Params.Warehouses.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un almacen", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using(ResultForm frm = new ResultForm(Params, new TraspasoResult()))
                {
                    frm.ShowDialog();
                }
            }
        }
    }
}
