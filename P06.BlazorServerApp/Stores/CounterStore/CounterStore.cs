using System;

namespace P06.BlazorServerApp.Stores.CounterStore
{

    public class CounterState
    { 
        public int Count { get;  }
        public CounterState(int count)
        {
           this.Count = count;
        }

    }

    public class CounterStoreWithDispatcherWithInput: CounterStoreWithDispatcher
    {
        public int Step { get; set; } = 0;
        public CounterStoreWithDispatcherWithInput(IActionDispatcher actionDispatcher) :base(actionDispatcher)
        {


        }

        ~CounterStoreWithDispatcherWithInput()
        {
            this._actionDispatcher.Unsubscript(HandleActions);
        }


        protected override void HandleActions(IAction action)
        {
            switch (action.Name)
            {
                case IncrementAction.INCREMENT:
                    IncrementCount(this.Step);
                    break;
                case DecrementAction.DECREMENT:
                    DecrementCount(this.Step);
                    break;
                default:
                    break;
            }
        }


        #region increase and decrease state count, make it private. handle by IActionDispatcher

        private void IncrementCount(int step)
        {
            var count = this._state.Count;
            count += step;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        private void DecrementCount(int step)
        {
            var count = this._state.Count;
            count -= step;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        #endregion


        #region observer pattern
        //from super class
        #endregion

    }


    public class CounterStoreWithDispatcher
    {
        protected CounterState _state;

        protected readonly IActionDispatcher _actionDispatcher;

        //inject dispatcher instance and register own emthod of handing events.
        public CounterStoreWithDispatcher(IActionDispatcher actionDispatcher)
        {
            _state = new CounterState(0);
            this._actionDispatcher = actionDispatcher;
            this._actionDispatcher.Subscript(HandleActions);
        }

        ~CounterStoreWithDispatcher()
        {
            this._actionDispatcher.Unsubscript(HandleActions);
        }


        public CounterState GetState()
        {
            return _state;
        }

        protected virtual void HandleActions(IAction action)
        {
            switch (action.Name)
            {
                case IncrementAction.INCREMENT:
                    IncrementCount();
                    break;
                case DecrementAction.DECREMENT:
                    DecrementCount();
                    break;
                default:
                    break;
            }
        }



        #region increase and decrease state count, make it private. handle by IActionDispatcher

        private void IncrementCount()
        {
            var count = this._state.Count;
            count += 3;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        private void DecrementCount()
        {
            var count = this._state.Count;
            count -= 3;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        #endregion


        #region observer pattern

        private Action _listeners;
        public void AddStateChangeListeners(Action listener)
        {
            _listeners += listener;
        }

        public void RemoveStateChangeListeners(Action listener)
        {
            _listeners -= listener;
        }

        protected void BroadcastStateChange()
        {
            _listeners.Invoke();
        }

        #endregion

    }

    public class CounterStore
    {
        private CounterState _state;

        public CounterStore()
        {
            _state = new CounterState(0);
        }

        public CounterState GetState()
        {
            return _state;
        }

        #region increase and decrease state count

        public void IncrementCount()
        {
            var count = this._state.Count;
            count = count+2;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        public void DecrementCount()
        {
            var count = this._state.Count;
            count = count-2;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        #endregion


        #region observer pattern

        private Action _listeners;
        public void AddStateChangeListeners(Action listener)
        {
            _listeners += listener;
        }

        public void RemoveStateChangeListeners(Action listener)
        {
            _listeners -= listener;
        }

        private void BroadcastStateChange()
        {
            _listeners.Invoke();
        }

        #endregion
    }
}
