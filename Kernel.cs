using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Drawing;
using Cosmos.System.Graphics;
using Cosmos.Debug.Kernel;
using Point = Cosmos.System.Graphics.Point;
using Cosmos.System.Graphics.Fonts;
using System.Threading;
using System.Diagnostics;


namespace Cosmos_Graphic_Subsytem
{
    public class myobject
    {
       
        public int x = 0;
        public int y = 0;
        public int w=1;
        public int h = 1;
        public Pen fore = new Pen(Color.Black);
        public myobject()
        {

        }
        public void draw(Canvas c)
        {
            Point p = new Point(x, y);
            Point p1 = new Point(x+w, y+h);
            Point p2 = new Point(x, y + h);
            Point p3 = new Point(x+w, y);
            c.DrawRectangle(fore, p, w, x);
            c.DrawLine(fore, p, p1);
            c.DrawLine(fore, p2, p3);

        }
       
    }
    public class Kernel : Sys.Kernel
    {

        

        private Canvas canvas;
        private Bitmap bitmap;

        protected override void BeforeRun()
        {
            
            Mode start = new Mode(320, 200, ColorDepth.ColorDepth32);

  
           
            
            canvas = FullScreenCanvas.GetFullScreenCanvas(start); 

           
            canvas.Clear(Color.Green);
        }

        protected override void Run()
        {
            try
            {
                int x = 0;
                int y = 0;
                myobject vr = new myobject();
                vr.w = 10;
                vr.h = 10;
                for (y = 0; y < 290; y=y+10)
                {
                    for (x = 0; x < 300; x=x+10)
                    {
                        vr.x = x;
                        vr.y = y;
                        vr.draw(canvas);
                    }
                }


                canvas.Display();


                Console.ReadKey();

               
                Console.ReadKey(true);


                Sys.Power.Shutdown();
            }
            catch (Exception e)
            {
                
                
            }
        }
    }
}