using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Optional
{
    public sealed class Optional<T> where T : struct
    {
        /// <summary>
        /// Indica se o valor foi explicitamente fornecido.
        /// </summary>
        public bool HasChange { get; }

        /// <summary>
        /// Valor informado. Pode ser <c>null</c> quando o valor foi
        /// explicitamente definido como nulo.
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Optional{T}"/>.
        /// </summary>
        /// <param name="haschange">
        /// Indica se um valor foi explicitamente fornecido.
        /// </param>
        /// <param name="value">
        /// Valor associado à instância. Pode ser <c>null</c> quando o valor foi
        /// explicitamente definido como nulo.
        /// </param>
        private Optional(bool haschange, T? value)
        {
            HasChange = haschange;
            Value = value;
        }

        /// <summary>
        /// Cria uma instância indicando que nenhum valor foi fornecido.
        /// </summary>
        /// <returns>
        /// Instância de <see cref="Optional{T}"/> representando ausência de alteração.
        /// </returns>
        public static Optional<T> NotProvided()
            => new Optional<T>(false, default);

        /// <summary>
        /// Cria uma instância indicando que o valor foi explicitamente definido como nulo.
        /// </summary>
        /// <returns>
        /// Instância de <see cref="Optional{T}"/> representando uma alteração com valor nulo.
        /// </returns>
        public static Optional<T> FromNullValue()
            => new Optional<T>(true, null);

        /// <summary>
        /// Converte implicitamente um valor para <see cref="Optional{T}"/>,
        /// indicando que o valor foi fornecido.
        /// </summary>
        /// <param name="value">Valor a ser convertido.</param>
        public static implicit operator Optional<T>(T? value)
            => new Optional<T>(true, value);
    }

}
