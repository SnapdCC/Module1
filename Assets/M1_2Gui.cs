using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class M1_2Gui : MonoBehaviour
{
    private const float yScale = 17.75f;
    private const float xScale = 17.75147f;
    //UI Elements
    public Dropdown basinDD;
    public Dropdown accentDD;
    public Dropdown faucetDD;
    public Toggle accentT;
    public InputField faucetIF;
    public Slider horizontal;
    public Slider vertical;
    public GameObject myPrefab;
    public GameObject cam;
    public Text popupText;
    //Private objects for individual sink parts
    private GameObject sink;
    private GameObject faucet;
    private GameObject basin;
    private GameObject accent;
    //Private materials to modify sink color
    private Material basinColor;
    private Material accentColor;
    private Material faucetColor;
    //helper variables
    private bool reset = false;
    private bool quit = false;
    private bool accentToggle;


    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        sink = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        accent = sink.transform.GetChild(0).gameObject;
        faucet = sink.transform.GetChild(1).gameObject;
        basin = sink.transform.GetChild(9).gameObject;
        basinColor = basin.GetComponent<Renderer>().material;
        accentColor = accent.GetComponent<Renderer>().material;
        faucetColor = faucet.GetComponent<Renderer>().material;
    }
    //Script for modifying the attributes of the sink basin
    public void BasinColor()
    {
        int color = basinDD.value;
        // Debug.Log(color);
        if(color==0){
            basinColor.color=Color.gray;
        }
        else if(color==1){
            basinColor.color=Color.white;
        }
        else if(color==2){
            basinColor.color=Color.blue;
        }
        else if(color==3){
            basinColor.color=Color.black;
        }
    }
    //Scripts for modifying the attributes of the accent feature
    public void AccentToggle()
    {
        bool toggle = accentT.isOn;
        // Debug.Log(toggle);
        accent.SetActive(toggle);
    }
    public void AccentColor()
    {
        int color = accentDD.value;
        // Debug.Log(color);
        if(color==0){
            accentColor.color=Color.gray;
        }
        else if(color==1){
            accentColor.color=Color.red;
        }
        else if(color==2){
            accentColor.color=Color.green;
        }
        else if(color==3){
            accentColor.color=Color.blue;
        }
    }
    //Scripts for modifying the attributes of the faucet
    public void FaucetColor()
    {
        int color = faucetDD.value;
        // Debug.Log(color);
        if(color==0){
            faucetColor.color=Color.gray;
        }
        else if(color==1){
            faucetColor.color=Color.yellow;
        }
        else if(color==2){
            faucetColor.color=Color.white;
        }
    }
    public void FaucetLength()
    {
        float length = 20f;
        if (faucetIF.text!="")
        {
            length = Mathf.Max(float.Parse(faucetIF.text), length);
        }
        faucet.transform.localScale = new Vector3(xScale, yScale, length);
    }
    //Scripts for control buttons
    public void Reset()
    {
        if(reset){
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        } else{
            popupText.text="Are you sure? Press \"Reset\" again to confirm.";
            reset=true;
        }
    }
    public void Quit()
    {
        if(quit){
            Application.Quit();
        } else{
            popupText.text="Are you sure? Press \"Quit\" again to confirm.";
        }
    }
    public void Checkout()
    {
        popupText.text="Order placed. You may now exit.";
    }
    //Scripts for rotation sliders to move the camera/sink
    public void RotateX()
    {
        float angle = vertical.value - sink.transform.rotation.eulerAngles.x;
        sink.transform.Rotate(angle, 0f, 0f, Space.World);
    }
    public void RotateY()
    {
        float angle = horizontal.value - sink.transform.rotation.eulerAngles.y;
        sink.transform.Rotate(0f, angle, 0f, Space.World);;
    }
}
