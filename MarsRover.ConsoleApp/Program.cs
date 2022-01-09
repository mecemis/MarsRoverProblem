using MarsRover.Application.Common.Concrete;
using MarsRover.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Application.Commands;
using MarsRover.Application.Helpers;
using MarsRover.Domain.Rovers;
using MarsRover.Domain.Surface;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddScoped<IInvoker, Invoker>()
                .BuildServiceProvider();

            IInvoker invoker = serviceProvider.GetService<IInvoker>()
                               ?? throw new NullReferenceException(nameof(invoker));

            string edgeOfAreaInput = Console.ReadLine();

            Dictionary<Rover, List<ICommand>> commands = new();

            Plateau plateau = InitializePlateau(edgeOfAreaInput, invoker);

            int roverId = 0;

            while (true)
            {
                roverId++;

                string startingCoordinatesInput = Console.ReadLine();

                string directions = Console.ReadLine();

                Rover rover = DeployRover(plateau, startingCoordinatesInput, roverId, invoker);

                List<ICommand> roverCommands = CommandHelper.GetRoverCommands(rover, directions);

                commands.Add(rover, roverCommands);

                Console.WriteLine("Add more rover? (Y/N)");

                string addMoreRover = Console.ReadLine()?.Trim();

                if (!string.Equals(addMoreRover, "Y", StringComparison.InvariantCultureIgnoreCase))
                    break;
            }

            invoker.ExecuteAll(commands.Values.SelectMany(x => x));

            foreach (Rover rover in commands.Keys)
                Console.WriteLine(rover.GetCurrentPosition());

        }

        private static Plateau InitializePlateau(string edgeOfAreaInput, IInvoker invoker)
        {
            InitializePlateauCommand initializePlateauCommand = new(edgeOfAreaInput);
            invoker.Execute(initializePlateauCommand);

            return initializePlateauCommand.Plateau;
        }

        private static Rover DeployRover(Plateau plateau, string startingCoordinatesInput, int roverId, IInvoker invoker)
        {
            DeployRoverCommand deployRoverCommand = new(plateau, startingCoordinatesInput, roverId);
            invoker.Execute(deployRoverCommand);

            return deployRoverCommand.Rover;
        }
    }
}
