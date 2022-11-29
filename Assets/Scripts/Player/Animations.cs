using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    private string currentState;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("speech_bubble_anim");
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    // Update is called once per frame
}
