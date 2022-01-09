using System.Collections.Generic;
using MarsRover.Application.Common.Interfaces;

namespace MarsRover.Application.Common.Concrete
{
    public class Invoker : IInvoker
    {
        public void Execute(ICommand command)
        {
            command.Execute();
        }

        public void ExecuteAll(IEnumerable<ICommand> commands)
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }
    }
}