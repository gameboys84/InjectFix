[TOC]



# InjectFix的作用

原始github地址： https://github.com/Tencent/InjectFix



## 特点

1. 纯C#开发和修改，不支持新特性，通常用于修复线上Bug用
2. 可以支持原地修改，新增类、字段、属性
3. 修复Bug的代码在C#中实现的虚拟机中运行，效率相对XLua来说会差一些



## 工程同步重点

1. 设置环境：UNITY_HOME，指向工程Unity安装目录
2. 进入Source\VSProj下，运行 build_for_unity.bat，在Windows上即可以为Android和iOS生成补丁文件
3. 拷贝Source\UnityProj\IFixToolKit下的文件到工程Tools下（同目录名IFixToolKit覆盖）
4. 拷贝Source\UnityProj\Assets\Plugins\IFix.Core.dll和meta到工程Plugins下（同dll名覆盖）
5. 拷贝Source\UnityProj\Assets\IFix下所有文件到工程Assets下（同目录名IFix覆盖）



# 配置标签： [Configure]、[IFix]和[IFilter]

## **[Configure]**

配置在 配置类上，表示此类是配置类，必须放在Editor目录下

## **[IFix]**

配置在配置类的属性上，表示此属性返回需要热修改的对象，此属性必须是静态类型，可以支持静态和动态指定需要热更新的对象

## **[IFilter]**

配置在 配置类的方法上，表示此方法返回热更新中需要过滤掉的类型（不需要热修复的类型）

```csharp
[Configure]
public class InterpertConfig {
    [IFix]
    static IEnumerable<Type> ToProcess
    {
        get
        {
            // return (from type in Assembly.Load("Assembly-CSharp").GetTypes() select type).ToList();
            return (from type in Assembly.Load("Assembly-CSharp").GetTypes()
                    where type.Namespace == "XLua" && !type.Name.Contains("<")
                    select type);
        }
    }
    
    [IFix.Filter]
    static bool Filter(System.Reflection.MethodInfo methodInfo)
    {
        return methodInfo.DeclaringType.FullName == "IFix.Test.Calculator" 
            && (methodInfo.Name == "Div" || methodInfo.Name == "Mult");
    }
}
```

 动态配置之后，后续该名字空间下的增删类，都不需要更改配置了。

配置好后，打包手机版本会自动预处理，如果希望自动化打包，可以手动调用`IFix.Editor.IFixEditor.InjectAllAssemblys`函数

 

# 热更新标签：[Patch]

对需要打补丁的函数加上[IFix.Patch]标签

```csharp
[IFix.Patch]
public int Add(int a, int b)
{
    return a + b;
}
```

 

修复完成后，执行`“InjectFix/Fix”`菜单，补丁会生成到工程目录下，默认的文件名为：***Assembly-CSharp.patch.bytes*** 和 ***Assembly-CSharp-firstpass.patch.bytes***

也可以为Android和iOS区分名字： `Assembly-CSharp_patch_android`和`Assembly-CSharp_patch_ios`

 

# 热更新新增模块标签：[Interpret]

新版本InjectFix还支持新增类和字段、属性，新增的类不能继承自MonoBehavior

- 如果新增类直接继承自MonoBehavior，在应用patch的时候，会报错

```
Exception: can not load type [NewClassTest3, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]
IFix.Core.PatchManager.Load (System.IO.Stream stream, System.Boolean checkNew) (at <2b76826291dc4de3ae25367702f81636>:0)
Helloworld.OnGUI () (at <f10ec22c45d0465d8300973964c3ce26>:0)
```

但可以间接实现相应功能，具体见下面流程：

- 基础MonoBehavior接口

```csharp
public interface IMonoBehaviour
{
    ...
    void Start();
    void Update();
    void OnDestroy();
    ...
}
```

- 间接继承

```csharp
public class VMMonoBehaviour : IMonoBehaviour
{
    public virtual void Start()
    {
    }
    
    public virtual void Update()
    {
    }
    
    public virtual void OnDestroy()
    {
    }
}
```

- 动态挂接

```csharp
        var go = new GameObject("VMMonoBehaviour");
        var behaviour = go.AddComponent(typeof(VMBehaviourScript)) as VMBehaviourScript;
        behaviour.VMMonoBehaviour = new VMMonoBehaviour();
```

 

