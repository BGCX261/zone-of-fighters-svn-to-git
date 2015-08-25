using System;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZoneOfFighters.Utils.RandomHelper
{
    /// <summary>
    /// Helper class for generating random values
    /// </summary>
    public static class RandomHelper
    {
        private static Random r = new Random();

        /// <summary>
        /// Generates a random string with the given length
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="lowerCase">If true, generate lowercase string</param>
        /// <returns>Random string</returns>
        public static string RandomString(int size, bool lowerCase)
        {
            // StringBuilder is faster than using strings (+=)
            StringBuilder RandStr = new StringBuilder(size);

            // Ascii start position (65 = A / 97 = a)
            int Start = (lowerCase) ? 97 : 65;

            // Add random chars
            for (int i = 0; i < size; i++)
                RandStr.Append((char)(26 * r.NextDouble() + Start));

            return RandStr.ToString();
        }

        /// <summary>
        /// Generates a random Integer.
        /// </summary>
        /// <param name="min">Minimal result</param>
        /// <param name="max">Maximal result</param>
        /// <returns>Random number</returns>
        public static int RandomInt(int min, int max)
        {
            r.Next(min, max);
            return r.Next(min, max);
        }

        /// <summary>
        /// Generates a random boolean value
        /// </summary>
        /// <returns>Random boolean value</returns>
        public static bool RandomBool()
        {
            return (r.NextDouble() > 0.5);
        }

        /// <summary>
        /// Generates a random float value
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>A float value</returns>
        public static float RandomFloat(float min, float max)
        {
            return (float)r.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Generates a random byte between min and max
        /// </summary>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <returns>Byte</returns>
        public static byte RandomByte(byte min, byte max)
        {
            return (byte)(r.Next(min, max));
        }

        /// <summary>
        /// Generates a random Vector2
        /// </summary>
        /// <param name="min">Minimum for each component</param>
        /// <param name="max">Maximum for each component</param>
        /// <returns>Vector2</returns>
        public static Vector2 RandomVector2(float min, float max)
        {
            return new Vector2(
                RandomFloat(min, max),
                RandomFloat(min, max));
        }

        /// <summary>
        /// Generates a random Vector3
        /// </summary>
        /// <param name="min">Minimum for each component</param>
        /// <param name="max">Maximum for each component</param>
        /// <returns>Vector3</returns>
        public static Vector3 RandomVector3(float min, float max)
        {
            return new Vector3(
                RandomFloat(min, max),
                RandomFloat(min, max),
                RandomFloat(min, max));
        }

        /// <summary>
        /// Generates a random color
        /// </summary>
        /// <returns>Color</returns>
        public static Color RandomColor()
        {
            return new Color(new Vector3(
                RandomFloat(0.25f, 1.0f),
                RandomFloat(0.25f, 1.0f),
                RandomFloat(0.25f, 1.0f)));
        }
    }
}
