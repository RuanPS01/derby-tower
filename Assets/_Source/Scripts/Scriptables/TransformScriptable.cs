using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectTransform", menuName = "Scriptables/Transform")]
public class TransformScriptable : ScriptableObject
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
}
