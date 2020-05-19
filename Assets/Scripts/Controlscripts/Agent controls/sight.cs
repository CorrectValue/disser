using UnityEngine;
using System.Collections;

public class sight : MonoBehaviour {

    public float fieldOfViewAngle = 110f;
    public float collectibleInSight;
    public Vector3 lastCollectibleSighting;

    
    private SphereCollider col;
    private Animator anim;
   // private LastSighting lastSighting;
    private GameObject collectible;

    void Awake()
    {
        
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
       // lastSighting
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == ...)
    }
}
