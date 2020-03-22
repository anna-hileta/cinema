namespace Cinema.Core.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
