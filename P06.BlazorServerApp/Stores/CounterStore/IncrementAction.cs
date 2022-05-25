namespace P06.BlazorServerApp.Stores.CounterStore
{
    public class IncrementAction : IAction
    {

        public string Name => INCREMENT;

        public const string INCREMENT = "INCREMENT";

        public int Count { get; set; }

    }
}
