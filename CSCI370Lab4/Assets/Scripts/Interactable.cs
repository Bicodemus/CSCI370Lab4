using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public BoxCollider triggerBox;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            GameManager.Instance.interactionCount--;
            triggerBox.isTrigger = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT!");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Leaving");
    }
}
