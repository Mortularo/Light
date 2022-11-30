using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLight : MonoBehaviour
{
    public GameObject LiteCristal;
    public bool SetLit;

    private void Start()
    {
        SetLit = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetLit = !SetLit;
            if (SetLit == true)
            {
                LiteCristal.SetActive(true);
            }
            if (SetLit == false)
            {
                LiteCristal.SetActive(false);
            }
        }

    }
}
