using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactHealthUI : MonoBehaviour
{
    [SerializeField] private Slider artifactHealthBar;
    [SerializeField] private Artifact artifact;

    void Start()
    {
        artifactHealthBar.maxValue = artifact.maxHealth;
        artifactHealthBar.value = artifact.maxHealth;
    }


    void Update()
    {
        artifactHealthBar.value = artifact.health;
    }
}
