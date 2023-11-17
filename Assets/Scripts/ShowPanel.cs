using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class ShowPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public static bool open = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            open = !open;
            SwitchPanel();
        }


    }

    private void SwitchPanel()
    {
        

        if (open)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
