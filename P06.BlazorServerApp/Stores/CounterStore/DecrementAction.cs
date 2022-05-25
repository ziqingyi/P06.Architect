namespace P06.BlazorServerApp.Stores.CounterStore
{
    public class DecrementAction : IAction
    {
        public string Name => DECREMENT;

        public const string DECREMENT = "DECREMENT";

    }
}
