namespace ErrorsAsValues;

public interface IError
{
    string Error();
}

public record NullArgumentError(string Argument) : IError
{
    public string Error() => $"{Argument} cannot be null";
}

public record UserNotFoundError : IError
{
    public string Error() => "User does not exist";
}

public record UniqueEmailError : IError
{
    public string Error() => "Email already taken";
}
