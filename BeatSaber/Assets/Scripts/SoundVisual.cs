﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisual : MonoBehaviour
{
    private const int SAMPLE_SIZE = 1024;

    public float rsmValue;
    public float dbValue;
    public float pitchValue;

    public float maxVisualScale = 25.0f;
    public float visualModifier = 50.0f;
    public float smoothSpeed = 10.0f;
    public float keepPercentage = 0.5f;

    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;

    private Transform[] visualList;
    private float[] visualScale;
    public int amnVisual = 64;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;
        //draw the circle
        SpawnCircle();
    }

    private void SpawnCircle()
    {
        visualScale = new float[amnVisual];
        visualList = new Transform[amnVisual];

        Vector3 center = Vector3.zero;
        //circul radius draw
        float radius = 10.0f;

        for (int i = 0; i < amnVisual; i++)
        {
            float ang = i * 1.0f / amnVisual;
            ang = ang * Mathf.PI * 2;

            float x = center.x + Mathf.Cos(ang) * radius;
            float y = center.y + Mathf.Sin(ang) * radius;

            Vector3 pos = center + new Vector3(x, y, 25);
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            go.transform.position = pos;
            go.transform.rotation = Quaternion.LookRotation(Vector3.forward, pos);
            visualList[i] = go.transform;
        }

    }

    private void Update()
    {
        AnalyzeSound();
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int)((SAMPLE_SIZE * keepPercentage) / amnVisual);

        while (visualIndex < amnVisual)
        {
            int j = 0;
            float sum = 0;
            while (j < averageSize)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * visualModifier;
            visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;
            if (visualScale[visualIndex] < scaleY)
            {
                visualScale[visualIndex] = scaleY;
            }
            if (visualScale[visualIndex] > maxVisualScale)
            {
                visualScale[visualIndex] = maxVisualScale;
            }
            visualList[visualIndex].localScale = Vector3.one + Vector3.up * visualScale[visualIndex];
            visualIndex++;
        }

    }
    private void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);

        //Get RSM value
        int i = 0;
        float sum = 0;
        for (; i < SAMPLE_SIZE; i++)
        {
            sum += samples[i] * samples[i];
        }

        rsmValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //Get DB value
        dbValue = 20 * Mathf.Log10(rsmValue / 0.1f);

        //Get sound spectrum
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        //Find Pitch
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < SAMPLE_SIZE; i++)
        {
            //change!!!!!!!!
            if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
            {
                continue;
            }
            maxV = spectrum[i];
            maxN = i;
        }

        float freqN = maxN;
        if (maxN > 0 && maxN < SAMPLE_SIZE - 1)
        {
            var dl = spectrum[maxN - 1] / spectrum[maxN];
            var dr = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dr * dr - dl * dl);
        }
        pitchValue = freqN * (sampleRate / 2) / SAMPLE_SIZE;
    }
}