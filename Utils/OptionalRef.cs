using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Utils
{
    public sealed class OptionalRef<T> where T : class
    {
        /// <summary>
        /// Indica se o valor foi explicitamente fornecido.
        /// </summary>
        public bool HasChange { get; }

        /// <summary>
        /// Valor informado. Pode ser <c>null</c> quando o valor foi
        /// explicitamente definido como nulo.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="OptionalRef{T}"/>.
        /// </summary>
        /// <param name="haschange">
        /// Indica se o valor foi explicitamente fornecido.
        /// </param>
        /// <param name="value">
        /// Valor associado à instância. Pode ser <c>null</c> quando o valor foi
        /// explicitamente definido como nulo.
        /// </param>
        private OptionalRef(bool haschange, T value)
        {
            HasChange = haschange;
            Value = value;
        }

        /// <summary>
        /// Cria uma instância indicando que nenhum valor foi fornecido.
        /// </summary>
        /// <returns>
        /// Instância de <see cref="OptionalRef{T}"/> representando ausência de alteração.
        /// </returns>
        public static OptionalRef<T> NotProvided()
            => new OptionalRef<T>(false, null);

        /// <summary>
        /// Cria uma instância indicando que o valor foi explicitamente definido como nulo.
        /// </summary>
        /// <returns>
        /// Instância de <see cref="OptionalRef{T}"/> representando uma alteração com valor nulo.
        /// </returns>
        public static OptionalRef<T> FromNullValue()
            => new OptionalRef<T>(true, null);

        /// <summary>
        /// Converte implicitamente um valor para <see cref="OptionalRef{T}"/>,
        /// indicando que o valor foi fornecido.
        /// </summary>
        /// <param name="value">Valor a ser convertido.</param>
        public static implicit operator OptionalRef<T>(T value)
            => new OptionalRef<T>(true, value);
    }
}
