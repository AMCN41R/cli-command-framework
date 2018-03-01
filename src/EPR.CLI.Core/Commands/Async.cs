using System;
using System.Threading.Tasks;

namespace EPR.CLI.Core.Commands
{
    internal static class Async
    {
        public static WrappedAsyncResult<T> Wrap<T>(Func<Task<T>> action)
        {
            try
            {
                return new WrappedAsyncResult<T>(action().Result);
            }
            catch (Exception ex)
            {
                return new WrappedAsyncResult<T>(ex);
            }
        }
    }
}