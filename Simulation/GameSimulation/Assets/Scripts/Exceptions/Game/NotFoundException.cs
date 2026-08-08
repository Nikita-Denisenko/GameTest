namespace Assets.Scripts.Exceptions.Game
{
    public class NotFoundException : GameException
    {
        public NotFoundException(
            string entityName,
            object id)
            : base($"{entityName} with id '{id}' was not found.")
        {
        }
    }
}
