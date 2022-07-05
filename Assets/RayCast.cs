using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    [Header("Key Binding")] 
    public KeyCode raycast_keycode = KeyCode.E;

    [Header("Range")] 
    public float RANGE = 3;

    [Header("Mask"), SerializeField] 
    public LayerMask mask; 

    [Header("Camera"), SerializeField] 
    public Transform main_camera;


    private void Update()
    {
        if (Input.GetKeyDown(raycast_keycode))
        {
            Shoot_RayCast();
        }
    }

    void Shoot_RayCast()
    {
        Ray Ray = new Ray(main_camera.transform.position, main_camera.transform.forward);
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(ray: Ray,hitInfo: out hitInfo,maxDistance: RANGE,layerMask: mask);
        Debug.DrawRay(Ray.origin,Ray.direction * RANGE,Color.red,4);
        if(hit)
        {
            if (hitInfo.transform.gameObject.CompareTag("Chair"))
            {   
                hitInfo.transform.gameObject.GetComponent<Chair_Logic_CS>().USE();


                // if (this.transform.position = new Vector3(hitInfo.transform.position.x ,hitInfo.transform.position.y + 1.5f,(float)(hitInfo.transform.position.z + .2f)))
                // {
                //     GetComponent<PlayerLogic>().is_sitting = true;
                // }       


                Debug.Log($"KOORDINATA :::::::::::::::::::::::::::::::::::::::::::: {hitInfo.point}");

                return;

                
            }


            GameObject hitObject = hitInfo.transform.gameObject.transform.parent
                    .gameObject; // nem a test a hitObject, hanem annak a "szuloje"
                
            
            



            if ((hitObject.CompareTag("Consumeable") && GetComponent<InventoryController>().get_free_space(GetComponent<InventoryController>().Fifth_Slot) > 0) || (hitObject.CompareTag("PickupItem") && GetComponent<InventoryController>().get_free_space(GetComponent<InventoryController>().MAIN_INVENTORY) > 0) )
            {
                
                GameObject item_Copy = GameObject.Instantiate(original:hitObject,parent:main_camera);
                item_Copy.SetActive(false);
                
                
                //Igy kene hivatkozni egy masik method-ra egy kulon scriptbol 

                if (hitObject.CompareTag("PickupItem") && GetComponent<InventoryController>().get_free_space(GetComponent<InventoryController>().MAIN_INVENTORY) > 0)
                {
                    
                    this.GetComponent<InventoryController>().Update_Inventory(item_Copy);
                    
                    Destroy(hitObject);
                }
                
                
                
                else if (hitObject.CompareTag("Consumeable") && GetComponent<InventoryController>().get_free_space( GetComponent<InventoryController>().Fifth_Slot ) > 0)
                {
                    this.GetComponent<InventoryController>().Update_Consumeable_Inventory(item_Copy);
                    
                    Destroy(hitObject);
                }
                
                
            }
                
            
            
            //taggel tudom megnezni hogy milyen
            //Debug.Log(hitObject.GetComponent<Image>().sprite);

           
                
            
            


        }
        
        
        

    }
}
