using UnityEngine;
using Scythe.Accessibility;
public class DemoScript : MonoBehaviour
{
    [SerializeField] SubtitleCard subtitleCard;
    void Start()
    {
        SubtitleManager.instance.CueSubtitle(subtitleCard);
    }

}
