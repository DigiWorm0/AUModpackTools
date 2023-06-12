using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AUModpackTools.Utils
{
    /// <summary>
    /// Generates sprites from raw image data
    /// </summary>
    public static class SpriteLoader
    {
        /// <summary>
        /// Loads a sprite from a byte array
        /// </summary>
        /// <param name="spriteData">Raw image data in the form of a byte array</param>
        /// <returns>A UnityEngine Sprite</returns>
        public static Sprite LoadSprite(byte[] spriteData)
        {
            // Texture
            Texture2D texture = new(1, 1, TextureFormat.RGBA32, false)
            {
                wrapMode = TextureWrapMode.Clamp,
                filterMode = FilterMode.Bilinear,
                hideFlags = HideFlags.HideAndDontSave,
                requestedMipmapLevel = 0
            };
            ImageConversion.LoadImage(texture, spriteData);

            // Sprite
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f),
                100f,
                0,
                SpriteMeshType.FullRect
            );
        }

        /// <summary>
        /// Loads a sprite from local resources
        /// </summary>
        /// <param name="resourceName">The name of the resource to load</param>
        /// <returns>A UnityEngine Sprite</returns>
        public static Sprite LoadSpriteFromResources(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream? resourceStream = assembly.GetManifestResourceStream($"AUModpackTools.Assets.{resourceName}");
            if (resourceStream == null)
                throw new FileNotFoundException($"Failed to find resource {resourceName}");

            byte[] resourceData = new byte[resourceStream.Length];
            resourceStream.Read(resourceData);
            return LoadSprite(resourceData);
        }

        /// <summary>
        /// Loads a sprite from a file
        /// </summary>
        /// <param name="fileName">Name of the file to load</param>
        /// <returns>A UnityEngine Sprite</returns>
        public static Sprite LoadSpriteFromFile(string fileName)
        {
            byte[] bytes = FileReader.ReadFileBytes(fileName);
            return LoadSprite(bytes);
        }
    }
}
