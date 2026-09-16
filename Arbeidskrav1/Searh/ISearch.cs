namespace Arbeidskrav1;

public interface ISearch
{
    public Contact[] Search(Contact[] array, Field field, string target);

    
}