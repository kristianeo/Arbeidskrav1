namespace Arbeidskrav1;

public enum Field { FirstName, LastName, Mobile }

public abstract class Algorithm
{
    protected SortOrder Order = SortOrder.Ascending;
    
    protected string GetField(Contact contact, Field field) => field switch
    {
        Field.FirstName => contact.FirstName,
        Field.LastName => contact.LastName,
        Field.Mobile => contact.Mobile,
        _ => throw new ArgumentOutOfRangeException(nameof(field))
    };

    protected int _comparisons;

    protected int _moves;

    public int Comparisons => _comparisons;

    protected int FindOrder(string a, string b, Field field)
    {
        _comparisons++;
        int result = Math.Sign(string.Compare(a, b,
            StringComparison.OrdinalIgnoreCase));
        
        if (Order == SortOrder.Descending) return -result;
        
        return result;
    }
}
