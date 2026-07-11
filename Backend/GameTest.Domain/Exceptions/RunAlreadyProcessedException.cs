namespace GameTest.Domain.Exceptions
{
    public class RunAlreadyProcessedException : Exception
    {
        public RunAlreadyProcessedException()
            : base("Run result has already been processed")
        {
        }
    }
}
