using System.Collections;
using UnityEngine;

public class Chair_Logic_CS : MonoBehaviour
{
    [Header("Key Code for Sitting"), SerializeField]
    private KeyCode Standing_Up_Keycode; 
    
    
    
    // Start is called before the first frame update
    [Header("Main Character Referencia"), SerializeField]
    private GameObject Main_Character;
    //              |
    //              |
    //              |
    //              V
    private PlayerLogic _player_Logic;

    private Vector3 Starting_Coordinate;
    
    [SerializeField]
    private GameObject debug_cube;


    public Vector3 Chair_Position;
    private Vector3 Sitting_Position;


    
    

    private void Awake()
    {
        _player_Logic = Main_Character.GetComponent<PlayerLogic>();


        Chair_Position = transform.gameObject.transform.position;
        Sitting_Position = new Vector3(Chair_Position.x ,Chair_Position.y + 1f,(float)(Chair_Position.z + .2f));


    }

    private void Update()
    {
        if (Input.GetKeyDown(Standing_Up_Keycode))
        {
            Leave_Seat();
        }
    }


    public void Leave_Seat()
    { 
        _player_Logic.is_sitting = false;
    }
    public void USE()
    {
        
        
        
            

        Starting_Coordinate = Main_Character.transform.position;


        Main_Character.transform.position = Sitting_Position;

            
    }

}
