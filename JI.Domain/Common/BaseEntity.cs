namespace JI.Domain.Common;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreationDate { get; private set; }
    public BaseEntity()
    {
        CreationDate = DateTime.Now;
    }
}
