using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbarController : MonoBehaviour
{
    public Image foregroundImage;
    public float updateSpeedSeconds;

    private void Awake()
    {
        GetComponentInParent<EnemyScript>().UpdateHealthBar += UpdateHealthbar;
    }

    private void UpdateHealthbar(float pct)
    {
        // using a coroutine to smooth the change of health
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        // cache the current image health
        float preChangePct = foregroundImage.fillAmount;

        // store the time passed
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;
    }

    private void LateUpdate()
    {
        // makes the healthbar face the camera
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
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
