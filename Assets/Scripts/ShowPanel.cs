using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

[AddComponentMenu ("My component/Panel")]
public class ShowPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public bool open;
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
