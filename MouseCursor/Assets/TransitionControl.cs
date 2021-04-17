using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionControl : MonoBehaviour
{
    public Animator m_Animator;
    public GameObject trashy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPace");
            m_Animator.SetTrigger("Transition");
        }
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Tutorial2"))
        {
            trashy.SetActive(true);
        }
    }
}
