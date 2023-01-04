namespace JI.Domain.Common;

public class EntityBase
{
    public long Id { get; set; }
    public DateTime CreationDate { get; private set; }
    public EntityBase()
    {
        CreationDate = DateTime.Now;
    }
}
