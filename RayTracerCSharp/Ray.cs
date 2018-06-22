using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RayTracerCSharp
{
  class Ray
  {
    // Default Constructor
    public Ray()
    {
    }

    // Data constructor
    public Ray(Vector3 a, Vector3 b)
    {
      Origin = a;
      Direction = b;
    }

    // Properties
    public Vector3 Origin { get; set; }
    public Vector3 Direction { get; set; }

    // Point along ray
    public Vector3 PointAtParameter(float t)
    {
      return Origin + t * Direction;
    }
  }
}
