using UnityEngine;

/**
* Used to wake up the SaveSystem and start the application.
*/
public class Initialize : MonoBehaviour 
{
    private void Awake()
    {
        SaveSystem.Load();
    }
}