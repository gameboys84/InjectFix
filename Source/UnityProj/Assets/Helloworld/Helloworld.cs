/*
 * Tencent is pleased to support the open source community by making InjectFix available.
 * Copyright (C) 2019 Tencent.  All rights reserved.
 * InjectFix is licensed under the MIT License, except for the third-party components listed in the file 'LICENSE' which may be subject to their corresponding license terms. 
 * This file is subject to the terms and conditions defined in file 'LICENSE', which is part of this source code package.
 */

using System;
using UnityEngine;
using IFix.Core;
using System.IO;
using System.Diagnostics;

// 跑不同仔细看文档Doc/example.md
public class Helloworld : MonoBehaviour {

    // check and load patchs
    void Start () {
    }

    private void OnGUI()
    {
        if (GUILayout.Button("BUTTON LOAD", new []{ GUILayout.Width(400), GUILayout.Height(260) }))
        {
            UnityEngine.Debug.Log("Button Clicked");
            
            VirtualMachine.Info = (s) => UnityEngine.Debug.Log(s);
            //try to load patch for Assembly-CSharp.dll
            var patch = Resources.Load<TextAsset>("Assembly-CSharp.patch");
            if (patch != null)
            {
                UnityEngine.Debug.Log("loading Assembly-CSharp.patch ...");
                var sw = Stopwatch.StartNew();
                PatchManager.Load(new MemoryStream(patch.bytes));
                UnityEngine.Debug.Log("patch Assembly-CSharp.patch, using " + sw.ElapsedMilliseconds + " ms");
            }
            //try to load patch for Assembly-CSharp-firstpass.dll
            patch = Resources.Load<TextAsset>("Assembly-CSharp-firstpass.patch");
            if (patch != null)
            {
                UnityEngine.Debug.Log("loading Assembly-CSharp-firstpass ...");
                var sw = Stopwatch.StartNew();
                PatchManager.Load(new MemoryStream(patch.bytes));
                UnityEngine.Debug.Log("patch Assembly-CSharp-firstpass, using " + sw.ElapsedMilliseconds + " ms");
            }

            test();
        }

        if (GUILayout.Button("RUN", new[] {GUILayout.Width(400), GUILayout.Height(150)}))
        {
            test();
        }
    }

    // [IFix.Patch]
    void test()
    {
        var calc = new IFix.Test.Calculator();
        //test calc.Add
        UnityEngine.Debug.Log("10 + 9 = " + calc.Add(10, 9));
        //test calc.Sub
        UnityEngine.Debug.Log("10 - 2 = " + calc.Sub(10, 2));

        var anotherClass = new AnotherClass(1);
        //AnotherClass in Assembly-CSharp-firstpass.dll
        var ret = anotherClass.Call(i => i + 1);
        UnityEngine.Debug.Log("anotherClass.Call, ret = " + ret);

        
        // GameObject go = new GameObject("NewClassTest");
        // var c = go.AddComponent<NewClassTest3>();
        // UnityEngine.Debug.Log("NewClassTest over");

        // NewClassTest2 cls = new NewClassTest2();
        // cls.Test();
        // UnityEngine.Debug.Log("NewClassTest2 over 1");
        //
        // cls.A = 10;
        // cls.TestA();
        // UnityEngine.Debug.Log("NewClassTest2 over 2");
     
        
        // NewClassTest2 cls = new NewClassTest2();
        // cls.Test();
        // UnityEngine.Debug.Log("NewClassTest22 over 1");
        
        // cls.A = 10;
        // cls.newValue = 112;
        // NewClassTest2.newStaticValue = 12;
        //
        // cls.TestA();
        // UnityEngine.Debug.Log("NewClassTest22 over 2");
        //
        // cls.TestNewFunc();
        // UnityEngine.Debug.Log("NewClassTest22 over 3");
        
        
        // 直接继承自MonoBehavior在应用patch时会报找不到此类 
        // GameObject go = new GameObject("NewClassTest3");
        // var c = go.AddComponent<NewClassTest3>();
        // // NewClassTest3 cls3 = new NewClassTest3();
        // // cls3.Start();
        // UnityEngine.Debug.Log("NewClassTest3 over");
        
        var go = new GameObject("NewClassTest3");
        var behaviour = go.AddComponent(typeof(VMBehaviourScript)) as VMBehaviourScript;
        behaviour.VMMonoBehaviour = new NewClassTest3();
        

        //test for InjectFix/Fix(Android) InjectFix/Fix(IOS) Menu for unity 2018.3 or newer
#if UNITY_2018_3_OR_NEWER
#if UNITY_IOS
        UnityEngine.Debug.Log("UNITY_IOS");
#endif
#if UNITY_EDITOR
        UnityEngine.Debug.Log("UNITY_EDITOR");
#endif
#if UNITY_ANDROID
        UnityEngine.Debug.Log("UNITY_ANDROID");
#endif
#endif
    }
}
