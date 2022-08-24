using System;
using UnityEngine;

namespace Codes.Util.Extensions
{
    public static class TextureExtensions
    {
                /// <summary>
        /// Clone the specified texture.
        /// </summary>
        /// <returns>The clone.</returns>
        /// <param name="texture">Texture.</param>
        public static Texture2D Clone(this Texture2D texture)
        {
            return texture.Mirror(false, false);
        }

        /// <summary>
        /// Combines the textures.
        /// </summary>
        /// <returns>The textures.</returns>
        /// <param name="texture">Texture.</param>
        /// <param name="layers">Layers.</param>
        public static Texture2D CombineTextures(this Texture2D texture, Texture2D[] layers)
        {
            Texture2D compiledTexture = new Texture2D(texture.width, texture.height);

            foreach (Texture2D layer in layers)
            {
                Color[] baseColors = compiledTexture.GetPixels();
                Color[] layerColors = layer.GetPixels();

                for (int p = 0; p < baseColors.Length; p++)
                {
                    Color resultColor = baseColors[p];

                    resultColor.r = baseColors[p].r * (1.0f - layerColors[p].a) + layerColors[p].r * layerColors[p].a;
                    resultColor.g = baseColors[p].g * (1.0f - layerColors[p].a) + layerColors[p].g * layerColors[p].a;
                    resultColor.b = baseColors[p].b * (1.0f - layerColors[p].a) + layerColors[p].b * layerColors[p].a;

                    baseColors[p] = resultColor;

                }

                compiledTexture.SetPixels(baseColors);
                compiledTexture.Apply();
            }

            return compiledTexture;
        }

        /// <summary>
        /// Create a new sprite out of the Texture.
        /// </summary>
        /// <returns>The sprite.</returns>
        /// <param name="texture">Texture.</param>
        public static Sprite CreateSprite(this Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }

