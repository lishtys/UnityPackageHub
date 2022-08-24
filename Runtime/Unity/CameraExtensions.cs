using UnityEngine;

namespace Codes.Util.FluentExt.Unity
{
    public static class CameraExtensions
    {
        /// <summary>
        ///  auto position in correct distance making a sprite fit the screen
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="sprite"></param>
        /// <returns></returns>
        public static float GetFullscreenSpriteCameraDistance(this Camera camera, Sprite sprite)
        {
            var frustumHeight = sprite.bounds.size.y;
            var distance = frustumHeight / (2.0f * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
            return  distance;
        }
        /// <summary>
        ///  check if a bound is in frustum
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static bool IsInFrustum(this Camera camera,Bounds bounds)
        {
            var planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, bounds);
        }
        
        /// <summary>
        ///  capture screen 
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static Texture2D CaptureCamera(this Camera camera, Rect rect)
        {
            var renderTexture = new RenderTexture(Screen.width, Screen.height, 0);
            camera.targetTexture = renderTexture;
            camera.Render();

            RenderTexture.active = renderTexture;

            var screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();

            camera.targetTexture = null;
            RenderTexture.active = null;
            UnityEngine.Object.Destroy(renderTexture);

            return screenShot;
        }
    }
}