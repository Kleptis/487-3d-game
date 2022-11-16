using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBubble : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private Animator animator;
    [SerializeField] GameObject npc;
    NPCBase npcBase;
    private string currentAnimation;
    //Animation States
    const string BUBBLE_PLAY = "bubble_play";
    private void Awake()
    {
        visualCue.SetActive(false);
        npcBase = npc.GetComponent<NPCBase>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SpeechBubbleVisible(Component sender, object data)
    {
        if ((int)data == npcBase.Id)
        {
            visualCue.SetActive(true);
            animator.Play(BUBBLE_PLAY);
        }
        else
            visualCue.SetActive(false);
    }
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

}
