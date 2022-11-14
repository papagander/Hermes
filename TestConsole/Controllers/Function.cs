namespace TestConsole.Controllers
{
    public class Function
    {
        public string Name { get; protected set; }
        public Action Action { get; protected set; }

        public Function(string name, Action action)
        {
            Name = name;
            Action = action;
        }
    }
}