using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    
    
    public const int full_hp = 100;

    public int current_hp = 100;


    public float _move_speed = 12f;

    public bool _is_healing = false;
    public bool _can_heal = true;



    public bool is_sitting;
    
    

    public void Healing(int healed_amount, int healing_time)
    {
        if (_is_healing == false && _can_heal == true)
        {
            
            _is_healing = true;
            _can_heal = false;
            
            StartCoroutine(Healing_Corutine(healed_amount, healing_time));//elindit egy "mellekagat", ami X masodperc utan healel
        }
    }

    // private void Update()
    // {
    //     Debug.Log(current_hp);
    // }

    IEnumerator Healing_Corutine(int healed_amount, int healing_time)
    {
        yield return new WaitForSeconds(healing_time); // 5 sec-et var
        // utanna elvegzi a fuggveny maradek reszet
        _can_heal = true;
        _is_healing = false;

        if (current_hp + healed_amount > full_hp) current_hp += healed_amount;
        else current_hp = full_hp;
        
    }

    public void Increase_Movement_Speed(int amount)
    {
        
    }
    

}