        /// <summary>
        /// Create a new sprite out of the Texture.
        /// </summary>
        /// <returns>The sprite.</returns>
        /// <param name="texture">Texture.</param>
        /// <param name="pivot">Pivot.</param>
        public static Sprite CreateSprite(this Texture2D texture, Vector2 pivot)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot);
        }

        /// <summary>
        /// Create a new sprite out of the Texture and centers it accordingly.
        /// </summary>
        /// <returns>The sprite pivotted at the center.</returns>
        /// <param name="texture">Texture.</param>
        public static Sprite CreateSpriteAndCenter(this Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
        }

        /// <summary>
        /// Creates the texture.
        /// </summary>
        /// <returns>The texture.</returns>
        /// <param name="base64String">Base64 string.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        private static Texture2D CreateTexture(string base64String, int width, int height)
        {
            // Loading texture from byte array
            byte[] bytes = Convert.FromBase64String(base64String);
            Texture2D newTexture = new Texture2D(width, height);
            newTexture.LoadImage(bytes);

            return newTexture;
        }

        /// <summary>
        /// Creates the texture.
        /// </summary>
        /// <returns>The texture.</returns>
        /// <param name="bytes">Base64 string.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        private static Texture2D CreateTexture(byte[] bytes, int width, int height)
        {
            Texture2D newTexture = new Texture2D(width, height);
            newTexture.LoadImage(bytes);

            return newTexture;
        }
        /// <summary>
        /// Deserialise the specified textureString.
        /// </summary>
        /// <returns>The deserialise.</returns>
        /// <param name="textureString">Texture string.</param>
        public static Texture2D Deserialise(this string textureString)
        {
            //Debug.LogFormat("Deserialise({0})", textureString);
            //IDictionary decodedTexture = JsonUtility.FromJson<Dictionary<string, object>>(textureString);
            Texture2DInfo decodedTexture = JsonUtility.FromJson<Texture2DInfo>(textureString);
            if (decodedTexture != null)
            {
                //int width = (int)decodedTexture[TEX_WIDTH];
                //int height = (int)decodedTexture[TEX_HEIGHT];
                //string base64String = decodedTexture[TEX_DATA] as string;

                // Extracting properties from padded fields
                int width = decodedTexture.width;//(int)decodedTexture[TEX_WIDTH];
                int height = decodedTexture.height;//(int)decodedTexture[TEX_HEIGHT];
                byte[] data = decodedTexture.data;

                return CreateTexture(data, width, height);
            }

            return null;
        }

        /// <summary>
        /// Gets the average color.
        /// </summary>
        /// <returns>The average color.</returns>
        /// <param name="texture">Texture.</param>
        public static Color GetAverageColor(this Texture2D texture)
        {
            var pixels = texture.GetPixels();
            Vector3 avg = Vector3.zero;
            for (int i = 0; i < pixels.Length; i++)
                avg += new Vector3(
                    pixels[i].r,
                    pixels[i].g,
                    pixels[i].b
                );
            avg /= pixels.Length;
            return new Color(avg.x, avg.y, avg.z, 1);
        }

        /// <summary>
        /// Returns the full Rect of this texture, with options for position and scale
        /// </summary>
        public static Rect GetRect(this Texture2D texture, float x = 0, float y = 0, float scale = 1)
        {
            return new Rect(x, y, texture.width * scale, texture.height * scale);
        }

        /// <summary>
        /// Gets the pixel.
        /// </summary>
        /// <returns>The pixel.</returns>
        /// <param name="texture">Texture.</param>
        /// <param name="pixels">Pixels.</param>
        /// <param name="coordinate">Coordinate.</param>
        public static Color GetPixel(this Texture2D texture, Color32[] pixels, Vector2 coordinate)
        {
            int xCord = (int)coordinate.x;
            int yCord = (int)coordinate.y;

            if (xCord >= texture.width || xCord < 0)
                return Color.clear;

            if (yCord >= texture.height || yCord < 0)
                return Color.clear;

            return pixels[(yCord * texture.width) + xCord];
        }

        /// <summary>
        /// Gets the texture data.
        /// </summary>
        /// <returns>The texture data.</returns>
        /// <param name="texture">Texture.</param>
        /// <param name="encodeFormat">Encode format.</param>
        public static byte[] GetTextureData(this Texture2D texture, TextureEncoding encodeFormat)
        {
            switch (encodeFormat)
            { 
                case TextureEncoding.EXR: return texture.EncodeToEXR();
                case TextureEncoding.JPG: return texture.EncodeToJPG();
                case TextureEncoding.PNG: return texture.EncodeToPNG();
                default: return texture.GetRawTextureData();   
            }
        }

        /// <summary>
        /// Loads from local.
        /// </summary>
        /// <returns><c>true</c>, if from local was loaded, <c>false</c> otherwise.</returns>
        /// <param name="localPath">Local path.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <param name="callback">Callback.</param>
        private static bool LoadFromLocal(string localPath, int width, int height, Action<Texture2D> callback)
        {
            #if !UNITY_WSA && !UNITY_WP8 && !UNITY_WEBPLAYER
            if (System.IO.File.Exists(localPath))
            {
                var bytes = System.IO.File.ReadAllBytes(localPath);
                var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
                tex.LoadImage(bytes);
                if (tex != null)
                {
                    callback(tex);
                    return true;
                }
            }
            return false;
            #else
            return false;
            #endif
        }

        /// <summary>
        /// Mirror the specified texture, mirrorHorizontally and mirrorVertically.
        /// </summary>
        /// <returns>The mirror.</returns>
        /// <param name="texture">Texture.</param>
        /// <param name="mirrorHorizontally">If set to <c>true</c> mirror horizontally.</param>
        /// <param name="mirrorVertically">If set to <c>true</c> mirror vertically.</param>
        public static Texture2D Mirror(this Texture2D texture, bool mirrorHorizontally, bool mirrorVertically)
        {
            Debug.LogFormat("Mirror({0}, {1}, {2})", texture, mirrorHorizontally, mirrorVertically);

            int textureWidth = texture.width;
            int textureWidthMinus1 = textureWidth - 1;
            int textureHeight = texture.height;
            int textureHeightMinus1 = textureHeight - 1;

            // Pixels
            Color32[] texurePixels = texture.GetPixels32(0);
            Color32[] mirrorTexturePixels = new Color32[texurePixels.Length];

            for (int yCord = 0; yCord < textureHeight; yCord++)
            {
                int sourceIndex = yCord * textureWidth;
                int destYCord = mirrorVertically ? (textureHeightMinus1 - yCord) : yCord;
                int destIndex = destYCord * textureWidth;

                for (int xCord = 0; xCord < textureWidth; xCord++)
                {
                    int destXCord = mirrorHorizontally ? (textureWidthMinus1 - xCord) : xCord;

                    mirrorTexturePixels[destIndex + destXCord] = texurePixels[sourceIndex++];
                }
            }

            // Create mirrored texture
            Texture2D mirrorTexture = new Texture2D(textureWidth, textureHeight, texture.format, false);
            mirrorTexture.SetPixels32(mirrorTexturePixels, 0);
            mirrorTexture.Apply();

            return mirrorTexture;
        }

        /// <summary>
        /// Change texture size (and scale accordingly)
        /// </summary>
        public static Texture2D Resample(this Texture2D texture, int targetWidth, int targetHeight)
        {
            int sourceWidth = texture.width;
            int sourceHeight = texture.height;
            float sourceAspect = (float)sourceWidth / sourceHeight;
            float targetAspect = (float)targetWidth / targetHeight;

            int xOffset = 0;
            int yOffset = 0;
            float factor;

            if (sourceAspect > targetAspect)
            {
                // crop width
                factor = (float)targetHeight / sourceHeight;
                xOffset = (int)((sourceWidth - sourceHeight * targetAspect) * 0.5f);
            }
            else
            {
                // crop height
                factor = (float)targetWidth / sourceWidth;
                yOffset = (int)((sourceHeight - sourceWidth / targetAspect) * 0.5f);
            }

            var data = texture.GetPixels32();
            var data2 = new Color32[targetWidth * targetHeight];
            for (int y = 0; y < targetHeight; y++)
            {
                for (int x = 0; x < targetWidth; x++)
                {
                    var p = new Vector2(Mathf.Clamp(xOffset + x / factor, 0, sourceWidth - 1), Mathf.Clamp(yOffset + y / factor, 0, sourceHeight - 1));
                    // bilinear filtering
                    var c11 = data[Mathf.FloorToInt(p.x) + sourceWidth * (Mathf.FloorToInt(p.y))];
                    var c12 = data[Mathf.FloorToInt(p.x) + sourceWidth * (Mathf.CeilToInt(p.y))];
                    var c21 = data[Mathf.CeilToInt(p.x) + sourceWidth * (Mathf.FloorToInt(p.y))];
                    var c22 = data[Mathf.CeilToInt(p.x) + sourceWidth * (Mathf.CeilToInt(p.y))];

                    data2[x + y * targetWidth] = Color.Lerp(Color.Lerp(c11, c12, p.y), Color.Lerp(c21, c22, p.y), p.x);
                }
            }

            var tex = new Texture2D(targetWidth, targetHeight);
            tex.SetPixels32(data2);
            tex.Apply(true);
            return tex;
        }

    

        const string TEX_WIDTH = "textureWidth";
        const string TEX_HEIGHT = "textureHeight";
        const string TEX_DATA = "textureData";
        /// <summary>
        /// Serialise the specified texture and encodeFormat.
        /// </summary>
        /// <returns>The serialise.</returns>
        /// <param name="texture">Texture.</param>
        /// <param name="encodeFormat">Encode format in base 64.</param>
        public static string Serialise(this Texture2D texture, TextureEncoding encodeFormat = TextureEncoding.PNG)
        {
            Texture2DInfo texture2DInfo = new Texture2DInfo()
            {
                width = texture.width,
                height = texture.height,
                data = texture.GetTextureData(encodeFormat)
            };

            // Need to append width and height information
            //IDictionary dictionary = new Dictionary<string, object>();
            //dictionary[TEX_WIDTH] = texture.width;
            //dictionary[TEX_HEIGHT] = texture.height;
            //dictionary[TEX_DATA] = texture.GetTextureData(encodeFormat);

            // Json format string
            string json = JsonUtility.ToJson(texture2DInfo);
            //Debug.LogFormat("Serialise({0})", json);
            return json;
        }

        /// <summary>
        /// Tint texture with solid color
        /// </summary>
        public static Texture2D Tint(this Texture2D texture, Color color)
        {
            var target = new Texture2D(texture.width, texture.height);
            for (int i = 0; i < target.width; i++)
            {
                for (int j = 0; j < target.height; j++)
                {
                    target.SetPixel(i, j, color);
                }
            }

            target.Apply();

            return target;
        }

        /// <summary>
        /// Tos the bytes.
        /// </summary>
        /// <returns>The bytes.</returns>
        /// <param name="texture">Texture.</param>
        /// <param name="encodeFormat">Encode format.</param>
        public static byte[] ToBytes(this Texture2D texture, TextureEncoding encodeFormat = TextureEncoding.PNG)
        {
            return texture.GetTextureData(encodeFormat);
        }

        /// <summary>
        /// To the greyscale.
        /// </summary>
        /// <returns>The greyscale.</returns>
        /// <param name="texture">Texture.</param>
        public static Texture2D ToGreyscale(this Texture2D texture)
        {
            Texture2D greyscaleTexture = texture.Clone();
            Color32[] pixels = greyscaleTexture.GetPixels32();
            for (int x = 0; x < greyscaleTexture.width; x++)
            {
                for (int y = 0; y < greyscaleTexture.height; y++)
                {
                    Color32 pixel = pixels[x + y * greyscaleTexture.width];
                    int p = ((256 * 256 + pixel.r) * 256 + pixel.b) * 256 + pixel.g;
                    int b = p % 256;
                    p = Mathf.FloorToInt(p / 256);
                    int g = p % 256;
                    p = Mathf.FloorToInt(p / 256);
                    int r = p % 256;
                    float l = (0.2126f * r / 255f) + 0.7152f * (g / 255f) + 0.0722f * (b / 255f);
                    Color c = new Color(l, l, l, 1);
                    greyscaleTexture.SetPixel(x, y, c);
                }
            }

            greyscaleTexture.Apply(false);
            return greyscaleTexture;
        }

        /// <summary>
        /// Tos the string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="texture">Texture.</param>
        /// <param name="encodeFormat">Encode format.</param>
        public static string ToString(this Texture2D texture, TextureEncoding encodeFormat = TextureEncoding.PNG)
        {
            // Converting texture data to string
            byte[] bytes = (encodeFormat == TextureEncoding.JPG) ? texture.EncodeToJPG() : texture.EncodeToPNG();
            string base64String = System.Convert.ToBase64String(bytes);

            return base64String;
        }
    }

    [System.Serializable]
    class Texture2DInfo
    {
        public int width;
        public int height;
        public byte[] data;
    }

    public enum TextureEncoding
    {
        None,
        EXR,
        JPG,
        PNG
    }
}