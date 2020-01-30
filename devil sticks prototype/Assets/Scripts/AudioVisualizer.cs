using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VisualizationMode
{
    Ring,
    RingWithBeat
}

public class AudioVisualizer : MonoBehaviour
{
    //found from https://www.youtube.com/watch?v=BVhnmm1SvF0 - Audio Vizualization and Beat Detection in Unity by Dini Dev

    public int bufferSampleSize;
    public float samplePercentage;
    public float emphasisMultiplier;
    public float retractionSpeed;

    public int amountOfSegments;
    public float radius;
    public float bufferSizeArea;
    public float maximumExtendLength;

    public GameObject lineRendererPrefab;
    public Material lineRendererMaterial;
    public VisualizationMode visualizationMode;

    public Gradient colorGradientA = new Gradient();
    public Gradient colorGradientB = new Gradient();

    private Gradient currentColor = new Gradient();

    private float sampleRate;

    private float[] samples;
    private float[] spectrum;
    private float[] extendLengths;

    private LineRenderer[] lineRenderers;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sampleRate = AudioSettings.outputSampleRate;

        samples = new float[bufferSampleSize];
        spectrum = new float[bufferSampleSize];

        switch (visualizationMode)
        {
            case VisualizationMode.Ring:
                InitiateRing();
                break;
        }

    }

    private void InitiateRing()
    {
        extendLengths = new float[amountOfSegments + 1];
        lineRenderers = new LineRenderer[extendLengths.Length];

        for (int i = 0; i < lineRenderers.Length; i++)
        {
            GameObject go = Instantiate(lineRendererPrefab);
            go.transform.position = Vector3.zero;

            LineRenderer lineRenderer = go.GetComponent<LineRenderer>();
            lineRenderer.sharedMaterial = lineRendererMaterial;

            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderers[i] = lineRenderer;
        }
    }

    private void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        UpdateExtends();
        if(visualizationMode == VisualizationMode.Ring)
        {
            UpdateRing();
        }
           
    }

    private void UpdateExtends()
    {
        int iteration = 0;
        int indexOnSpectrum = 0;
        int averageValue = (int)Mathf.Abs(samples.Length * samplePercentage) / amountOfSegments;

        if(averageValue < 1)
        {
            averageValue = 1;
        }

        while (iteration < amountOfSegments)
        {
            int iterationIndex = 0;
            float sumValueY = 0;

            while (iterationIndex < averageValue)
            {
                sumValueY += spectrum[indexOnSpectrum];
                indexOnSpectrum++;
                iterationIndex++;
            }

            float y = sumValueY / averageValue * emphasisMultiplier;
            extendLengths[iteration] -= retractionSpeed * Time.deltaTime;

            if (extendLengths[iteration] < y)
            {
                extendLengths[iteration] = y;
            }

            if (extendLengths[iteration] > maximumExtendLength)
            {
                extendLengths[iteration] = maximumExtendLength;
            }
            iteration++;
        }
    }

    private void UpdateRing()
    {

    }

}
