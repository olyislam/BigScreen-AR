using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class CameraController : MonoBehaviour
{

    #region green_screen_remover_Unit
    public Material Green_screen_material;
    WebCamTexture World_Futage;
  
    void Start()
    {
        WebCamDevice[] All_Device_Camera = WebCamTexture.devices;
        if (All_Device_Camera.Length == 0)
        {
            Debug.Log("Camera is not available in this device");
            return;
        }
 
        for (int i = 0; i < All_Device_Camera.Length; i++)
        {

   /*       
            if (!All_Device_Camera[i].isFrontFacing)
            {

                World_Futage = new WebCamTexture(All_Device_Camera[i].name, Screen.width, Screen.height);
            }

   */           
            if (All_Device_Camera[i].isFrontFacing)
            {
                 World_Futage = new WebCamTexture(All_Device_Camera[i].name, Screen.width, Screen.height);
            }
         
        }
        if (World_Futage == null)
        {
            Debug.Log("Camera can't read data from this device");
            return;
        }


        Green_screen_material.mainTexture = World_Futage;
        World_Futage.Play();
       
    }
#endregion green_screen_remover_Unit


 #region video_controller_unit
    public Texture[] img;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Green_screen_material.SetTexture("_TexReplacer", img[0]);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Green_screen_material.SetTexture("_TexReplacer", img[1]);
        }

    }
#endregion video_controller_unit


}