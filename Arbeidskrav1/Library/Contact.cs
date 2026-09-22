namespace Arbeidskrav1;

public class Contact
{
    private string _firstname;
    
    private string _lastname;

    private string _mobile;

    private DateOnly _birthday;

    private string _street;

    private string _city;

    public Contact(string info)
    {
        string[] newInfo = info.Split(',');
        _firstname = newInfo[0];
        _lastname = newInfo[1];
        _mobile = newInfo[2];
        _birthday = DateOnly.Parse(newInfo[3]);
        _street = newInfo[4];
        _city = newInfo[5];
        
    }

    public string FirstName => _firstname;
    
    public string LastName => _lastname;

    public string Mobile => _mobile;
    
    public string GetField(Field field) => field switch
    {
        Field.FirstName => FirstName,
        Field.LastName => LastName,
        Field.Mobile => Mobile,
        _ => throw new ArgumentOutOfRangeException(nameof(field))
    };

    public override string ToString()
    {
        return $"{_firstname}, {_lastname}, {_mobile}, {_birthday}, {_street}, {_city}";
    }
}