using UnityEngine;



public class LaterActive : MonoBehaviour
{
    public GameObject TriggerLefRig;
    public GameObject TriggerTopBot;
 

    private void Update()
    {
        int rotate = (int) (Mathf.Abs(transform.rotation.z) * 1000f);


        if (rotate < 500 || rotate > 850) 
        {
            TriggerTopBot.SetActive(true);
            TriggerLefRig.SetActive(false);
            Debug.Log(rotate);
        }
        else
        {
            TriggerTopBot.SetActive(false);
            TriggerLefRig.SetActive(true);
        }
       
    }
    

}
