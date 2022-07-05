using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryController : MonoBehaviour
{
        public GameObject[] MAIN_INVENTORY = new GameObject[4];
        public GameObject[] Fifth_Slot = new GameObject[3]; //az otodik slot egy "forgatasos" (kinda mint csgoban a granatok) 
                                                                // nem kell mennyiseggel foglalkozni, ha "nagyba" gondolkoz, (nem 8 bandage, hanem 1 first aid) 
        
        [SerializeField, Header("Hot Bar Referencia")]
        public List<Image> HOT_BAR_PANELS;

        [SerializeField, Header("Key Mapping")]
        public KeyCode First_Slot_KeyCode;
        public KeyCode Second_Slot_KeyCode;
        public KeyCode Third_Slot_KeyCode;
        public KeyCode Fourth_Slot_KeyCode;
        
        [SerializeField, Header("Consumeable Key Mapping")]
        public KeyCode Fifth_Slot_KeyCode; 
        public KeyCode Use_Consumeable_KeyCode;


       public GameObject Used_Item;


       public int _current_item_index_on_fifth;


       private void Start()
       {
               _current_item_index_on_fifth = 0;
       }

       private void Update()
        {
                //Debug.Log(message: get_free_space());
                //Debug.Log(HOT_BAR_PANELS.Count);
                
                // Input Feldolgozasa
                if (Input.GetKeyDown(First_Slot_KeyCode)) use_slot_first();
                else if (Input.GetKeyDown(Second_Slot_KeyCode)) use_slot_second();
                else if (Input.GetKeyDown(Third_Slot_KeyCode)) use_slot_third();
                else if (Input.GetKeyDown(Fourth_Slot_KeyCode)) use_slot_fourth();
                else if (Input.GetKeyDown(Fifth_Slot_KeyCode)) use_slot_fifth(); 
                else if (Input.GetKeyDown(Use_Consumeable_KeyCode)) use_consumeable();
        }

        public void Update_Inventory(GameObject new_item)
        {       //event... 
                // a raycast fogja meghivni
                

                bool is_full = true;
                
                for (int i = 0; i < MAIN_INVENTORY.Length; i++)
                {
                        if (MAIN_INVENTORY[i] == null)
                        {
                                MAIN_INVENTORY[i] = new_item;
                                is_full = false;
                                break;
                        }
                }

                if (is_full)
                {
                        Debug.Log("TELE VAN");
                }
                
                Update_Hotbar();
        }
        public void Update_Consumeable_Inventory(GameObject new_item)
        {       //event... 
                // a raycast fogja meghivni
                

                bool is_full = true;
                
                for (int i = 0; i < Fifth_Slot.Length; i++)
                {
                        if (Fifth_Slot[i] == null)
                        {
                                Fifth_Slot[i] = new_item;
                                is_full = false;
                                break;
                        }
                }

                if (is_full)
                {
                        Debug.Log("TELE VAN A CONSUMEABLE SLOT");
                }
                
                Update_Hotbar();
        }

        private void Update_Hotbar()
        {
                for (int i = 0; i < MAIN_INVENTORY.Length; i++)
                {
                        if (HOT_BAR_PANELS[i] != null && MAIN_INVENTORY[i] != null && MAIN_INVENTORY[i].GetComponent<Image>()) //nehogy veletlen null ertekre hivatkozzak (Unreal mar 5x crashelt vonlna ki null referencre)
                        {
                                HOT_BAR_PANELS[i].sprite = MAIN_INVENTORY[i].GetComponent<Image>().sprite;
                        }

                }

                if (HOT_BAR_PANELS[4] != null && MAIN_INVENTORY[_current_item_index_on_fifth] != null && MAIN_INVENTORY[_current_item_index_on_fifth].GetComponent<Image>().sprite )
                        try{HOT_BAR_PANELS[4].sprite = Fifth_Slot[_current_item_index_on_fifth].GetComponent<Image>().sprite;} // a consumeable slot hotbar update}
                                catch(Exception E){Debug.Log($"{E} = meg kene adni egy kepet");}


                                //Event; Update_Inventory Hivja meg
        }

        private void use_slot_first()
        {
                if (MAIN_INVENTORY[0])
                {
                        Debug.Log("Elso Slot hasznalva");

                        if (Used_Item != null)
                        {
                                Used_Item = MAIN_INVENTORY[0];
                        }
                        //!!MEG KELL MEG IRNI !!
                        // throw new NotImplementedException();

                        var Components = MAIN_INVENTORY[0].GetComponents(typeof(MonoBehaviour));
                        foreach (var Component in Components)
                        {

                                Debug.Log(Component);
                        }
                }
        }
        private void use_slot_second()
        {
                if (MAIN_INVENTORY[1]){
                        Debug.Log("Masodik Slot hasznalva");
                        
                        if(Used_Item != null)
                        {
                                Used_Item = MAIN_INVENTORY[1];
                        }
                        //!!MEG KELL MEG IRNI !!
                      //throw new NotImplementedException();  
                      
                      var Components = MAIN_INVENTORY[1].GetComponents(typeof(MonoBehaviour));
                      foreach(var Component in Components)
                      {
                        
                        Debug.Log(Component);
                      }
                }
        }
        private void use_slot_third()
        {
                if (MAIN_INVENTORY[2])
                {
                        Debug.Log("Harmadik Slot hasznalva");

                        if (Used_Item != null)
                        {
                                Used_Item = MAIN_INVENTORY[2];
                        }

                        //!!MEG KELL MEG IRNI !!
                        //throw new NotImplementedException();  

                        var Components = MAIN_INVENTORY[2].GetComponents(typeof(MonoBehaviour));
                        foreach (var Component in Components)
                        {

                                Debug.Log(Component);
                        }
                }
        }
        private void use_slot_fourth()
        {
                if (MAIN_INVENTORY[3])
                {
                        Debug.Log("Negyedik Slot hasznalva");


                        if (Used_Item != null)
                        {
                                Used_Item = MAIN_INVENTORY[3];
                        }
                        //!!MEG KELL MEG IRNI !!
                        //throw new NotImplementedException(); 

                        var Components = MAIN_INVENTORY[3].GetComponents(typeof(MonoBehaviour));
                        foreach (var Component in Components)
                        {

                                Debug.Log(Component);
                        }
                }
        }

        private void use_slot_fifth()
        {
                if (_current_item_index_on_fifth <= 2) _current_item_index_on_fifth++;
                else _current_item_index_on_fifth = 0;
                
                Debug.Log(_current_item_index_on_fifth);
        }

        private void use_consumeable()
        {
                if (Fifth_Slot[_current_item_index_on_fifth].name.Contains("Health")) // valoszinuleg hp-zos lesz
                        Fifth_Slot[_current_item_index_on_fifth].GetComponent<Health_Consumeable>().Use_Item();
                
                Debug.Log("Felhasznalva");
                Destroy(Fifth_Slot[_current_item_index_on_fifth]); // kitakaritas
        }
        
        
        
        
        public int get_free_space(GameObject[] Inventory)
        {
                int ures_hely = 0;


                foreach (GameObject item in Inventory)
                {
                        if (item == null)
                        {
                                ures_hely++;
                        }
                }

                return ures_hely;
        }
        
        
        
        
        
}
