namespace TheSlum.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using TheSlum.Characters;
    using TheSlum.Items;
    using TheSlum;

    public class Engine
    {
        protected List<Character> characterList = new List<Character>();
        protected LinkedList<Bonus> timeoutItems = new LinkedList<Bonus>();

        private const int GameTurns = 4;

        public virtual void Run()
        {
            this.ReadUserInput();

            for (int i = 0; i < GameTurns; i++)
            {
                foreach (var character in this.characterList)
                {
                    if (character.IsAlive)
                    {
                        this.ProcessTargetSearch(character);
                    }
                }

                this.ProcessItemTimeout();
            }

            this.PrintGameOutcome();
        }

        private void ReadUserInput()
        {
            string inputLine = Console.ReadLine();
            while (inputLine != string.Empty)
            {
                string[] parameters = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                this.ExecuteCommand(parameters);
                inputLine = Console.ReadLine();
            }
        }

        protected virtual void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus();
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    {
                        throw new InvalidOperationException("Invalid input!");
                    }
            }
        }

        protected void PrintCharactersStatus()
        {
            foreach (Character character in this.characterList)
            {
                Console.WriteLine(character.ToString());
            }
        }

        protected virtual void CreateCharacter(string[] inputParams)
        {
            string className = inputParams[1].ToLower();
            string charID = inputParams[2];
            int charX = int.Parse(inputParams[3]);
            int charY = int.Parse(inputParams[4]);
            string charTeam = inputParams[5];
            switch (className.ToLower())
            {
                case "warrior":
                    this.characterList.Add(new Warrior(charID, charX, charY, charTeam.ToLower() == "red" ? Team.Red : Team.Blue));
                    break;
                case "mage":
                    this.characterList.Add(new Mage(charID, charX, charY, charTeam.ToLower() == "red" ? Team.Red : Team.Blue));
                    break;
                case "healer":
                    this.characterList.Add(new Healer(charID, charX, charY, charTeam.ToLower() == "red" ? Team.Red : Team.Blue));
                    break;
                default:
                    {
                        throw new InvalidOperationException("Invalid input!");
                    }
            }
        }

        protected void AddItem(string[] inputParams)
        {
            Character target = this.characterList.FirstOrDefault(x => x.Id == inputParams[1]);

            if (target == null)
            {
                throw new InvalidOperationException("Character does not exists!");
            }

            string itemClass = inputParams[2].ToLower();
            string itemID = inputParams[3];
            switch (itemClass)
            {
                case "axe":
                    Item currentAxe = new Axe(itemID, target);
                    break;
                case "shield":
                    Item currenShield = new Shield(itemID, target);
                    break;
                case "pill":
                    Bonus currentPill = new Pill(itemID, target);
                    this.timeoutItems.AddLast(currentPill);
                    break;
                case "injection":
                    Bonus currentInjection = new Injection(itemID, target);
                    this.timeoutItems.AddLast(currentInjection);
                    break;
                default:
                    {
                        throw new InvalidOperationException("Invalid input!");
                    }
            }
        }

        public void ProcessItemTimeout()
        {
            List<Bonus> expiredItems = new List<Bonus>();
            foreach (var item in this.timeoutItems)
            {
                item.Countdown--;
                if (item.Countdown == 0)
                {
                    expiredItems.Add(item);
                }
            }

            foreach (Bonus expiredBonus in expiredItems)
            {
                expiredBonus.ItemHolder.RemoveFromInventory(expiredBonus);
                this.timeoutItems.Remove(expiredBonus);
            }
        }

        protected void ProcessTargetSearch(Character currentCharacter)
        {
            var availableTargets = this.characterList
                .Where(t => this.IsWithinRange(currentCharacter.X, currentCharacter.Y, t.X, t.Y, currentCharacter.Range) && t.IsAlive && t.Id != currentCharacter.Id)
                .ToList();

            if (availableTargets.Count == 0)
            {
                return;
            }

            var target = currentCharacter.GetTarget(availableTargets);
            if (target == null)
            {
                return;
            }

            this.ProcessInteraction(currentCharacter, target);
        }

        protected void ProcessInteraction(Character currentCharacter, Character target)
        {
            if (currentCharacter is IHeal)
            {
                (currentCharacter as IHeal).ExecuteHeal(target);
            }
            else if (currentCharacter is IAttack)
            {
                (currentCharacter as IAttack).ExecuteAttack(target);
            }
        }

        protected bool IsWithinRange(int attackerX, int attackerY, int targetX, int targetY, int range)
        {
            double distance = Math.Sqrt(
                (attackerX - targetX) * (attackerX - targetX) +
                (attackerY - targetY) * (attackerY - targetY));

            return distance <= range;
        }

        protected Character GetCharacterById(string characterId)
        {
            return this.characterList.FirstOrDefault(x => x.Id == characterId);
        }

        protected Character GetCharacterByItem(Item item)
        {
            return this.characterList.FirstOrDefault(x => x.Inventory.Contains(item));
        }

        protected void PrintGameOutcome()
        {
            var charactersAlive = this.characterList.Where(c => c.IsAlive);
            var redTeamCount = charactersAlive.Count(x => x.Team == Team.Red);
            var blueTeamCount = charactersAlive.Count(x => x.Team == Team.Blue);

            if (redTeamCount == blueTeamCount)
            {
                Console.WriteLine("Tie game!");
            }
            else
            {
                string winningTeam = redTeamCount > blueTeamCount ? "Red" : "Blue";
                Console.WriteLine(winningTeam + " team wins the game!");
            }

            var aliveCharacters = this.characterList.Where(c => c.IsAlive);

            foreach (Character aliveCharacter in aliveCharacters)
            {
                Console.WriteLine(aliveCharacter.ToString());
            }
        }
    }
}
