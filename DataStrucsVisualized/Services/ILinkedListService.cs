namespace DataStrucsVisualized.Services;

public interface ILinkedListService
{
    LinkedList CreateLinkedList(LinkedList linkedList);
    IEnumerable<LinkedList> GetAllLinkedLists();
}