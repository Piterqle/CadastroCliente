using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Aplication
{
    public abstract class CustomValidatableObjectCheck
    {
        public IList<ValidationResult> Validate()
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);

            Validator.TryValidateObject(
                this,
                context,
                results,
                validateAllProperties: true
            );

            return results;
        }
    }
}
