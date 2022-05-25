using System;

namespace P06.BlazorServerApp.Stores
{
    public interface IActionDispatcher
    {
        void Dispatch(IAction action);
        void Subscript(Action<IAction> actionhandler);
        void Unsubscript(Action<IAction> actionHandler);
    }
}