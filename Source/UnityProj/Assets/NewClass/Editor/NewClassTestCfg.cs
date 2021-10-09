using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;
using System;
using System.Linq;
using System.Reflection;

// 这个文件和Configure、HelloworldCfg本质是一样的，保留一份即可
[Configure]
public class NewClassTestCfg {

	[IFix]
    static IEnumerable<Type> hotfix
    {
        get
        {
            var lst = (from type in Assembly.Load("Assembly-CSharp").GetTypes() select type).ToList();
            return lst;     
            
            return new List<Type>()
            {
                // typeof(NewClassTest),
                // typeof(NewClassTest2),
                // typeof(NewClassTest3),

            };
        }
    }
}
