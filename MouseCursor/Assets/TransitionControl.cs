using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionControl : MonoBehaviour
{
    public Animator m_Animator;
    public GameObject trashy;
    private bool endTutorial;
    public AudioSource musicA;
    public AudioSource musicB;
    public AudioSource musicC;
    public AudioSource musicD;
    public List<AudioSource> music;
    private bool played1;
    private bool played2;
    private AudioSource oldMusic;
    // Start is called before the first frame update
    void Start()
    {
        musicA.PlayDelayed(4.0f);
        oldMusic = musicA;
        endTutorial = false;
        played1 = false;
        played2 = false;
        music.Add(musicA);
        music.Add(musicB);
        music.Add(musicC);
        music.Add(musicD);
    }



    // Update is called once per frame
    void Update()
    {
        if (endTutorial && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(sceneName: "TimerAndTrail");
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!endTutorial)
            {
                oldMusic.Stop();
                oldMusic = music[Random.Range(0, 3)];
                oldMusic.Play();
            }
            Debug.Log("SPace");
            m_Animator.SetTrigger("Transition");
            
        }
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Tutorial2"))
        {
            trashy.SetActive(true);
        }
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Tutorial5")) {

            endTutorial = true;
        }
    }
}
