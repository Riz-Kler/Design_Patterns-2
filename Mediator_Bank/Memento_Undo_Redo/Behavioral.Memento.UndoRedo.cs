using System.Collections.Generic;
using static System.Console;

namespace DotNetDesignPatternDemos.Behavioral.Memento.UndoRedo
{
  public class Memento
  {
    public int Balance { get; }

    public Memento(int balance)
    {
      Balance = balance;
    }
  }

  public class BankAccount
  {
    private int balance;
    private List<Memento> changes = new List<Memento>(); // here a list of different Mementos are saved.
    private int current;

    public BankAccount(int balance)
    {
      this.balance = balance;
      changes.Add(new Memento(balance));  // Here you can roll back to the initial state at creation
    }

    public Memento Deposit(int amount)
    {
      balance += amount;
      var m = new Memento(balance);    // When ever a new Memento is created it nis saved in changes above
      changes.Add(m);
      ++current;
      return m;
    }

    public void Restore(Memento m)
    {
      if (m != null)   // A null check is introduced in case you try to Undo somethign that is empty
      {
        balance = m.Balance;  // Balance set tom created Mmento balance
        changes.Add(m);       // Added to list of changes
        current = changes.Count - 1;  // increment the count of Mementos added to the list
      }
    }

    public Memento Undo()
    {
      if (current > 0) // Checking that changes exist
      {
        var m = changes[--current];  // Here the current in List of Changes is stepped back it's an Undo
        balance = m.Balance;         // Balance set and returned
        return m;
      }
      return null; // return null if empty
    }

    public Memento Redo()
    {
      if (current + 1 < changes.Count)  // here we check that the number of changes allows a Redo that is one exists
      {
        var m = changes[++current];   // Move to the next Memento in the List
        balance = m.Balance;    // set and return the Balance
        return m;
      }
      return null;  // return null if no chsnges exist
    }

    public override string ToString()
    {
      return $"{nameof(balance)}: {balance}";
    }
  }

  public class Demo
  {
    static void Main(string[] args)  // a list of every possible change is recorded
    {
      var ba = new BankAccount(100);
      ba.Deposit(50);
      ba.Deposit(25);

      WriteLine(ba);

      ba.Undo();
      WriteLine($"Undo 1: {ba}");
      ba.Undo();
      WriteLine($"Undo 2: {ba}");
      ba.Redo();
      WriteLine($"Redo 2: {ba}");
    }
  }
}