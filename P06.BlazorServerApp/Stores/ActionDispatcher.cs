using System;

namespace P06.BlazorServerApp.Stores
{
    public class ActionDispatcher : IActionDispatcher
    {
        private Action<IAction> _registeredActionHandlers;

        public void Subscript(Action<IAction> actionhandler)
        {
            _registeredActionHandlers += actionhandler;
        }

        public void Unsubscript(Action<IAction> actionHandler)
        {
            _registeredActionHandlers -= actionHandler;
        }

        public void Dispatch(IAction action)
        {
            _registeredActionHandlers?.Invoke(action);
        }
    }
}
