using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mediator_Bank
{
    namespace Coding.Exercise
    {
        public class Token
        {
            public int Value = 0;

            public Token(int value)
            {
                this.Value = value;
            }
        }

        public class Memento
        {
            public List<Token> Tokens = new List<Token>();
        }

        public class TokenMachine
        {
            public List<Token> Tokens = new List<Token>();

            public Memento AddToken(int value)
            {
                return AddToken(new Token(value));
            }

            public Memento AddToken(Token token)
            {
               // return AddToken(token);

                Tokens.Add(token);
                var m = new Memento();

                m.Tokens = Tokens.Select(t => new Token(t.Value)).ToList(); // Lambda/LINQ
                return m; // Here it Selects the element in the List of Tokens where Value matches for the given Token token. See mewthod Token above
                          // It then coverts the reult intoa Token and then into a List.
            }

            public void Revert(Memento m)
            {
                Tokens = m.Tokens.Select(mm => new Token(mm.Value)).ToList();
            }
        }
    }

}
