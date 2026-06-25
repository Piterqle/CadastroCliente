namespace CadastroCliente
{
    partial class TelaCliente
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lb_Nome = new Label();
            txb_Nome = new TextBox();
            lb_Contato = new Label();
            txb_Contato = new TextBox();
            lb_DataNasc = new Label();
            dtp_DataNasc = new DateTimePicker();
            label1 = new Label();
            txb_endereco = new TextBox();
            lb_Documento = new Label();
            txb_documento = new TextBox();
            rb_Cpf = new RadioButton();
            rb_Cnpj = new RadioButton();
            bt_adicionar = new Button();
            SuspendLayout();
            // 
            // lb_Nome
            // 
            lb_Nome.Anchor = AnchorStyles.Top;
            lb_Nome.AutoSize = true;
            lb_Nome.Font = new Font("Segoe UI", 12F);
            lb_Nome.Location = new Point(30, 26);
            lb_Nome.Name = "lb_Nome";
            lb_Nome.Size = new Size(127, 21);
            lb_Nome.TabIndex = 3;
            lb_Nome.Text = "Nome do Cliente";
            // 
            // txb_Nome
            // 
            txb_Nome.Anchor = AnchorStyles.Top;
            txb_Nome.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_Nome.Location = new Point(30, 56);
            txb_Nome.Name = "txb_Nome";
            txb_Nome.PlaceholderText = "xxxxxx";
            txb_Nome.Size = new Size(196, 27);
            txb_Nome.TabIndex = 2;
            // 
            // lb_Contato
            // 
            lb_Contato.Anchor = AnchorStyles.Top;
            lb_Contato.AutoSize = true;
            lb_Contato.Font = new Font("Segoe UI", 12F);
            lb_Contato.Location = new Point(232, 26);
            lb_Contato.Name = "lb_Contato";
            lb_Contato.Size = new Size(147, 21);
            lb_Contato.TabIndex = 5;
            lb_Contato.Text = "Telefone de Contato";
            // 
            // txb_Contato
            // 
            txb_Contato.Anchor = AnchorStyles.Top;
            txb_Contato.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_Contato.Location = new Point(232, 56);
            txb_Contato.Name = "txb_Contato";
            txb_Contato.PlaceholderText = "(xx) xxxxx-xxxx";
            txb_Contato.Size = new Size(196, 27);
            txb_Contato.TabIndex = 4;
            txb_Contato.TextChanged += txb_contato_textChanged;
            // 
            // lb_DataNasc
            // 
            lb_DataNasc.Anchor = AnchorStyles.Top;
            lb_DataNasc.AutoSize = true;
            lb_DataNasc.Font = new Font("Segoe UI", 12F);
            lb_DataNasc.Location = new Point(435, 26);
            lb_DataNasc.Name = "lb_DataNasc";
            lb_DataNasc.Size = new Size(150, 21);
            lb_DataNasc.TabIndex = 7;
            lb_DataNasc.Text = "Data de Nascimento";
            // 
            // dtp_DataNasc
            // 
            dtp_DataNasc.Anchor = AnchorStyles.Top;
            dtp_DataNasc.CalendarFont = new Font("Segoe UI", 20F);
            dtp_DataNasc.Format = DateTimePickerFormat.Short;
            dtp_DataNasc.Location = new Point(435, 54);
            dtp_DataNasc.Name = "dtp_DataNasc";
            dtp_DataNasc.Size = new Size(196, 23);
            dtp_DataNasc.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(30, 104);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 10;
            label1.Text = "Endereço";
            // 
            // txb_endereco
            // 
            txb_endereco.Anchor = AnchorStyles.Top;
            txb_endereco.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_endereco.Location = new Point(30, 134);
            txb_endereco.Name = "txb_endereco";
            txb_endereco.Size = new Size(196, 27);
            txb_endereco.TabIndex = 9;
            // 
            // lb_Documento
            // 
            lb_Documento.Anchor = AnchorStyles.Top;
            lb_Documento.AutoSize = true;
            lb_Documento.Font = new Font("Segoe UI", 12F);
            lb_Documento.Location = new Point(232, 104);
            lb_Documento.Name = "lb_Documento";
            lb_Documento.Size = new Size(82, 21);
            lb_Documento.TabIndex = 12;
            lb_Documento.Text = "Documeto";
            // 
            // txb_documento
            // 
            txb_documento.Anchor = AnchorStyles.Top;
            txb_documento.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_documento.Location = new Point(232, 134);
            txb_documento.Name = "txb_documento";
            txb_documento.PlaceholderText = "xxx.xxx.xxx-xx";
            txb_documento.Size = new Size(196, 27);
            txb_documento.TabIndex = 11;
            txb_documento.TextChanged += txb_documento_TextChanged;
            // 
            // rb_Cpf
            // 
            rb_Cpf.Anchor = AnchorStyles.Top;
            rb_Cpf.AutoSize = true;
            rb_Cpf.Checked = true;
            rb_Cpf.Location = new Point(320, 109);
            rb_Cpf.Name = "rb_Cpf";
            rb_Cpf.Size = new Size(46, 19);
            rb_Cpf.TabIndex = 15;
            rb_Cpf.TabStop = true;
            rb_Cpf.Text = "CPF";
            rb_Cpf.UseVisualStyleBackColor = true;
            // 
            // rb_Cnpj
            // 
            rb_Cnpj.Anchor = AnchorStyles.Top;
            rb_Cnpj.AutoSize = true;
            rb_Cnpj.Location = new Point(376, 109);
            rb_Cnpj.Name = "rb_Cnpj";
            rb_Cnpj.Size = new Size(52, 19);
            rb_Cnpj.TabIndex = 16;
            rb_Cnpj.Text = "CNPJ";
            rb_Cnpj.UseVisualStyleBackColor = true;
            rb_Cnpj.CheckedChanged += rb_Changed;
            // 
            // bt_adicionar
            // 
            bt_adicionar.Anchor = AnchorStyles.Top;
            bt_adicionar.BackColor = Color.Lime;
            bt_adicionar.FlatStyle = FlatStyle.Flat;
            bt_adicionar.Location = new Point(463, 137);
            bt_adicionar.Name = "bt_adicionar";
            bt_adicionar.Size = new Size(147, 24);
            bt_adicionar.TabIndex = 17;
            bt_adicionar.Text = "Adicionar";
            bt_adicionar.UseVisualStyleBackColor = false;
            bt_adicionar.Click += BuscarCliente;
            // 
            // TelaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bt_adicionar);
            Controls.Add(rb_Cnpj);
            Controls.Add(rb_Cpf);
            Controls.Add(lb_Documento);
            Controls.Add(txb_documento);
            Controls.Add(label1);
            Controls.Add(txb_endereco);
            Controls.Add(dtp_DataNasc);
            Controls.Add(lb_DataNasc);
            Controls.Add(lb_Contato);
            Controls.Add(txb_Contato);
            Controls.Add(lb_Nome);
            Controls.Add(txb_Nome);
            Name = "TelaCliente";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_Nome;
        private TextBox txb_Nome;
        private Label lb_Contato;
        private TextBox txb_Contato;
        private Label lb_DataNasc;
        private DateTimePicker dtp_DataNasc;
        private Label label1;
        private TextBox txb_endereco;
        private Label lb_Documento;
        private TextBox txb_documento;
        private RadioButton rb_Cpf;
        private RadioButton rb_Cnpj;
        private Button bt_adicionar;
    }
}
