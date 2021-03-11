using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGlow : MonoBehaviour
{
    public Material mat;
    SkinnedMeshRenderer rend;
    Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
        mats = rend.materials;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        for (int i = 0; i < 3; i++)
        {
            mats[i] = mat;
            Debug.Log("Material: " + mats[i]);
        }
    }

}
