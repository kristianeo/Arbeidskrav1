namespace Arbeidskrav1;

public enum Field { FirstName, LastName, Mobile }

public abstract class Algorithm
{
    private string GetField(Contact contact, Field field) => field switch
    {
        Field.FirstName => contact.FirstName,
        Field.LastName => contact.LastName,
        Field.Mobile => contact.Mobile,
        _ => throw new ArgumentOutOfRangeException(nameof(field))
    };

    protected int _comparisons;

    public int Comparisons => _comparisons;

    protected bool FindOrder(Contact a, Contact b, Field field, SortOrder order)
    {
        switch (order)
        {
            case SortOrder.Ascending when string.Compare(GetField(a, field), GetField(b, field),
                StringComparison.OrdinalIgnoreCase) > 0:
            case SortOrder.Descending when string.Compare(GetField(a, field), GetField(b, field),
                StringComparison.OrdinalIgnoreCase) < 0:
                _comparisons++;
                return true;
            default:
                _comparisons++;
                return false;
        }
    }
}
