namespace Utils
{
    public class NameValidator : IValidator
    {
        public NameValidator(string valueToValidate)
        {
            this.valueToValidate = valueToValidate;
        }
        private string valueToValidate;

        public string validValue { get; set; }

        public bool Validate()
        {
            var messageParts = valueToValidate.Split(new[] { ',' }, 2);

            if (messageParts.Length < 2)
                return false;

            string name = messageParts[1].Trim();

            if (!string.IsNullOrWhiteSpace(name))
                validValue = name;

            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
