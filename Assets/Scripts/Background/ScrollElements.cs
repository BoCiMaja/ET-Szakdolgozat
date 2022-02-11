using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollElements : Scroll
{
    private IEnumerable<GameObject> children;

    //public void SetChildrenElements(ref IEnumerable<GameObject> collection)
    //{
    //    children = collection;
    //}

    public void SetChildrenElements(Queue<GameObject> collection)
    {
        children = collection;
    }

    protected override void Scrolling()
    {
        foreach (GameObject child in children)
        {
            child.transform.position = new Vector3(
                child.transform.position.x - diffX,
                child.transform.position.y,
                child.transform.position.z);
        }
    }
}
