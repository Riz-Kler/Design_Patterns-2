using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;
//using DotNetDesignPatternDemos.Behavioral.ChainOfResponsibility.MethodChain;
using static System.Console;

namespace Chain_of_ResponsibilityBlock
{
    public class Game //using mediator pattern
    {
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }
    }

    public class Query
    {
        public string CreatureName;

        public enum Argument
        {
            Attack, Defense
        }

        public Argument WhatToQuery;

        public int Value;

        public Query(string creatureName, Argument whatToQuery, int value)
        {
            CreatureName = creatureName ?? throw new ArgumentNullException(nameof(creatureName));
            WhatToQuery = whatToQuery; //?? throw new ArgumentNullException(nameof(whatToQuery));
            Value = value; //initial value before bonus
        }
    }

    public class Creature
    {
        private Game game;
        public string Name;
        private int attack, defense;

        public Creature(Game game, string name, int attack, int defense)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.attack = attack;
            this.defense = defense;
        }

        public int Attack
        {
            get
            {
                var q = new Query(Name, Query.Argument.Attack, attack);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public int Defense
        {
            get
            {
                var q = new Query(Name, Query.Argument.Defense, defense);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public abstract class CreatureModifier : IDisposable
    {
        protected Game game;
        protected Creature creature;

        protected CreatureModifier(Game game, Creature creature)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
            game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query q);

        public void Dispose()
        {
            // throw new NotImplementedException();

            game.Queries -= Handle;
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
          //  throw new NotImplementedException();
            if (q.CreatureName == creature.Name
                && q.WhatToQuery == Query.Argument.Attack)
                q.Value *= 2;

         }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
           // throw new NotImplementedException();
            if (q.CreatureName == creature.Name
                && q.WhatToQuery == Query.Argument.Defense)
                q.Value += 2;
        }
    }

    public class Demo
    {

        static void Main(string[] args)
        {
            var game = new Game();
            var goblin = new Creature(game, "Strong Goblin", 3, 3);
            WriteLine(goblin);

            using (new DoubleAttackModifier(game, goblin))
            {
            WriteLine(goblin);

                using (new IncreaseDefenseModifier(game, goblin))
                {
                    WriteLine(goblin);
                }

            }
            WriteLine(goblin);
        }
    }
}
