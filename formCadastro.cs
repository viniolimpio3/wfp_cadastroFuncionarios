using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadastroFuncionarios {
    public partial class frmFuncionarios : Form {
        public frmFuncionarios() {
            InitializeComponent();
        }

        private void txtData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {
            MessageBox.Show("Data Inválida!");
        }

        private void btnSalvar_Click(object sender, EventArgs e) {

        }
    }
}
