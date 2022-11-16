using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    // Start is called before the first frame update
    [field: SerializeField]
    public int Id { get; private set; }
}   
