using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTriggerArea : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.current.PortalTriggerEnter(id);
            GameManager.level++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            GameEvents.current.PortalTriggerExit(id);
    }
}
