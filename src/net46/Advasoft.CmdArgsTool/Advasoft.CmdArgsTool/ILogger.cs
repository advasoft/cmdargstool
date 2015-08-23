
using System;

namespace Advasoft.CmdArgsTool
{
    public interface ILogger
    {
        void LogError(Exception exception);
        void LogError(string message);
        void LogError(string message, Exception exception);
    }
}
