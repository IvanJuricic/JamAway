using UnityEngine;
using UnityEngine.UI;

public class PluginScript : MonoBehaviour
{

    //[SerializeField] Text text;


    void Awake()
    {
        if (PermissionScript.IsPermitted(AndroidPermission.READ_EXTERNAL_STORAGE))
        {
            //text.text = "READ_EXTERNAL_STORAGE is already permitted!!";
            return;
        }

        PermissionScript.RequestPermission(AndroidPermission.READ_EXTERNAL_STORAGE, OnAllow, OnDeny, OnDenyAndNeverAskAgain);
    }
    
    private void OnAllow()
    {
        //text.text = "READ_EXTERNAL_STORAGE is permitted NOW!!";

    }

    private void OnDeny()
    {
        //text.text = "READ_EXTERNAL_STORAGE is NOT permitted...";
    }

    private void OnDenyAndNeverAskAgain()
    {
        //text.text = "READ_EXTERNAL_STORAGE is NOT permitted and checked never ask again option";
    }
}
