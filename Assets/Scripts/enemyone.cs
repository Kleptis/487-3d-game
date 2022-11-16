using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyone : MonoBehaviour
{
    public float maxhealth;
    public float currenthealth;
    public int damagerange;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 8 + 2 * GameManager.level;
        currenthealth = maxhealth;
        damagerange = 2 * GameManager.level;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp =  new Vector3(5.0f*(currenthealth/maxhealth), this.transform.localScale.y, this.transform.localScale.z);
        this.transform.localScale = temp;
        if(currenthealth <= 0)
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
