using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Cell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().PlaySound("PickupEnergyCell");
        if (other.tag == "Player")
        {
            PlayerManager.numberOfCells += 1;
            Destroy(gameObject);
        
        }

    }

}
