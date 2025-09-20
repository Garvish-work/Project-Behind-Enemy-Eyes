using UnityEngine;

namespace UI.ToolKit
{

    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasIdentity : MonoBehaviour
    {
        UiManager uiManager;
        CanvasGroup canvasGroup;
        ICanvasAnimation customAnimation;

        [SerializeField] private CanvasNames myCanvasName;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            customAnimation = GetComponentInChildren<ICanvasAnimation>();
        }

        private void Start()
        {
            uiManager = UiManager.instance;
            uiManager.AddCanvas(this);
        }

        public CanvasNames GetCanvasName()
        {
            return myCanvasName;
        }

        public void EnableCanvas()
        {
            if (customAnimation != null)
            {
                customAnimation.EnableAnimation();
            }

            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public void DisableCanvas()
        {
            if (customAnimation != null)
            {
                customAnimation.DisableAnimation();
            }

            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}