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
            count++;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        public void DecrementCount()
        {
            var count = this._state.Count;
            count--;
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
