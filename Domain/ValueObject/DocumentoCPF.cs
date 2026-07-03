namespace CadastroCliente.Domain.ValueObject
{
    internal class DocumentoCPF
    {
        public string CPF { get; private set; }
        public string? DocumentoNumerico { get; private set; }

        public DocumentoCPF(string documento)
        {
            var (isValid, errorMessage) = ValidarCPF(documento);
            if (!isValid)
            {
                throw new ArgumentException(errorMessage);
            }
            CPF = documento;
        }

        private (bool, string) ValidarCPF(string cpf) // Retorna uma tupla indicando se o CPF é válido e uma mensagem de erro, se aplicável
        {
            if (cpf == null ) return (false, "CPF inválido");

            if (cpf.Length == 14)  cpf = cpf.Replace(".", "").Replace("-", "").Trim();

            if (cpf.Distinct().Count() == 1) return (false, "CPF não pode ter todos os dígitos iguais");

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(cpf[i].ToString()) * multiplicador1[i];

            int resto = sum % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[9].ToString()) != digito1) return (false, "CPF inválido");


            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(cpf[i].ToString()) * multiplicador2[i];

            resto = sum % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[10].ToString()) != digito2) return (false, "CPF inválido");


            DocumentoNumerico = cpf; // Armazena apenas os números do CPF sem formatação

            // Implementação da validação do CPF
            // Retorna true se o CPF for válido, caso contrário, retorna false
            return (true, string.Empty); // Substitua com a lógica real de validação
        }
    }
}
