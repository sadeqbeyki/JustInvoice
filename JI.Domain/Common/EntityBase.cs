namespace JI.Domain.Common;

public class EntityBase<T>
{
    public T Id { get; set; }
    public DateTime CreationDate { get; private set; }
    public EntityBase()
    {
        CreationDate = DateTime.Now;
    }
}
