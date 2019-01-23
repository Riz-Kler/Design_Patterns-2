using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Coding.Exercise;

//namespace Design_Patterns2
//using System;

namespace Coding.Exercise
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; set; }
    }
    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
  
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
            // public Triangle() => Name = "Triangle";
        }
    }

    public class Square : Shape
    {
 
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
            // public Square() => Name = "Square";
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs
        {
            get { return "lines"; }
            set => throw new NotImplementedException();
        }
    }
            
        
   // }

    public class RasterSquare : IRenderer
    {
    public string WhatToRenderAs
    {
        get { return "pixels"; }
        set => throw new NotImplementedException();
    }
    }

    // imagine VectorTriangle and RasterTriangle are here too
}



