using UnityEngine;

namespace Codes.Util.Extensions
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Sets value to vector's axis.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <param name="axis">Axis index of the vector.</param>
        /// <param name="value">Value to set.</param>
        /// <returns>Changed copy of the vector.</returns>
        public static Vector2 With(this Vector2 vector, int axis, float value)
        {
            vector[axis] = value;
            return vector;
        }
        /// <summary>
        /// Sets value to vector's x axis.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <param name="x">Value to set.</param>
        /// <returns>Changed copy of the vector.</returns>
        public static Vector2 WithX(this Vector2 vector, float x) => With(vector, 0, x);
        
        /// <summary>
        /// Sets value to vector's y axis.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <param name="y">Value to set.</param>
        /// <returns>Changed copy of the vector.</returns>
        public static Vector2 WithY(this Vector2 vector, float y) => With(vector, 1, y);
        
        /// <summary>
        /// Gets inverted vector.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <returns>Inverted vector.</returns>
        public static Vector2 WithYX(this Vector2 vector) => new Vector2(vector.y, vector.x);
       
        /// <summary>
        /// Inserts value to x axis and extends vector to 3-dimensional.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <param name="x">Value to set.</param>
        /// <returns>3-dimensional vector.</returns>
        public static Vector3 InsertX(this Vector2 vector, float x = 0) => new Vector3(x, vector.x, vector.y);

        /// <summary>
        /// Inserts value to y axis and extends vector to 3-dimensional.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <param name="y">Value to set.</param>
        /// <returns>3-dimensional vector.</returns>
        public static Vector3 InsertY(this Vector2 vector, float y = 0) => new Vector3(vector.x, y, vector.y);
        
        /// <summary>
        /// Inserts value to z axis and extends vector to 3-dimensional.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <param name="z">Value to set.</param>
        /// <returns>3-dimensional vector.</returns>
        public static Vector3 InsertZ(this Vector2 vector, float z = 0) => new Vector3(vector.x, vector.y, z);
        
        /// <summary>
        /// Gets max component from vector.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <returns>Vector's max component</returns>
        public static float MaxComponent(this Vector2 vector) => Mathf.Max(vector.x, vector.y);

        /// <summary>
        /// Gets min component from vector.
        /// </summary>
        /// <param name="vector">Target vector.</param>
        /// <returns>Vector's min component</returns>
        public static float MinComponent(this Vector2 vector) => Mathf.Min(vector.x, vector.y);
        
        /// <summary>
        /// Add in Y-Axis
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector2 AddY(this Vector2 v, float y)
        {
            return new Vector2(v.x, v.y + y);
        }

        /// <summary>
        /// Add in Y-Axis
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 AddX(this Vector2 v, float x)
        {
            return new Vector2(v.x + x, v.y);
        }
        
        /// <summary>
        ///  Get Absolute Value
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector2 Abs(this Vector2 a)
        {
            return new Vector2(Mathf.Abs(a.x), Mathf.Abs(a.y));
        }

        /// <summary>
        ///  Get Inversed value
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector2 Inverse(this Vector2 a)
        {
            return new Vector2(1 / a.x, 1 / a.y);
        }
    }
}