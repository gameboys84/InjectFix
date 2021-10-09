using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IMonoBehaviour
{
    void Start();//简单demo，只定义了Start方法，实际Awake，Update，OnDestroy。。。都类似

    void Update();
}

public class VMBehaviourScript : MonoBehaviour
{
    public IMonoBehaviour VMMonoBehaviour { get;set; }

    void Start()
    {
        if (VMMonoBehaviour != null)
        {
            VMMonoBehaviour.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (VMMonoBehaviour != null)
        {
            VMMonoBehaviour.Update();
        }
    }
}
