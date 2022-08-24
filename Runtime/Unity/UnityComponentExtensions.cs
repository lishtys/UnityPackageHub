using UnityEngine;

namespace Codes.Util.FluentExt
{
    /// <summary>
    /// Extension methods for UnityEngine.Component.
    /// </summary>
    public static class UnityComponentExtensions
    {
        /// <summary>
        /// Attaches a component to the given component's game object.
        /// </summary>
        /// <param name="component">Component.</param>
        /// <returns>Newly attached component.</returns>
        public static T AddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Gets a component attached to the given component's game object.
        /// If one isn't found, a new one is attached and returned.
        /// </summary>
        /// <param name="component">Component.</param>
        /// <returns>Previously or newly attached component.</returns>
        public static T GetOrAddComponent<T>(this Component uo) where T : Component
        {
            return uo.GetComponent<T>() ?? uo.AddComponent<T>();
        }

        /// <summary>
        /// Checks whether a component's game object has a component of type T attached.
        /// </summary>
        /// <param name="component">Component.</param>
        /// <returns>True when component is attached.</returns>
        public static bool HasComponent<T>(this Component component) where T : Component
        {
            return component.GetComponent<T>() != null;
        } 
        
        /// <summary>
        ///  set active to true of a gameobject
        /// </summary>
        /// <param name="component"></param>
        public static void Show(this Component component)
        {
            component.gameObject.SetActive(true);
        } 
        /// <summary>
        ///  set active to false of a gameobject
        /// </summary>
        /// <param name="component"></param>
        public static void Hide(this Component component)
        {
            component.gameObject.SetActive(false);
        }

        #region destroy

        /// <summary>
        ///  destroy game object
        /// </summary>
        /// <param name="selfBehaviour"></param>
        /// <typeparam name="T"></typeparam>
        public static void DestroyGameObj<T>(this T selfBehaviour) where T : Component
        {
            selfBehaviour.gameObject.DestroySelf();
        }

        public static T DestroySelfGracefully<T>(this T selfObj) where T : UnityEngine.Object
        {
            if (selfObj)
            {
                UnityEngine.Object.Destroy(selfObj);
            }

            return selfObj;
        }
        
        public static T DestroySelfAfterDelay<T>(this T selfObj, float afterDelay) where T : UnityEngine.Object
        {
            UnityEngine.Object.Destroy(selfObj, afterDelay);
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
