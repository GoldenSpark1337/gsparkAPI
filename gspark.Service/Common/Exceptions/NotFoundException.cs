namespace gspark.Service.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name)
            : base($"Entity \"{name}\" not found.") { }
        public NotFoundException(string name, int id)
            : base($"Entity \"{name}\" ({id}) not found.") { }
    }
}
