using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Consumeable : MonoBehaviour
{
    [Header("Bonus HP"), SerializeField] 
    private int _bonus_hp;


    [Header("Animation Length"), SerializeField]
    private int _animation_lenght; 


    [Header("Main Character Referencia"), SerializeField]
    private GameObject Main_Character;
    //              |
    //              |
    //              |
    //              V
    private PlayerLogic _player_Logic;

    private void Awake() // JOE BIDEN WAKE UP
    {
        _player_Logic = Main_Character.GetComponent<PlayerLogic>();
    }

    public void Use_Item()
    {
        _player_Logic.Healing(_bonus_hp,_animation_lenght);
    }
}
