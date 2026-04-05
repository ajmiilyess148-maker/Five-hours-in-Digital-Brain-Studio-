using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float energy = 100f;
    public float crawlSpeed = 2f;
    private bool isCrawling = false;

    void Update()
    {
        Move();
        HandleCrawling();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (isCrawling)
        {
            transform.Translate(movement * crawlSpeed * Time.deltaTime);
            energy -= 1f * Time.deltaTime; // Energy consumption while crawling
        }
        else
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
        // Regenerate energy
        if (energy < 100f)
        {
            energy += 0.5f * Time.deltaTime;
        }
    }

    void HandleCrawling()
    {
        if (Input.GetKeyDown(KeyCode.C) && energy > 0)
        {
            isCrawling = !isCrawling;
        }
    }
}