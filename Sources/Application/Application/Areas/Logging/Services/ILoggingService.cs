using System;

namespace Mmu.CleanArchitecture.Application.Areas.Logging.Services
{
    public interface ILoggingService
    {
        void LogError(string message);

        void LogException(Exception ex);

        void LogInformation(string message);

        void LogWarning(string warning);
    }
}