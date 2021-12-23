using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace ClothSFML
{
    static class SFML_Helper
    {
        public static Vector2 cameraPosition;
        public static RenderWindow Window;
        public static float orthographicSize = 20;

        public static void DrawLine(Vector2 start, Vector2 end, Color color)
        {
            Window.Draw(new Vertex[] { new Vertex(start.toVector2f(), color), new Vertex(end.toVector2f(), color) }, PrimitiveType.Lines);
        }

        public static void DrawPixel(Vector2 point)
        {
            Window.Draw(new Vertex[] { new Vertex(point.toVector2f()) }, PrimitiveType.Points);
        }

        public static Color ColorLerp(Color a, Color b, float t)
        {
            t = Math.Clamp(t, 0, 1);
            return new Color()
            {
                R = (byte)((a.R + (b.R - a.R) * t)),
                G = (byte)((a.G + (b.G - a.G) * t)),
                B = (byte)((a.B + (b.B - a.B) * t)),
                A = (byte)((a.A + (b.A - a.A) * t))
            };
        }

        public static Vector2 mousePosition
        {
            get
            {
                return new Vector2((Vector2f)(SFML.Window.Mouse.GetPosition() - Window.Position));
            }
        }
    }
}
