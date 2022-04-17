namespace sg.adnovum.keyboard.assist
{
    public interface IValidationRule
    {
        bool IsValid(string line);
    }
}