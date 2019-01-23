using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility_Exercise
{
    public abstract class Creature
    {
        protected Game game;
        protected readonly int baseAttack;
        protected readonly int baseDefense;

        protected Creature(Game game, int baseAttack, int baseDefense)
        {
            this.game = game;
            this.baseAttack = baseAttack;
            this.baseDefense = baseDefense;
        }

        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }

    }

    public class Goblin : Creature
    {
       
        public Goblin(Game game) { }

        public override int Attack { get => base.Attack; set => base.Attack = value; }
        public override int Defense { get => base.Defense; set => base.Defense = value; }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) { }
    }

    public class Game
    {
        public IList<Creature> Creatures;
    }
}

