using CadastroCliente.Aplication.DTO;
using CadastroCliente.Aplication.Facade;
using CadastroCliente.Aplication.Models;
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

        private void TelaCliente_Load(object sender, EventArgs e)
        {
            BuscarCliente();
            dtp_DataNasc.MaxDate = DateTime.Now;
        }

        private async void BuscarCliente()
        {
            var clientes = await _clienteFacade.BuscarCliente();

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

                var cliente = new ClienteCreateDTO()
                {
                    NomeCliente = nome,
                    ClienteContato = contato,
                    DataCliente = dataNasc,
                    EnderecoCliente = endereco,
                    DocumentoCliente = documento,
                    StatusCliente = true
                };

                await _clienteFacade.AdicionarCliente(cliente);

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
            txb.MaxLength = 15;

            string documento = txb.Text;
            txb.Text = Regex.Replace(documento, @"^(\d{2})(\d{5})(\d{4})$", "($1) $2-$3");

        }

        private void txb_documento_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (rb_Cpf.Checked)
            {
                txb.MaxLength = 14;
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

                if (cellValue)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.Value = "Ativo";
                    return;
                }

                e.CellStyle.BackColor = Color.Red;
                e.Value = "Cancelado";
            }
        }


        // Criando Fução para Cancelar e Editar o Cliente.
        private async void UpdateClick(object sender, EventArgs e)
        {

            var selected = dg_Clientes.CurrentRow != null ? dg_Clientes.CurrentRow.DataBoundItem : throw new Exception("Clique em Uma linha");
            ClienteReadModel? clienteSelect = (ClienteReadModel?)selected;

            if (dg_Clientes.SelectedRows.Count <= 0 || clienteSelect == null)
            {
                MessageBox.Show("Selecione uma linha para edição", "Edição", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ;

            Button button = (Button)sender;

            if (button.Name == "bt_alterarStatus")
            {
                ClienteUpdateDTO clienteUpdate = new() { StatusCliente = !clienteSelect.StatusCliente };

                await _clienteFacade.AlterarDadosCliente(clienteSelect.IdCliente, clienteUpdate);

                BuscarCliente();
                return;
            }
            else if (button.Name == "bt_editar") // Verificação para Preencher os Campos de Texto para Edição
            {
                button.Name = "bt_confirm";
                button.BackColor = Color.LightGreen;
                button.Text = "Confirmar Alteração";

                bt_adicionar.Hide();

                bt_alterarStatus.Name = "bt_cancelar";
                bt_alterarStatus.Text = "Cancelar";
                bt_alterarStatus.BackColor = Color.Red;


                txb_Nome.DataBindings.Add("Text", clienteSelect, "NomeCliente");
                txb_Contato.DataBindings.Add("Text", clienteSelect, "ContatoCliente");
                dtp_DataNasc.DataBindings.Add("Value", clienteSelect, "DataCliente");
                txb_endereco.DataBindings.Add("Text", clienteSelect, "EnderecoCliente");

                if (clienteSelect.DocumentoCliente.Length == 18)
                    rb_Cnpj.Checked = true;

                txb_documento.DataBindings.Add("Text", clienteSelect, "DocumentoCliente");

                return;
            }

            if (button.Name == "bt_confirm")
            {
                ClienteUpdateDTO clienteUpdateDTO = new()
                {
                    NomeCliente = txb_Nome.Text,
                    DataCliente = dtp_DataNasc.Value.ToLocalTime().Date,
                    ContatoCliente = txb_Contato.Text,
                    EnderecoCliente = txb_endereco.Text,
                    DocumentoCliente = txb_documento.Text
                };

                await _clienteFacade.AlterarDadosCliente(clienteSelect.IdCliente, clienteUpdateDTO);
            }

            txb_Nome.DataBindings.Clear();
            txb_Nome.Clear();

            txb_Contato.DataBindings.Clear();
            txb_Contato.Clear();

            dtp_DataNasc.DataBindings.Clear();
            dtp_DataNasc.Value = DateTime.Today;

            txb_endereco.DataBindings.Clear();
            txb_endereco.Clear();

            txb_documento.DataBindings.Clear();
            txb_documento.Clear();

            bt_editar.Name = "bt_editar";
            bt_editar.BackColor = Color.Yellow;
            bt_editar.Text = "Editar";

            bt_adicionar.Show();

            bt_alterarStatus.Name = "bt_alterarStatus";
            bt_alterarStatus.Text = "Inativar/Ativar Cliente";
            bt_alterarStatus.BackColor = Color.CornflowerBlue;

            BuscarCliente();
            return;

        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)
                && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

    }
}
