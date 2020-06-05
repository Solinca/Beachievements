using UnityEngine;

public class EnnemyCollision : MonoBehaviour
{
    public Transform respawn;
    public Transform player;
    public GameObject[] instructions;
    
    private int currentInstructionIndex = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ennemy"))
        {
            ManageEnnemy(collision.gameObject);
        }
    }

    public void ManageEnnemy(GameObject ennemy)
    {
        if (ennemy.name == "InstructionCrab" && currentInstructionIndex < instructions.Length - 1)
        {
            ChangeText();

            if (currentInstructionIndex == instructions.Length - 1)
            {
                DestroyInstructionCrab(ennemy);
            } else
            {
                RepositionPlayer();
            }
        } else
        {
            RepositionPlayer();
        }
    }

    private void RepositionPlayer()
    {
        player.position = respawn.position;
    }

    private void ChangeText()
    {
        instructions[currentInstructionIndex].SetActive(false);
        instructions[++currentInstructionIndex].SetActive(true);
    }

    private void DestroyInstructionCrab(GameObject instructionCrab)
    {
        instructionCrab.SetActive(false);
        AchievementManager.Instance.CollectAchievement("CrabFight");
    }
}
