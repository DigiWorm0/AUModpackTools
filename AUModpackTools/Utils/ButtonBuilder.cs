using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AUModpackTools.Utils
{
    /// <summary>
    /// Builds buttons
    /// </summary>
    public class ButtonBuilder
    {
        /// <summary>
        /// Builds a button from the main menu prefab
        /// </summary>
        /// <param name="pos">Position to move button to</param>
        /// <param name="btnSprite">Sprite to set button</param>
        /// <param name="hoverColor">Color to make button on hover</param>
        /// <param name="onClick">Action to perform on click</param>
        /// <returns>The button GameObject</returns>
        public static GameObject BuildMainMenuButton(Vector3 pos, Sprite btnSprite, Color hoverColor, Action onClick)
        {
            // Prefab
            GameObject buttonPrefab = GameObject.Find("ExitGameButton");
            GameObject btnObj = UnityEngine.Object.Instantiate(buttonPrefab);
            btnObj.name = "button_LevelImposterUpdater";
            btnObj.transform.localPosition = pos;

            // Sprite
            float btnAspect = btnSprite.rect.height / btnSprite.rect.width;
            SpriteRenderer btnRenderer = btnObj.GetComponent<SpriteRenderer>();
            btnRenderer.sprite = btnSprite;
            btnRenderer.size = new Vector2(
                1.3f,
                1.3f * btnAspect
            );

            // Text
            Transform textTransform = btnObj.transform.GetChild(0);
            UnityEngine.Object.Destroy(textTransform.gameObject);

            // Remove Aspect
            AspectPosition aspectComponent = btnObj.GetComponent<AspectPosition>();
            UnityEngine.Object.Destroy(aspectComponent);

            // Button
            PassiveButton btnComponent = btnObj.GetComponent<PassiveButton>();
            btnComponent.OnClick = new();
            btnComponent.OnClick.AddListener(onClick);

            // Button Hover
            ButtonRolloverHandler btnRollover = btnObj.GetComponent<ButtonRolloverHandler>();
            btnRollover.OverColor = hoverColor;

            // Box Collider
            BoxCollider2D btnCollider = btnObj.GetComponent<BoxCollider2D>();
            btnCollider.size = btnRenderer.size;

            return btnObj;
        }
    }
}
