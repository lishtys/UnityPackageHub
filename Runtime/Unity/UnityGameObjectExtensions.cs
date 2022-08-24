using UnityEngine;

namespace Codes.Util.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.GameObject.
    /// </summary>
    public static class UnityGameObjectExtensions
    {
        /// <summary>
        /// Gets a component attached to the given game object.
        /// If one isn't found, a new one is attached and returned.
        /// </summary>
        /// <param name="gameObject">Game object.</param>
        /// <returns>Previously or newly attached component.</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            return component == null ? gameObject.AddComponent<T>() : component;
        }

        /// <summary>
        /// Checks whether a game object has a component of type T attached.
        /// </summary>
        /// <param name="gameObject">Game object.</param>
        /// <returns>True when component is attached.</returns>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() != null;
        }

        #region transform getter
        public static Vector3 Position(this GameObject go) { return go.transform.position; }
        public static Vector3 Position(this GameObject go, Vector3 newPosition) { return go.transform.position = newPosition; }
        public static Vector3 LocalPosition(this GameObject go) { return go.transform.localPosition; }
        public static Vector3 LocalPosition(this GameObject go, Vector3 newPosition) { return go.transform.localPosition = newPosition; }
        public static Quaternion Rotation(this GameObject go) { return go.transform.rotation; }
        public static Quaternion Rotation(this GameObject go, Quaternion newRotation) { return go.transform.rotation = newRotation; }
        public static Quaternion LocalRotation(this GameObject go) { return go.transform.localRotation; }
        public static Quaternion LocalRotation(this GameObject go, Quaternion newRotation) { return go.transform.localRotation = newRotation; }
        public static Vector3 EulerAngles(this GameObject go) { return go.transform.eulerAngles; }
        public static Vector3 EulerAngles(this GameObject go, Vector3 newAngles) { return go.transform.eulerAngles = newAngles; }
        public static Vector3 LocalEulerAngles(this GameObject go) { return go.transform.localEulerAngles; }
        public static Vector3 LocalEulerAngles(this GameObject go, Vector3 newAngles) { return go.transform.localEulerAngles = newAngles; }
        public static Vector3 LocalScale(this GameObject go) { return go.transform.localScale; }
        public static Vector3 LocalScale(this GameObject go, Vector3 newScale) { return go.transform.localScale = newScale; }

        #endregion

        #region Show & Hide

        public static GameObject Show(this GameObject gameObject)
        {
            gameObject.SetActive(true);
            return gameObject;
        }
        
        public static GameObject Hide(this GameObject gameObject)
        {
            gameObject.SetActive(false);
            return gameObject;
        }

        #endregion

        #region children & parent

        /// <summary>
        /// Finds all components of type <typeparamref name="T"/> on this <paramref name="gameObject"/> and all its children and sets their enabled state.
        /// </summary>
        /// <typeparam name="T">Components type.</typeparam>
        /// <param name="gameObject">Target object.</param>
        /// <param name="enabled">Enabled state to set.</param>
        public static void SetComponentsEnabledInChildren<T>(this GameObject gameObject, bool enabled) where T : MonoBehaviour
        {
            var components = gameObject.GetComponentsInChildren<T>();

            foreach (var component in components)
                component.enabled = enabled;
        }

        /// <summary>
        /// Finds all components of type <typeparamref name="T"/> on this <paramref name="gameObject"/> and all its parents and sets their enabled state.
        /// </summary>
        /// <typeparam name="T">Components type.</typeparam>
        /// <param name="gameObject">Target object.</param>
        /// <param name="enabled">Enabled state to set.</param>
        public static void SetComponentsEnabledInParents<T>(this GameObject gameObject, bool enabled) where T : MonoBehaviour
        {
            var components = gameObject.GetComponentsInParent<T>();
            
            foreach (var component in components)
                component.enabled = enabled;
        }

        #endregion
     
    }
}
