using System.Linq;
using UnityEngine.SceneManagement;

namespace Codes.Util.FluentExt.Unity
{
    public static class UnitySceneManagerExtensions
    {
        /// <summary>
        /// Finds game objects in active scene with <typeparamref name="T"/> component.
        /// </summary>
        /// <typeparam name="T">Component type.</typeparam>
        /// <returns>Found game objects.</returns>
        public static T[] FindObjectsOfTypeInActiveScene<T>() => SceneManager.GetActiveScene().FindObjectsOfType<T>();

        /// <summary>
        /// Finds game objects in open scenes with <typeparamref name="T"/> component.
        /// </summary>
        /// <typeparam name="T">Component type.</typeparam>
        /// <returns>Found game objects.</returns>
        public static T[] FindObjectsOfTypeInOpenScenes<T>() => Enumerable.Range(0, SceneManager.sceneCount).Select(index => SceneManager.GetSceneAt(index)).SelectMany(scene => scene.FindObjectsOfType<T>()).ToArray();
        
        /// <summary>
        /// Finds game objects in scene with <typeparamref name="T"/> component.
        /// </summary>
        /// <typeparam name="T">Component type.</typeparam>
        /// <param name="scene">Target scene.</param>
        /// <returns>Found game objects.</returns>
        public static T[] FindObjectsOfType<T>(this Scene scene) => scene.GetRootGameObjects().SelectMany(go => go.GetComponentsInChildren<T>(true)).ToArray();
        
    }
}