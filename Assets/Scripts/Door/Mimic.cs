using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class Mimic : MonoBehaviour
{  
    public float intensity;
    private PostProcessVolume volume;
    private Bloom bloom;
    private bool isPlaying = false;

    void Start()
    {
        this.bloom = ScriptableObject.CreateInstance<Bloom>();
        this.bloom.enabled.Override(true);
        this.bloom.intensity.Override(0.0f);
        this.bloom.threshold.Override(1.0f);
        this.bloom.diffusion.Override(10.0f);

        this.volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 0.0f, this.bloom);
    }

    void Update()
    {
        if (this.bloom)
        {
            this.volume.priority = this.intensity;
            this.bloom.intensity.value = this.intensity;
        }

        if (this.intensity > 10.0f && !this.isPlaying)
        {
            this.isPlaying = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
