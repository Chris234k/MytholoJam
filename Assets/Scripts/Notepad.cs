using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Notepad : ScriptableObject
{
    [Multiline(50)]
    public string notes;
}
