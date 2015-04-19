using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, ISelectHandler, IDeselectHandler {

    public Button button;
    public int index;

    void Start()
    {
        button.interactable = Levels.IsLevelUnlocked(index);
        if (index == 1)
        {
            button.Select();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        MainMenu.instance.OnLevelSelect(index);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //TODO?
    }
}
