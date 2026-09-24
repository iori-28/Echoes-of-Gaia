using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class IntroCutsceneManager : MonoBehaviour
{
    [Header("Cutscene")]
    [SerializeField] private PlayableDirector playableDirector;

    [Header("Scene After Intro")]
    [SerializeField] private string nextScene = "Village";

    [Header("Player")]
    [SerializeField] private Behaviour playerMove;
    [SerializeField] private Behaviour playerCombat;

    private void Start()
    {
        if (PlayerPrefs.GetInt("IntroPlayed", 0) == 1)
        {
            SceneManager.LoadScene(nextScene);
            return;
        }

        if (playerMove != null)
        {
            playerMove.enabled = false;
        }

        if (playerCombat != null)
        {
            playerCombat.enabled = false;
        }

        if (playableDirector != null)
        {
            playableDirector.stopped += OnCutsceneFinished;
            playableDirector.Play();
        }
    }

    private void OnCutsceneFinished(PlayableDirector director)
    {
        PlayerPrefs.SetInt("IntroPlayed", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene(nextScene);
    }
}