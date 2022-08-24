using UnityEngine;

namespace Codes.Util.FluentExt
{
    public static class UnityEngineObjectExtensions
    {
        #region Instantiate 

        public static T Instantiate<T>(this T selfObj) where T : Object
        {
            return Object.Instantiate(selfObj);
        }
        
        public static T Instantiate<T>(this T selfObj, Vector3 position, Quaternion rotation)
            where T : Object
        {
            return Object.Instantiate(selfObj, position, rotation);
        }
        
        public static T Instantiate<T>(this T selfObj, Vector3 position, Quaternion rotation, Transform parent)
            where T : Object
        {
            return Object.Instantiate(selfObj, position, rotation, parent);
        }
        
        public static T InstantiateWithParent<T>(this T selfObj, Transform parent, bool worldPositionStays)
            where T : Object
        {
            return (T)Object.Instantiate((Object)selfObj, parent, worldPositionStays);
        }

        public static T InstantiateWithParent<T>(this T selfObj, Transform parent) where T : Object
        {
            return Object.Instantiate(selfObj, parent, false);
        }

        #endregion

        #region properties

        public static T Name<T>(this T selfObj, string name) where T : Object
        {
            selfObj.name = name;
            return selfObj;
        }

        #endregion


        #region Destroy 

        public static void DestroySelf<T>(this T selfObj) where T : UnityEngine.Object
        {
            UnityEngine.Object.Destroy(selfObj);
        }
        
        public static T DestroySelfAfterDelay<T>(this T selfObj, float afterDelay) where T : Object
        {
            Object.Destroy(selfObj, afterDelay);
            return selfObj;
        }
        
        public static T DestroySelfAfterDelayGracefully<T>(this T selfObj, float delay) where T : UnityEngine.Object
        {
            if (selfObj)
            {
                UnityEngine.Object.Destroy(selfObj, delay);
            }

            return selfObj;
        }

        #endregion
        
    }
}
