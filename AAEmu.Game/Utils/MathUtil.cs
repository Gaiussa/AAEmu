using System;
using AAEmu.Game.Models.Game.World;

namespace AAEmu.Game.Utils
{
    public class MathUtil
    {
        // Return degree value of object 2 to the horizontal line with object 1 being the origin
        public static double CalculateAngleFrom(GameObject obj1, GameObject obj2)
        {
            return CalculateAngleFrom(obj1.Position.X, obj1.Position.Y, obj2.Position.X, obj2.Position.Y);
        }

        // Return degree value of object 2 to the horizontal line with object 1 being the origin
        public static double CalculateAngleFrom(float obj1X, float obj1Y, float obj2X, float obj2Y)
        {
            var angleTarget = RadianToDegree(Math.Atan2(obj2Y - obj1Y, obj2X - obj1X));
            if(angleTarget < 0)
                angleTarget += 360;
            return angleTarget;
        }
        
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
        
        public static double ConvertDirectionToDegree(sbyte direction)
        {
            var angle = (direction) * (360f / 128) + 90;
            if(angle < 0)
                angle += 360;
            return angle;
        }
        
        public static bool IsFront(GameObject obj1, GameObject obj2)
        {
            var degree = CalculateAngleFrom(obj1, obj2);
            var degree2 = ConvertDirectionToDegree(obj2.Position.RotationZ);
            var diff = Math.Abs(degree - degree2);
            if(diff >= 90 && diff <= 270)
                return true;
            return false;
        }
    }
}