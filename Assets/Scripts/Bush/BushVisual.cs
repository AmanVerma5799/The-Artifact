using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] bushSprites, fruitSprites, drySprite;
    [SerializeField] private SpriteRenderer[] fruitRenderers;

    public enum BushVariant {Green, Cyan, Yellow};
    private BushVariant bushVariant;

    public float hideTimeFruit = 0.2f;

    private SpriteRenderer bushRenderer;

    void Awake()
    {
        bushRenderer = GetComponent<SpriteRenderer>();

        bushVariant = (BushVariant)Random.Range(0, bushSprites.Length);
        bushRenderer.sprite = bushSprites[(int)bushVariant];

        if(Random.Range(0, 2) == 1)
        {
            bushRenderer.flipX = true;
        }

        for(int i = 0; i < fruitRenderers.Length; i++)
        {
            fruitRenderers[i].sprite = fruitSprites[(int)bushVariant];
            fruitRenderers[i].enabled = false;
        }

    }

    public BushVariant GetBushVariant()
    {
        return bushVariant;
    }

    public void SetToDry()
    {
        bushRenderer.sprite = drySprite[(int)bushVariant];
    }

    IEnumerator HideFruitsTimer(float time, int index)
    {
        yield return new WaitForSeconds(time);
        fruitRenderers[index].enabled = false;
    }

    public void HideFruits()
    {
        float waitTimeForFruits = hideTimeFruit;

        for(int i = 0; i < fruitRenderers.Length; i++)
        {
            StartCoroutine(HideFruitsTimer(waitTimeForFruits, i));
            waitTimeForFruits += hideTimeFruit; 
        }
    }

    public void ShowFruits()
    {
        for(int i = 0; i < fruitRenderers.Length; i++)
        {
            fruitRenderers[i].enabled = true;
        }
    }
}
