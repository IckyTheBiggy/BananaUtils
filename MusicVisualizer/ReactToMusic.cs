using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public List<GameObject> visualizerObjects;
    public List<Range> frequencyRanges;
    public float scaleMultiplier = 10f;

    [System.Serializable]
    public struct Range
    {
        public int start;
        public int end;
    }

    void Update()
    {
        float[] spectrumData = new float[256];
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        for (int i = 0; i < visualizerObjects.Count; i++)
        {
            float intensity = 0;

            for (int j = frequencyRanges[i].start; j <= frequencyRanges[i].end; j++)
            {
                intensity += spectrumData[j];
            }

            Vector3 newScale = visualizerObjects[i].transform.localScale;
            newScale.y = intensity * scaleMultiplier;
            visualizerObjects[i].transform.localScale = newScale;
        }
    }
}
