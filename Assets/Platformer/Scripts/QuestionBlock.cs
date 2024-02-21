using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour, InteractableBlock
{
    private void Start()
    {
        StartCoroutine(CycleTexture());
    }


    private void OnCollisionEnter(Collision collision)
    {
        OnHit();
    }
    public void OnHit()
    {
        //Debug.Log("? Block hit!");
        AddCoin();
        SpawnCoin();
        Destroy(gameObject);
    }

    public void AddCoin()
    {
        GameManager.instance.AddCoin();
    }

    private void SpawnCoin()
    {
        Instantiate(LevelResources.instance.GetCoin(), transform.position, Quaternion.identity, LevelResources.instance.transform);
    }

    private IEnumerator CycleTexture()
    {
        // TODO: Cycle through the 5 textures one way, then back. 
        float offsetAmount = 0.2f;
        float currentOffset = 0f;
        float cycleSpeed = 0.1f;
        var material = GetComponent<MeshRenderer>().material;
        while(true)
        {
            Vector2 offset = new Vector2(0, currentOffset);
            material.mainTextureOffset = offset;
            currentOffset = (currentOffset + offsetAmount) % 1;
            yield return new WaitForSeconds(cycleSpeed);

        }
        // TODO: Pause for a split second, then cycle through again.
    }

}
