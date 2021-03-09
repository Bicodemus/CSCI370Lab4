using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionCount : MonoBehaviour
{

    public TextMeshProUGUI interactionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interactionText.text = "Interactions: " + GameManager.Instance.interactionCount;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.interactionCount--;
        }
    }
}
