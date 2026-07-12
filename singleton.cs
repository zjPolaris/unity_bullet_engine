using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton<T> where T : singleton<T> 
{
    protected singleton(){
        
    }
    private static T instance=null;
    public static T Instance{
        get{
            if(instance==null){
                instance = Activator.CreateInstance<T>();
            }
            return instance;
        }
    }

}

