using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public static float[] _frequencyBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];
    float[] _freqBandAmplitude = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumDataFromAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
    }

    private void CreateAudioBands()
    {
        for(int i = 0; i < 8; i++)
        {
            if (_frequencyBand[i] > _freqBandAmplitude[i])
            {
                _freqBandAmplitude[i] = _frequencyBand[i];
            }
            _audioBand[i] = (_frequencyBand[i] / _freqBandAmplitude[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandAmplitude[i]);
        }
    }

    private void BandBuffer()
    {
        for(int g = 0; g < 8; g++)
        {
            if(_frequencyBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _frequencyBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            if (_frequencyBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    private void GetSpectrumDataFromAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
    private void MakeFrequencyBands()
    {
        int count = 0;
        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7) sampleCount += 2;
            for(int j = 0; j < sampleCount; j++)
            {
                average += _samples[count]*(count+1);
                count++;
            }

            average /= count;

            _frequencyBand[i] = average*10;
        }
    }
}
