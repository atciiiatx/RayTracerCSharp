using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace RayTracerCSharp
{
  class Program
  {
    static void Main(string[] args)
    {
      CreateTestPPM();
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
      bmp.Save("out.png", System.Drawing.Imaging.ImageFormat.Png);
    }
  }
}
