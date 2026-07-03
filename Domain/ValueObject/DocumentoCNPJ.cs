namespace CadastroCliente.Domain.ValueObject
{
    internal class DocumentoCNPJ
    {
        public string documento { get; private set; }

        public DocumentoCNPJ(string documento)
        {
            var (isValid, errorMessage) = ValidarCNPJ(documento);
            if (!isValid)
            {
                throw new ArgumentException(errorMessage);
            }
            this.documento = documento;
        }


        private (bool, string) ValidarCNPJ(string cnpj) // Retorna uma tupla indicando se o CNPJ é válido e uma mensagem de erro, se aplicável
        {
            if (cnpj.Length != 18) return (false, "CNPJ deve ter 18 caracteres no formato XX.XXX.XXX/XXXX-XX");

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

            if (cnpj.Distinct().Count() == 1) return (false, "CNPJ não pode ter todos os dígitos iguais");


            int[] mult1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(cnpj[i].ToString()) * mult1[i];

            int resto = sum % 11;
            int firstDigit = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cnpj[12].ToString()) != firstDigit) return (false, "CNPJ inválido");


            int[] mult2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(cnpj[i].ToString()) * mult2[i];

            resto = sum % 11;
            int secondDigit = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cnpj[13].ToString()) != secondDigit) return (false, "CNPJ inválido");

            // Implementação da validação do CNPJ
            // Retorna true se o CNPJ for válido, caso contrário, retorna false
            return (true, string.Empty); // Substitua com a lógica real de validação
        }
    }
}
