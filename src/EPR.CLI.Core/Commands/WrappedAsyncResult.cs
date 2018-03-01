using System;

namespace EPR.CLI.Core.Commands
{
    internal class WrappedAsyncResult<T>
    {
        public WrappedAsyncResult(T result)
        {
            this.Result = result;
        }

        public WrappedAsyncResult(Exception ex)
        {
            this.Result = default(T);
            this.HasErrored = true;
            this.Exception = ex;
        }

        public T Result { get; }

        public bool HasErrored { get; }

        public Exception Exception { get; }
    }
}