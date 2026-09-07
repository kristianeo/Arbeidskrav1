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
    public string GetProperty(Phonebook.Field field)
    {
        string property;
        switch (field)
        {
            case Phonebook.Field.FirstName:
                property = _firstname;
                break;
            case Phonebook.Field.LastName:
                property = _lastname;
                break;
            case Phonebook.Field.Mobile:
                property = _mobile;
                break;
            default:
                property = "";
                break;
        }

        return property;
    }

    
}