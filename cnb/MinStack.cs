using System;
using System.Collections.Generic;
using System.Linq;

namespace cnb
{
    public class MinStack
    {
        private int _calls;
        private readonly double _maxCalls = Math.Pow(10, 4) * 3;
        private readonly Stack<int> _stack;

        public MinStack()
        {
            _stack = new Stack<int>();
        }

        #region public methods

        public int GetMin()
        {
            ValidateCalls();
            var sArray = new int[_stack.Count];
            _stack.CopyTo(sArray, 0);
            return sArray.ToList().Min();
        }
        public int Top()
        {
            ValidateCalls();
            return _stack.Peek();
        }

        public new void Push(int value)
        {
            ValidateCalls();
            _stack.Push(value);
        }

        public new void Pop()
        {
            ValidateCalls();
            _stack.Pop();
        }

        #endregion

        #region private methods

        private void ValidateCalls()
        {
            if (_calls > _maxCalls)
                throw new Exception("Exceeded number of calls");
            _calls++;
        }
        #endregion

    }
}