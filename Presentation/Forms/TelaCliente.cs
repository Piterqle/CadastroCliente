using CadastroCliente.Aplication.Facade;
using CadastroCliente.Infrastructure.Repositories;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CadastroCliente
{
    public partial class TelaCliente : Form
    {
        private readonly ClienteFacade _clienteFacade;
        public TelaCliente()
        {

            _clienteFacade = DependencyServices.Get<ClienteFacade>();
            InitializeComponent();

        }

        private async void bt_adicionar_Click(object sender, EventArgs e)
        {
            try
            {

                string nome = txb_Nome.Text;
                string contato = txb_Contato.Text;
                DateTime dataNasc = dtp_DataNasc.Value;
                string endereco = txb_endereco.Text;
                string documento = txb_documento.Text;

                await _clienteFacade.AdicionarCliente(nome, dataNasc, contato, endereco, documento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txb_contato_textChanged(object sender, EventArgs e)
        {
            TextBox txb = (TextBox)sender;
            string documento = (string)txb.Text;
            txb.Text = Regex.Replace(documento, @"^(\d{2})(\d{5})(\d{4})$", "($1) $2-$3");
        }

        private void txb_documento_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (rb_Cpf.Checked)
            {
                txb.MaxLength = 13;
                string documento = txb.Text;
                txb.Text =  Regex.Replace(documento, @"^(\d{3})(\d{3})(\d{3})(\d{2})$", "$1.$2.$3-$4");

            } else if (rb_Cnpj.Checked)
            {
                txb.MaxLength = 18;
                string documento = txb.Text;
                txb.Text = Regex.Replace(documento, @"^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$", "$1.$2.$3/$4-$5");
            }

        }

        private void rb_Changed(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (!radioButton.Checked) txb_documento.PlaceholderText = "xxx.xxx.xxx-xx";
            else if (radioButton.Checked) txb_documento.PlaceholderText = "xx.xxx.xxx/xxxx-xx";
        }
    }
}
