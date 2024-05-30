using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNNUtils
{
    public class BnnUtils
    {
        public static Vector3 CalculateDistance(Transform a, Transform b)
        {
            return a.position - b.position.normalized;
        }

        public static GameObject GetMasterParent(GameObject obj)
        {
            Transform currentParent = obj.transform;

            while (currentParent.parent != null)
            {
                currentParent = currentParent.parent;
            }

            return currentParent.gameObject;
        }
    }
}
