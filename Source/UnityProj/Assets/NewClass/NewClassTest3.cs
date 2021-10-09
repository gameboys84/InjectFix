using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 直接从MonoBehavior继承在应用patch时会提示找不到这个类
// public class NewClassTest3 : MonoBehaviour

// 因此采用下面的方式间接继承MonoBehavior
[IFix.Interpret]
public class NewClassTest3 : IMonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("NewClassTest3 Start");
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log("NewClassTest3 Update");
    }
}
