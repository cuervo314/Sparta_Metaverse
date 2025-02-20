using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    private Camera camera;
    private GameManager gameManager;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        camera = Camera.main;
    }

    private void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnLook(InputValue inputValue)
    {
        lookDirection = inputValue.Get<Vector2>();
        lookDirection = lookDirection.normalized;

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            GameObject canvas = collision.gameObject.GetComponentInChildren<Canvas>(true).gameObject;
            canvas.SetActive(true);
        }

        if(collision.gameObject.CompareTag("FlappyPlane"))
        {
            SceneManager.LoadScene("FlappyPlane");
        }

        if (collision.gameObject.CompareTag("BombDodge"))
        {
            SceneManager.LoadScene("BombDodge");
        }

        if (collision.gameObject.CompareTag("BreakOut"))
        {
            SceneManager.LoadScene("BreakOut");
        }

        if (collision.gameObject.CompareTag("TopDown"))
        {
            SceneManager.LoadScene("TopDown");
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            GameObject canvas = collision.gameObject.GetComponentInChildren<Canvas>(true).gameObject;
            canvas.SetActive(false);
        }
    }
}
