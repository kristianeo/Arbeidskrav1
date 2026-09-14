namespace Arbeidskrav1;

public interface ISort
{
    public Contact[] Sort(Contact[] array, Phonebook.Field field);
}