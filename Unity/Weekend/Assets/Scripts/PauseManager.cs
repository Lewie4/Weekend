using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    [SerializeField] private bool m_isPaused;

    [SerializeField] private GameObject m_pauseMenu;

    public static PauseManager ms_instance;

    private void Awake()
    {
        if(ms_instance == null)
        {
            ms_instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start ()
    {
        m_isPaused = false;

        m_pauseMenu.SetActive(m_isPaused);
    }

    public void Pause()
    {
        m_isPaused = !m_isPaused;

        if(m_isPaused)
        {
            Time.timeScale = 0.0f;            
        }
        else
        {
            Time.timeScale = 1.0f;
        }

        m_pauseMenu.SetActive(m_isPaused);
    }

    public void Restart()
    {
        Pause();
        SceneManager.LoadScene("Main");
    }
}
