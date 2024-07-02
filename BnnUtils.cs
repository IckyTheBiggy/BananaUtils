using System.Collections;
using System.Collections.Generic;
using System.Text;
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

        public static string GenerateRandomID(int length)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int id = Random.Range(0, 9);
                builder.Append(id);
            }

            return builder.ToString();
        }
    }
}
