using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggManager : MonoBehaviour
{
    public GameObject hammer;
    public CameraShake shaker;
    private bool used = false;
    void Update()
    {
        if (used) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(hammer, new Vector3(34, 14, 56), Quaternion.identity);
            StartCoroutine(ShakeCamera());
            used = true;
        }
    }
    private IEnumerator ShakeCamera()
    {
        yield return new WaitForSeconds(1f);
        shaker.StartCoroutine(shaker.Shake(0.35f, 0.04f));
        yield return null;
    }
}
