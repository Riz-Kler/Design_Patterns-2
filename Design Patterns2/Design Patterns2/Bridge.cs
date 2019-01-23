using System;
using Autofac;
using static System.Console;


namespace Design_Patterns2
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing a circle of radius {radius}");

        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing pixels for circle with radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer) // Protected method used for aggregation of the renderer using san Interface
        {
            this.renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape //Inherits from shape and using the bridge to IRenderer
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
           renderer.RenderCircle(radius); 
        }

        public override void Resize(float factor)
        {
            radius = radius * factor;
        }
    }

  class Bridge
    {
        static void Main(string[] args)

        // Better to use dependency injection here
        {
            //           IRenderer renderer1 = new VectorRenderer();
            //           IRenderer renderer2 = new RasterRenderer();
            //           var circle1 = new Circle(renderer1, 5);
            //           var circle2 = new Circle(renderer2, 5);
            //           circle1.Draw();
            //           circle2.Draw();
            //           circle1.Resize(2);
            //           circle2.Resize(2);
            //           circle1.Draw();
            //           circle2.Draw();

            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>()
                .SingleInstance();
            cb.Register((c, p) =>
            new Circle(c.Resolve<IRenderer>(), 
                    p.Positional<float>(0)));
            using (var c = cb.Build())
            {
                var circle = c.Resolve<Circle>(
                  new PositionalParameter(0, 5.0f)  
                    );
                circle.Draw();
                circle.Resize(2.0f);
                circle.Draw();
            }
        }
    }    
}
