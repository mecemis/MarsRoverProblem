using System.Collections.Generic;

namespace MarsRover.Application.Common.Interfaces
{
    public interface IInvoker
    {
        void Execute(ICommand command);
        void ExecuteAll(IEnumerable<ICommand> commands);
    }
}