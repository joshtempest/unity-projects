using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{

    Animator minAnimator;

    // Start is called before the first frame update
    void Start()
    {
     minAnimator = gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {

    imPickedChecker();
     
    void imPickedChecker()

    {

        if (minAnimator.GetBool("picked") == false) 
        
        {
            minAnimator.SetBool("picked" , true);
        }

        else if(minAnimator.GetBool("picked") == true)
        
        {
            minAnimator.SetBool("picked", false);
        }

        }   
    }   
    
}
