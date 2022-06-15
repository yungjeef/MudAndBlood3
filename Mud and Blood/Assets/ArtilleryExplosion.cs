using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryExplosion : MonoBehaviour
{

    public GameObject artilleryExplosion;
    public bool callArtilleryStrike;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(artilleryExplosion);
    }

    // Update is called once per frame
    void Update()
    {
        if(callArtilleryStrike) {
            
        }
    }
}
