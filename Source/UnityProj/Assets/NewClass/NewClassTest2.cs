using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClassTest2
{
    // [IFix.Interpret]
    // public static int newStaticValue = 11;
    // [IFix.Interpret]
    // public int newValue = 111;
    // [IFix.Interpret] 
    // public int NewValue => newValue;
        
    private int a = 1;

    public int A
    {
        get
        {
            return a;
        }
        set
        {
            a = value;
        }
    }
    
    // [IFix.Patch]
    public void Test()
    {
        // UnityEngine.Debug.Log($"NewClassTest2.Test1 a:{a}, static:{newStaticValue}, normal:{newValue}");
        UnityEngine.Debug.Log($"NewClassTest2.Test1 a:{a}");
    }

    // [IFix.Patch]
    public void TestA()
    {
        // UnityEngine.Debug.Log($"NewClassTest2.Test2 a:{a}, static:{newStaticValue}, normal:{newValue}");
        UnityEngine.Debug.Log($"NewClassTest2.Test2 a:{a}");
    }

    // [IFix.Interpret]
    // public void TestNewFunc()
    // {
    //     UnityEngine.Debug.Log($"NewClassTest2.TestNewFunc static:{newStaticValue}, normal:{newValue}");
    // }
}
