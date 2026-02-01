using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B_Extensions;
using B_Extensions.SceneLoader;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CallerSceneLoader))]
public class ButtonLoaderScene : BaseButtonAttendant
{
    [SerializeField] bool pauseOnClick = false;
    [SerializeField] bool unpauseOnClick = false;
    [SerializeField] bool reload = false;
    CallerSceneLoader callerLoading;
    private void Start()
    {
        buttonComponent.onClick.AddListener(LoadScene);
        callerLoading = GetComponent<CallerSceneLoader>();
    }

    private void LoadScene()
    {
        if (reload)
            callerLoading.LoadScene();
        else
        {
            var active = SceneManager.GetActiveScene();
            SceneManager.LoadScene(active.name);
        }

        if(pauseOnClick)
            callerLoading.Pause();
        if (unpauseOnClick)
            callerLoading.Unpause();
    }
}