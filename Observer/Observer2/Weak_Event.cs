using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Windows;

namespace Observer
{
    // when you edit contronls in WinForm or WPF

    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window //Could use IDisposable to creste -= ButtonClicked; method but better to use WeakEvent Manager
    {
        public Window(Button button)
        {
         //   button.Clicked += ButtonOnClicked;

            WeakEventManager<Button, EventArgs> // WeakEvent Design Pattern
                .AddHandler(button, "Clicked", ButtonOnClicked);   // Since .NET 4.5
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            WriteLine("Button clicked (Window handler)");
        }

        ~Window() // Destructor
        {
            WriteLine("Window finalised");
        }
    }

    public class Weak_Event
    {
        static void Main(string[] args)
        {
            var button = new Button();
            var window = new Window(button);
            var windowRef = new WeakReference(window);  // This does not take the life time of the window as its base constructor
            button.Fire();

            WriteLine("Setting Window to null");
            window = null;  // bUT THE INSTANCE OF THE bUTTON STILL EXISTS

            FireGC();    // Fire Garbage Collector
            WriteLine($"Is the window alive after GC? {windowRef.IsAlive}"); //The Window is still alive because the Event is leaking
        }

        private static void FireGC()
        {
            WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(); // Running to here shows that the Button isn't Finalaised because it is connected an instance of Window
            WriteLine("GC is done!");
        }
    }
}
