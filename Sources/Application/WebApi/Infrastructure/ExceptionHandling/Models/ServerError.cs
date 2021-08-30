using System;
using JetBrains.Annotations;
using Mmu.CleanArchitecture.Common.Areas.Invariance;

namespace Mmu.CleanArchitecture.WebApi.Infrastructure.ExceptionHandling.Models
{
    [PublicAPI]
    public class ServerError
    {
        private ServerError(string message, string typeName, string stackTrace)
        {
            Guard.StringNotNullOrEmpty(() => message);
            Guard.StringNotNullOrEmpty(() => typeName);

            Message = message;
            TypeName = typeName;
            StackTrace = stackTrace;
        }

        public string Message { get; }
        public string StackTrace { get; }
        public string TypeName { get; }

        public static ServerError CreateFromException(Exception exception)
        {
            Guard.ObjectNotNull(() => exception);

            var mostInnerEx = GetMostInnerException(exception);

            return new ServerError(mostInnerEx.Message, mostInnerEx.GetType().Name, mostInnerEx.StackTrace);
        }

        private static Exception GetMostInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex;
        }
    }
}