using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDescription : MonoBehaviour
{
    [SerializeField]
    GameObject ItemGO;
    [SerializeField]
    TMP_Text ItemText;
    public float fadeDuration = 2.0f;
    
    public async void Play(ItemSO itemSO)
    {
        ItemText.text = itemSO.ItemDescription.Replace("\\n","\u000a");
        ItemGO.SetActive(true);
        StartCoroutine(FadeOutText());
    }
    private IEnumerator FadeOutText()
    {
        Color originalColor = ItemText.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            ItemText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            
            yield return null;
        }

        ItemText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        
        ItemGO.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
