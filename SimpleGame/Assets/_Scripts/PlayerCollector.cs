using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        print(name + " has been collected!!");
        
    }
}
