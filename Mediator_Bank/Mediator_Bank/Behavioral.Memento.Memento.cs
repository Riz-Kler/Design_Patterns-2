using static System.Console;

namespace DotNetDesignPatternDemos.Behavioral.Memento
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

    public BankAccount(int balance)
    {
      this.balance = balance;
    }

    public Memento Deposit(int amount)
    {
      balance += amount;
      return new Memento(balance);  // this creates a new Memento instance that records the current balance
    }

    public void Restore(Memento m)
    {
      balance = m.Balance;         // this returns the balance to the balance of the Memento
    }

    public override string ToString()
    {
      return $"{nameof(balance)}: {balance}";
    }
  }

  public class Demo
  {
    static void Main(string[] args)
    {
      var ba = new BankAccount(100);  // Can't roll back to here as no Memento Token is created
      var m1 = ba.Deposit(50); // 150 a new Memento is created with 50 depotied Balance = 200
      var m2 = ba.Deposit(25); // 175 

        WriteLine(ba); // initial balance

      // restore to m1
      ba.Restore(m1);  
      WriteLine(ba);  // m1 balance

      ba.Restore(m2);
      WriteLine(ba); // m2 balance
    }
  }         // if you had Command Query you could roll back further see Rollback example
}