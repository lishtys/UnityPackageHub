using UnityEngine;

namespace Codes.Util.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Rigidbody.
    /// </summary>
    public static class RigidbodyExtensions
    {
        /// <summary>
        /// Changes the direction of a rigidbody without changing its speed.
        /// </summary>
        /// <param name="rigidbody">Rigidbody.</param>
        /// <param name="direction">New direction.</param>
        public static void ChangeDirection(this Rigidbody rigidbody, Vector3 direction)
        {
            rigidbody.velocity = direction * rigidbody.velocity.magnitude;
        }

        #region velocity

        public static Vector3 SetVelX(this Rigidbody self, float x)
        {
            Vector3 pos = self.velocity;
            pos.x = x;
            self.velocity = pos;
            return pos;
        }

        public static Vector3 SetVelY(this Rigidbody self, float y)
        {
            Vector3 pos = self.velocity;
            pos.y = y;
            self.velocity = pos;
            return pos;
        }

        public static Vector3 SetVelZ(this Rigidbody self, float z)
        {
            Vector3 pos = self.velocity;
            pos.z = z;
            self.velocity = pos;
            return pos;
        }

        public static Vector3 SetVelXY(this Rigidbody self, float x, float y)
        {
            Vector3 pos = self.velocity;
            pos.x = x;
            pos.y = y;
            self.velocity = pos;
            return pos;
        }

        public static Vector3 SetVelXYZ(this Rigidbody self, float x, float y, float z)
        {
            Vector3 pos = self.velocity;
            pos.x = x;
            pos.y = y;
            pos.z = z;
            self.velocity = pos;
            return pos;
        }

        #endregion


        #region calculation
        public static void NormalizeVelocity(this Rigidbody rb, float magnitude = 1)
        {
            rb.velocity = rb.velocity.normalized * magnitude;
        }
        #endregion
        
    }
}
