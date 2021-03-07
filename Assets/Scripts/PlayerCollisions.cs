using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{   
    private int batteries = 0;
    public Sprite battery0;
    public Sprite battery1;
    public Sprite battery2;
    public Sprite battery3;
    public Sprite battery4;
    private Sprite[] batteryPics = new Sprite[5];
    public Image batteryImage;

    // Start is called before the first frame update
    void Start()
    {
        batteryPics[0] = battery0;
        batteryPics[1] = battery1;
        batteryPics[2] = battery2;
        batteryPics[3] = battery3;
        batteryPics[4] = battery4;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            if(hit.collider.gameObject.tag == "Pickup")
            {
                Debug.Log(hit.distance);
                hit.collider.gameObject.GetComponent<Renderer>().material.color =Color.black;

            }
            if(hit.collider.gameObject.tag == "Battery")
            {
                hit.collider.gameObject.GetComponent<AudioSource>().Play(0);
                batteries++;
                Debug.Log("Batteries Collected:" + batteries);
                hit.collider.transform.localScale = new Vector3(0f,0f,0f);
                hit.collider.enabled = false;
                batteryImage.sprite = batteryPics[batteries];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Platform")
        {
            transform.parent = other.transform; //player child of the platform
            if(batteries>=4){
                transform.parent.GetComponent<PlatformMover>().enabled = true;
            }
            else{
                Debug.Log("Elevator needs 4 batteries to work. You have "+batteries+".");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Platform")
        {
            transform.parent.GetComponent<PlatformMover>().enabled = false;
            transform.parent = null;
        }
    }
}
