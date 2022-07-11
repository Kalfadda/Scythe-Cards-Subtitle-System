using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Scythe.Accessibility
{
    public class SubtitleManager : MonoBehaviour
    {

        // instance definition
        public static SubtitleManager instance;

        // reference to our subtitle text object
        [Tooltip("The text used for the subtitles, can be any text object")] [SerializeField] public TextMeshProUGUI subtitleText;

        // optional functionality if we want to interrupt subtitles 
        [Tooltip("If false, does not interrupt the current playing subtitle")] public bool subtitlesInterrupt;

        // throwaway variables
        private Coroutine _subControl;
        private bool _subtitleSequenceRunning;

        // for additional functionality, if needed :)
        public UnityEvent BeforeSubtitleBegins;
        public UnityEvent OnSubtitleFinished;


        void Awake()
        {
            instance = this;
        }

        public void CueSubtitle(SubtitleCard subCard)
        {
            if(!subtitlesInterrupt && _subtitleSequenceRunning)
            {
                return;
            }
            else
            {
                if (_subtitleSequenceRunning)
                {
                    StopCoroutine(_subControl);
                }
            }
            _subControl = StartCoroutine(SubtitleControl(subCard));
        }

        IEnumerator SubtitleControl(SubtitleCard subCard)
        {
            BeforeSubtitleBegins.Invoke(); // for additional functionality, if needed :)
            _subtitleSequenceRunning = true;
            for (int i = 0; i < subCard.dialogue.Length; i++)
            {
                subtitleText.text = subCard.dialogue[i];
                yield return new WaitForSeconds(subCard.pauseUntilNextLine[i]);
            }
            subtitleText.text = "";
            _subtitleSequenceRunning = false;
            OnSubtitleFinished.Invoke(); // for additional functionality, if needed :)
            Debug.Log("Subtitle Sequence finished");
        }
    }
}

// The subtitle manager is a singleton instance so we can call it from any script.

