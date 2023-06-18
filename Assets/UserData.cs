
public class UserData 
{
    string email = "";
    string id = "";
    string password = "";

    public UserData(string email, string id, string password)
    {
        this.Email = email;
        this.Id = id;
        this.Password = password;
    }

    public string Email { get => email; set => email = value; }
    public string Id { get => id; set => id = value; }
    public string Password { get => password; set => password = value; }


}
