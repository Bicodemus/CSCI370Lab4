using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGlow : MonoBehaviour
{
    public Material mat;
    SkinnedMeshRenderer rend;
    Material[] mats;
    ParticleSystem[] ps;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
        ps = gameObject.GetComponentsInChildren<ParticleSystem>();
        mats = rend.materials;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < rend.materials.Length; i++)
            {
                mats[i] = mat;
            }

            rend.materials = mats;
            ps[0].Play();
            GameManager.Instance.interactionCount++;
        }
    }

}
