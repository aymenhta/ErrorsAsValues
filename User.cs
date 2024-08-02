namespace ErrorsAsValues;

public record User(string Name, int Age, string Email, string Password);


public class UserService
{
    private readonly List<User> USERS = [
        new User("User #1", 33, "user_1@example.com", "test123"),
        new User("User #2", 45, "user_2@example.com", "test123"),
        new User("User #3", 20, "user_3@example.com", "test123"),
        new User("User #4", 27, "user_4@example.com", "test123"),
    ];

    public IError? Add(User? newUser)
    {
        if (newUser is null)
            return new NullArgumentError(nameof(newUser));

        // check if exist a user with the same email
        if (USERS.Any(u => u.Email == newUser.Email))
            return new UniqueEmailError();

        USERS.Add(newUser);
        return null;
    }

    public (User?, IError?) FindByEmail(string? email)
    {
        if (email is null)
            return (null, new NullArgumentError(nameof(email)));

        var userExists = USERS.FirstOrDefault(u => u.Email == email);
        return userExists switch
        {
            User u => (u, null),
            _ => (null, new UserNotFoundError()),
        };
    }
}