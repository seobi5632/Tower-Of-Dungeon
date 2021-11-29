using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonType : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public buttonType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

    public CanvasGroup mainGroup;
    public CanvasGroup oprionGroup;

    [SerializeField]
    private string click_sound;
    void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnButtonClick()
    {
        switch(currentType)
        {
            case buttonType.New:
                SceneLoader.LoadSceneHandle("Tutorial", 0);
                Debug.Log("New");
                break;
            case buttonType.Continue:
                SceneLoader.LoadSceneHandle("InGame", 1);
                Debug.Log("Continue");
                break;
            case buttonType.Option:
                CanvasGroupOn(oprionGroup);
                CanvasGroupOff(mainGroup);
                Debug.Log("Option");
                break;
            case buttonType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(oprionGroup);
                Debug.Log("Back");
                break;
            case buttonType.Exit:
                Application.Quit();
                Debug.Log("Exit");
                break;
        }
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
    public void ClickSound()
    {
        SoundManager.instance.PlaySE(click_sound);
    }
}
