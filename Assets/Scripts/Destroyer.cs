using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.name == "SpawnPointClosedRoom") {
        // destroy closed room when set in entry room
        Destroy(other.gameObject.transform.parent.gameObject);
      }
    }
}
