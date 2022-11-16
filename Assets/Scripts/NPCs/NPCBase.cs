using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : ObjectBase
{
    // Start is called before the first frame update
    [field: SerializeField]
    public string Name { get; private set;}
    [field: SerializeField]
    public Sprite CharImage { get; private set;}

    void Start()
    {
        CharImage = GetComponent<Sprite>();
    }
    
    //public GameEvent onNPCinRange;
    //private void Start()
    //{
    //    GameEvents.current.onNPCTriggerEnter += OnNPCInteracted;
    //    GameEvents.current.onNPCTriggerExit += OnNPCExit;
    //}
    //private void OnNPCInteracted(int id)
    //{
    //    if (id == this.id)
    //    {
    //        //visualCue.SetActive(true);
    //        onNPCinRange.Raise(this, true);
    //        Debug.Log("you're talking with NPC" + id);
    //    }
    //}

    //private void OnNPCExit(int id)
    //{
    //    if (id == this.id)
    //    {
    //        onNPCinRange.Raise(this, false);
    //        Debug.Log("you've stopped talking with NPC" + id);
    //    }
    //}

    //private void OnDestroy()
    //{
    //    GameEvents.current.onNPCTriggerEnter -= OnNPCInteracted;
    //    GameEvents.current.onNPCTriggerExit -= OnNPCInteracted;
    //}
}
