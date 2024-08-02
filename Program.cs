using ErrorsAsValues;

UserService service = new();

var (user, error) = service.FindByEmail("user_5@example.com");
if (error is not null)
    switch (error)
    {
        case NullArgumentError e:
            Console.WriteLine($"ERROR: {e.Error()}");
            return;
        case UserNotFoundError e:
            Console.WriteLine($"ERROR: {e.Error()}");
            return;
        default:
            Console.WriteLine($"ERROR: {error.Error()}");
            return;
    }

Console.WriteLine(user);