using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CharacterTests
{
    private CharacterControllerScript character;
    GameObject gameGameObject;

    [SetUp]
    public void Setup()
    {
        gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        character = gameGameObject.GetComponentInChildren<CharacterControllerScript>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(gameGameObject.gameObject);
    }

    [UnityTest]
    public IEnumerator Coins()
    {
        character.coins = 100;
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(character.coins, 100);
        Assert.AreEqual(character.moneycount.text, "100");
        
    }

    [UnityTest]
    public IEnumerator IsGrounded()
    {
        
        Assert.IsTrue(character.isGrounded);
        character.transform.position = new Vector3(character.transform.position.x + 1000, character.transform.position.y + 1000, character.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(character.isGrounded);
        
    }

    [UnityTest]
    public IEnumerator Hp()
    {
        character.maxhp = 15;
        
        Assert.AreEqual(character.hp, 16);
        Assert.AreEqual(character.maxhp, 15);
        yield return new WaitForSeconds(0.1f);

    }

    [UnityTest]
    public IEnumerator BuySmth()
    {
        character.maxhp = 15;
        character.coins = 100;
        character.dmg = 2;
        character.BuyDmgBuff();
        Assert.AreEqual(character.dmg, 3);
        Assert.AreEqual(character.coins, 0);
        character.BuyHpBuff();
        Assert.AreEqual(character.maxhp, 15);
        Assert.AreEqual(character.coins, 0);
        character.coins += 100;
        character.BuyHpBuff();
        Assert.AreEqual(character.hp, 16);
        Assert.AreEqual(character.coins, 0);
        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator FlipTest()
    {
        var Facing = character.isFacingRight;
        var theScale = character.transform.localScale.x;
        character.Flip();
        Assert.AreEqual(character.isFacingRight, !Facing);
        Assert.AreEqual(theScale, -character.transform.localScale.x);
        yield return new WaitForSeconds(0.1f);
    }

}