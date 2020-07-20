namespace Utils
{
    public interface IValidator
    {
        string validValue { get; }
        bool Validate();
    }
}