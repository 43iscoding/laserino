using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AchievementButton : MonoBehaviour, ISelectHandler, IDeselectHandler {

    public Button button;
    public string key;
    public Text name;
    public Text description;

    void Start()
    {
        button.interactable = !Achievements.HasAchievement(key);
    }

    public void OnSelect(BaseEventData eventData)
    {
        description.text = Achievements.Description(key);
        name.text = Achievements.Name(key);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        description.text = "";
        name.text = "";
    }
}
