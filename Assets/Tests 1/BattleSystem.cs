using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BattleSystem
{
    private CharacterControllerScript character;
    GameObject gameGameObject;

    [SetUp]
    public void Setup()
    {
        gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Battle"));
        character = gameGameObject.GetComponentInChildren<CharacterControllerScript>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(gameGameObject.gameObject);
    }

    [UnityTest]
    public IEnumerator TakeAndDealDMG()
    {
        var Enemies = gameGameObject.GetComponentsInChildren<Enemy>();
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(Enemies.Length, 2);
        Enemies[0].health = 30;
        Enemies[0].TakeDamage(15);
        Assert.AreEqual(Enemies[0].health, 15);
        Enemies[1].dmg = 5;
        character.hp = 7;
        Enemies[1].OnEnemyAttack();
        Assert.AreEqual(character.hp, 2);
    }

    [UnityTest]
    public IEnumerator Flip()
    {
        var enemy = gameGameObject.GetComponentInChildren<Enemy>();
        var Facing = enemy.isFacingRight;
        var theScale = enemy.transform.localScale.x;
        enemy.Flip();
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(enemy.isFacingRight, !Facing);
        Assert.AreEqual(theScale, -enemy.transform.localScale.x);

    }
}
