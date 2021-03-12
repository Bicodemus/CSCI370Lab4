using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfish : MonoBehaviour
{
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
        if(GameManager.Instance.interactionCount >= 10)
        {
            GameManager.Instance.interactionCount = 0;
            GameManager.Instance.nextScene();
        }
    }
}
