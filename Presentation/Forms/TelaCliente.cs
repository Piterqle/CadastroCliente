using CadastroCliente.Aplication.Facade;
using CadastroCliente.Infrastructure.Repositories;
using System.Text.RegularExpressions;


namespace CadastroCliente
{
    public partial class TelaCliente : Form
    {
        private readonly ClienteFacade _clienteFacade;
        private List<Object> clientes; 
        public TelaCliente()
        {

            _clienteFacade = DependencyServices.Get<ClienteFacade>();
            InitializeComponent();
            BuscarCliente();
        }
        private async void BuscarCliente(object sender = null, EventArgs e = null)
        {
            var clientes = await _clienteFacade.BuscarCliente(0);

            // Loop para adicionar as Linhas de Acordo com os Dados do Cliente
            if (clientes == null) return;

            dg_Clientes.DataSource = clientes;
        }

        private async void bt_adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txb_Nome.Text;
                string contato = txb_Contato.Text;
                DateTime dataNasc = dtp_DataNasc.Value.ToLocalTime().Date;
                string endereco = txb_endereco.Text;
                string documento = txb_documento.Text;

                await _clienteFacade.AdicionarCliente(nome, dataNasc, contato, endereco, documento);

                BuscarCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txb_contato_textChanged(object sender, EventArgs e)
        {
            TextBox txb = (TextBox)sender;
            txb.MaxLength = 13;
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
                txb.Text = Regex.Replace(documento, @"^(\d{3})(\d{3})(\d{3})(\d{2})$", "$1.$2.$3-$4");

            }
            else if (rb_Cnpj.Checked)
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

        private void dg_Clientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dg_Clientes.Columns[e.ColumnIndex].Name == "col_StatusCliente" && e.Value != null)
            {
                bool cellValue = (bool)e.Value;

                if (cellValue){ 
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.Value = "Ativo";
                    return;
                }
                 
                e.CellStyle.BackColor = Color.Red;
                e.Value = "Cancelado";
            }
        }


        // Criando Fução para Cancelar e Editar o Cliente.
        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            if(dg_Clientes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecione uma Linha", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            Button button = (Button)sender;
            
            if(button.Name == "bt_cancelar")
            {
                var cliente = dg_Clientes.SelectedRows[0].Cells[0].Value.ToString();

                return;
            }
        }
    }
}
