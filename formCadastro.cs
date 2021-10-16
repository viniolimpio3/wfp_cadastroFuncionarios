using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
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

            int codigo;

            bool success = Int32.TryParse(txtCodigo.Text, out codigo);

            if (!success || codigo < 0) {
                MessageBox.Show("Digite um código válido!");
                txtCodigo.Focus();
                return;
            }


            if (txtNome.Text.Trim().Length == 0) {
                MessageBox.Show("Preecha o nome.");
                txtNome.Focus();
                return;
            }

            DateTime data;
            success = DateTime.TryParse(txtData.Text, out data);


            //Salvando em arquivo .txt
            string content = codigo + Environment.NewLine +
                txtNome.Text + Environment.NewLine +
                txtData.Text;

            //Salva o nome do arquivo com o código do usuário
            string filename = $"{codigo}.txt";

            File.WriteAllText(filename, content);

            MessageBox.Show("Dados Salvos com Sucesso!");
        }

        private void btnCarregar_Click(object sender, EventArgs e) {
            int codigo;

            bool success = Int32.TryParse(txtCodigo.Text, out codigo);

            if (!success || codigo < 0) {
                MessageBox.Show("Digite um código válido para carregar um usuário!");
                txtCodigo.Focus();
                return;
            }

            string path = $"{codigo}.txt";

            if (!File.Exists(path)){
                MessageBox.Show("O usuário ainda não foi cadastrado no sistema. Salve-o!");
                txtNome.Focus();
                return;
            }

            string[] linhas = File.ReadAllLines(path);
            txtNome.Text = linhas[1];
            txtData.Text = linhas[2];
        }
    }
}
