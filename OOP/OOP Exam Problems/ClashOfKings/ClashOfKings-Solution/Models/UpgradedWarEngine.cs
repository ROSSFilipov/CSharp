using ClashOfKings.Contracts;
using ClashOfKings.Engine;
using ClashOfKings.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models
{
    public class UpgradedWarEngine : WarEngine
    {
        public UpgradedWarEngine(
            IRenderer renderer,
            IInputController inputController,
            IUnitFactory unitFactory,
            IArmyStructureFactory armyStructureFactory,
            ICommandFactory commandFactory,
            IContinent continent)
            :  base(
            renderer,
            inputController,
            unitFactory,
            armyStructureFactory,
            commandFactory,
            continent
            )
        {
        }

        public override void ExecuteCommand(string commandInput)
        {
            base.ExecuteCommand(commandInput);
        }

        public override void Run()
        {
            base.Run();
        }
    }
}
