using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TriggerArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvent gameEvent;
    ObjectBase objBase;
    [SerializeField] GameObject obj;
    [SerializeField] string tag_of_trigger_obj;
    

    private void Awake()
    {
        objBase = obj.GetComponent<ObjectBase>();
        //Physics.gravity = new Vector3(0, -1.0F, 0);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(tag_of_trigger_obj))
            //GameEvents.current.NPCTriggerEnter(id);
            gameEvent.Raise(this, objBase.Id);
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag(tag_of_trigger_obj))
            //GameEvents.current.NPCTriggerExit(id);
            gameEvent.Raise(this, -99);
    }
}
