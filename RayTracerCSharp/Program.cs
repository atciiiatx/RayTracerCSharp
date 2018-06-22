using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Numerics;

namespace RayTracerCSharp
{
  class Program
  {
    static void Main(string[] args)
    {
      CreateTestPPM();
      CreateTestRayTrace();
    }


    static void CreateTestPPM()
    {
      int nx = 200;
      int ny = 100;
      Bitmap bmp = new Bitmap(nx, ny);
      for (int iy = ny-1; iy >= 0; --iy)
      {
        for (int ix = 0; ix < nx; ++ix)
        {
          int r = (int)(255.0f * ((float)ix / (float)nx));
          int g = (int)(255.0f * ((float)iy / (float)ny));
          int b = (int)(255.0f * 0.2f);
          bmp.SetPixel(ix, iy, Color.FromArgb(r, g, b));
        }
      }
      bmp.Save("ppmOut.png", System.Drawing.Imaging.ImageFormat.Png);
    }

    static Vector3 RayColor(Ray r)
    {
      Vector3 unitDirection = r.Direction / r.Direction.Length();
      float t = 0.5f * (unitDirection.Y + 1.0f);
      return (1.0f - t) * Vector3.One + t * new Vector3(0.5f, 0.7f, 1.0f);
    }

    static void CreateTestRayTrace()
    {
      int nx = 200;
      int ny = 100;
      Bitmap bmp = new Bitmap(nx, ny);
      Vector3 lowerLeftCorner = new Vector3(-2, -1, -1);
      Vector3 horizontal = new Vector3(4, 0, 0);
      Vector3 vertical = new Vector3(0, 2, 0);
      Vector3 origin = Vector3.Zero;
      for (int iy = ny - 1; iy >= 0; --iy)
      {
        for (int ix = 0; ix < nx; ++ix)
        {
          float u = (float)ix / (float)nx;
          float v = (float)iy / (float)ny;
          Ray ray = new Ray(origin, lowerLeftCorner + u * horizontal + v * vertical);
          Vector3 rayColor = RayColor(ray);
          int r = (int)(255.99 * rayColor.X);
          int g = (int)(255.99 * rayColor.Y);
          int b = (int)(255.99 * rayColor.Z);
          bmp.SetPixel(ix, iy, Color.FromArgb(r, g, b));
        }
      }
      bmp.Save("rayTraceOut.png", System.Drawing.Imaging.ImageFormat.Png);
    }
  }
}
