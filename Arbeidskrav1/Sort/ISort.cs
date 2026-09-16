namespace Arbeidskrav1;

public enum SortOrder { Ascending, Descending }
public interface ISort
{
    public Contact[] Sort(Contact[] array, Field field);
}