using UnityEngine;

namespace Codes.Util.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.LayerMask.
    /// </summary>
    public static class LayerMaskExtensions
    {
        /// <summary>
        ///  check a [layer] is in a layer mask
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool IsLayerInLayerMask(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
    }
}