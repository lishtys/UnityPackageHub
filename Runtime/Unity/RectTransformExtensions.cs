using UnityEngine;

namespace Codes.Util.Extensions
{
    public static class RectTransformExtensions
    {
        public static Vector2 SetSizeDeltaX(this RectTransform rt, float x) { var sd = rt.sizeDelta; sd.x = x; return rt.sizeDelta = sd; }
        public static Vector2 SetSizeDeltaY(this RectTransform rt, float y) { var sd = rt.sizeDelta; sd.y = y; return rt.sizeDelta = sd; }
        public static Vector2 SetAnchoredPosX(this RectTransform rt, float x) { var ap = rt.anchoredPosition; ap.x = x; return rt.anchoredPosition = ap; }
        public static Vector2 SetAnchoredPosY(this RectTransform rt, float y) { var ap = rt.anchoredPosition; ap.y = y; return rt.anchoredPosition = ap; }
        public static Vector3 SetAnchoredPos3dX(this RectTransform rt, float x) { var ap = rt.anchoredPosition3D; ap.x = x; return rt.anchoredPosition3D = ap; }
        public static Vector3 SetAnchoredPos3dY(this RectTransform rt, float y) { var ap = rt.anchoredPosition3D; ap.y = y; return rt.anchoredPosition3D = ap; }
        public static Vector3 SetAnchoredPos3dZ(this RectTransform rt, float z) { var ap = rt.anchoredPosition3D; ap.z = z; return rt.anchoredPosition3D = ap; }
    }
}