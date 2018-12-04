using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

	public   static   GlobalControl   Instance ; 

	public   int  id; 
    public   string   nome;
    public   float  cash ; 

    public string [] dataPage;
    public string [] userWeapon;

    void   Awake   () { 

         if   ( Instance   ==   null ) 
         { 
             DontDestroyOnLoad ( gameObject ); 
             Instance   =   this ; 
         } 
         else   if   ( Instance   !=   this ) 
         { 
             Destroy   ( gameObject ); 
         } 
    } 

}
