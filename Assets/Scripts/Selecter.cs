using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selecter : MonoBehaviour
{
    private Gyroscope gyro;
    public GameObject EAT;
    public GameObject DESTROY;
    public GameObject CancelSelection;
    public GameObject Switcher;

    public GameObject Bomb;
    public GameObject Rocket;
    public GameObject Fork;
    public GameObject Spoon;

    public Swipe_motion SM;

    RaycastHit hitInfo;
    RaycastHit HCInfo;
    GameObject ob;
    public bool selected = false;
    public bool account = false;
    public bool fruitSelected = false;
    public Text nombre;
    public int eating = 0;


    void Selected()
    {

        gyro.enabled = false;
        EAT.SetActive(true);
        DESTROY.SetActive(true);
        CancelSelection.SetActive(true);
        fruitSelected = true;
    }

    public bool getState()
    {
        return (selected == true ? true : false);
    }
    // OnEat
    public void Eat()
    {
        gyro.enabled = true;
        EAT.SetActive(false);
        DESTROY.SetActive(false);
        Switcher.SetActive(true);

        eating = 2;

        //Debug.Log("A comer");
        ob = HCInfo.transform.gameObject;
        Debug.Log(ob.name);
        // Destroy(ob);
        selected = true;
        account = true;
        switch_panel();
    }

    void switch_panel()
    {
        if (account)
        {

            if (SM.Tool_Selector == 0)
            {
                hiddenWeaponLabels();
                Spoon.SetActive(true);
            }
            else
            {
                hiddenWeaponLabels();
                Fork.SetActive(true);
            }
        }
        else
        {
            if (SM.Tool_Selector == 0)
            {
                hiddenWeaponLabels();
                Bomb.SetActive(true);
            }
            else
            {
                hiddenWeaponLabels();
                Rocket.SetActive(true);
            }
        }

    }
    public void Switch_weapon()
    {
        SM.Tool_Selector++;
        SM.Tool_Selector = SM.Tool_Selector % 2;
        switch_panel();
    }

    public void Disapear()
    {
        Destroy(ob);
        nombre.text = "";
        eating = 0;
        hiddenWeaponLabels();
        hiddenButtons();
        fruitSelected = false;
    }
    //  OnDestroy
    public void Discard()
    {
        gyro.enabled = true;
        EAT.SetActive(false);
        DESTROY.SetActive(false);
        Switcher.SetActive(true);

        eating = 5;
        //Debug.Log("Al hielo <the godfather>");
        ob = HCInfo.transform.gameObject;
        Debug.Log(ob.name);
        //Destroy(ob);
        selected = true;
        account = false;
        switch_panel();
    }

    public void cancelSelected()
    {
        Debug.Log("cancelado seleccion");
        hiddenWeaponLabels();
        hiddenButtons();
        gyro.enabled = true;
        nombre.text = "";
        fruitSelected = false;
    }

    private void hiddenWeaponLabels()
    {
        Spoon.SetActive(false);
        Fork.SetActive(false);
        Bomb.SetActive(false);
        Rocket.SetActive(false);
    }

    private void hiddenButtons()
    {
        EAT.SetActive(false);
        DESTROY.SetActive(false);
        CancelSelection.SetActive(false);
        Switcher.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        SM = FindObjectOfType<Swipe_motion>();
        hiddenWeaponLabels();
        hiddenButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Cl.icked");
            if (fruitSelected == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo))
                {
                    var rig = hitInfo.collider.GetComponent<Rigidbody>();
                    Debug.Log("Ray");
                    if (rig != null)
                    {
                        Debug.Log("rig");

                        Selected();
                        HCInfo = hitInfo;
                        try
                        {
                            nombre.text = HCInfo.transform.gameObject.GetComponent<G_Foes>().Name;
                        }
                        catch
                        {
                            //Debug.Log("error");
                        }
                        //Debug.Log("object hit");

                    }
                }

            }
        }

    }
    public void Set_selected()
    {

        selected = false;
        account = false;

    }

    public int GetOption()
    {
        return eating;
    }
}
