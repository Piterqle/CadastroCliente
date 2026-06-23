using CadastroCliente.Aplication.Facade;
using CadastroCliente.Infrastructure.Repositories;
using System.Text.RegularExpressions;

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

        private void txb_documento_TextChanged(object sender, EventArgs e)
        {
            if (!rb_Cnpj.Checked)
            {
                string documento = txb_documento.Text;
                documento =  Regex.Replace(documento, @"^(\d{3})(\d{3})(\d{3})(\d)$", "$1.$2.$3-$4");
            }
        }
    }
}
