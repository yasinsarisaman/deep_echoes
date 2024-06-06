using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace DeepEchoes.Scripts
{
    [RequireComponent(typeof(Light))]
    public class FadeLight : MonoBehaviour
    {
        [SerializeField] private float delayFadeTime;
        [SerializeField] private float fadeTime;

        private Light _light;
        
        private void Awake()
        {
            _light = GetComponent<Light>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(delayFadeTime);
            DOTween.To(()=> _light.intensity, x=> _light.intensity = x, 0, fadeTime);
        }
        
        
    }
}