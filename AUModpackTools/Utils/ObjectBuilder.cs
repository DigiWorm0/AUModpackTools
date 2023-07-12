using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Twitch;
using UnityEngine;
using static CreditsScreenPopUp;

namespace AUModpackTools.Utils
{
    /// <summary>
    /// Builds buttons
    /// </summary>
    public class ObjectBuilder
    {
        /// <summary>
        /// Builds a button from the main menu
        /// </summary>
        /// <param name="pos">Position to move button to</param>
        /// <param name="btnSprite">Sprite to set button</param>
        /// <param name="hoverColor">Color to make button on hover</param>
        /// <param name="onClick">Action to perform on click</param>
        /// <returns>The button GameObject</returns>
        public static GameObject BuildButton(Vector3 pos, Sprite btnSprite, Color hoverColor, Action onClick)
        {
            // Prefab
            GameObject buttonPrefab = GameObject.Find("ExitGameButton");
            GameObject btnObj = UnityEngine.Object.Instantiate(buttonPrefab);
            btnObj.name = "button_LevelImposterUpdater";
            btnObj.transform.localPosition = pos;

            // Active/Inactive
            GameObject active = btnObj.transform.Find("Highlight").gameObject;
            GameObject inactive = btnObj.transform.Find("Inactive").gameObject;

            // Sprite
            float btnAspect = btnSprite.rect.height / btnSprite.rect.width;

            // Active
            SpriteRenderer btnRendererActive = active.GetComponent<SpriteRenderer>();
            btnRendererActive.sprite = btnSprite;
            btnRendererActive.size = new Vector2(
                1.3f,
                1.3f * btnAspect
            );
            btnRendererActive.color = hoverColor;

            // Inactive
            SpriteRenderer btnRendererInactive = inactive.GetComponent<SpriteRenderer>();
            btnRendererInactive.sprite = btnSprite;
            btnRendererInactive.size = btnRendererActive.size;
            btnRendererInactive.color = Color.white;

            // Remove Text
            Transform textTransform = btnObj.transform.FindChild("FontPlacer");
            UnityEngine.Object.Destroy(textTransform.gameObject);

            // Remove Aspect
            AspectPosition aspectComponent = btnObj.GetComponent<AspectPosition>();
            UnityEngine.Object.Destroy(aspectComponent);

            // Button
            PassiveButton btnComponent = btnObj.GetComponent<PassiveButton>();
            btnComponent.OnClick = new();
            btnComponent.OnClick.AddListener(onClick);

            // Box Collider
            BoxCollider2D btnCollider = btnObj.GetComponent<BoxCollider2D>();
            btnCollider.size = btnRendererActive.size;

            return btnObj;
        }

        public static GenericPopup BuildPopup()
        {
            // Prefab
            GameObject popupPrefab = DestroyableSingleton<TwitchManager>.Instance.TwitchPopup.gameObject;
            GameObject popupObject = UnityEngine.Object.Instantiate(popupPrefab);
            GenericPopup popupComponent = popupObject.GetComponent<GenericPopup>();

            // Text
            TextMeshPro popupText = popupComponent.TextAreaTMP;
            popupText.enableAutoSizing = false;
            popupText.fontSize = 1.5f;

            // Background
            SpriteRenderer popupBackground = popupObject.transform.Find("Background").GetComponent<SpriteRenderer>();
            popupBackground.size = new Vector2(5, 5);

            // Button
            Transform confirmButton = popupObject.transform.Find("ExitGame");
            confirmButton.position -= new Vector3(0, 1.2f, 0);

            return popupComponent;
        }
    }
}
