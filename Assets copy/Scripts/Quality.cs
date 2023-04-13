using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quality : MonoBehaviour
{
    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
}
