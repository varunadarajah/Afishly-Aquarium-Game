using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

public class GachaTests
{
    private Game game;
    private GachaManager gachaManager;

    [SetUp]
    public void Setup()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/HomeScreen.unity");
        game = GameObject.Find("GameEngine").GetComponent<Game>();
        gachaManager = GameObject.Find("Gacha").GetComponent<GachaManager>();


        gachaManager.selectedBox = GameObject.Find("VanillaBox").GetComponent<GachaBox>();
        gachaManager.selectedBox.fishRarity.Add(0);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void GachaBuyBoxWithoutEnoughPearls()
    {
        // set pearls to 10
        game.pearls = 10;

        // attempt to buy box
        gachaManager.buyBox();

        // assert that pearl value stays the same
        Assert.AreEqual(game.pearls, 10);

    }

    [Test]
    public void GachaBuyBoxWithEnoughPearls()
    {
        // set pearls to 10
        game.pearls = 50000;

        int expectedValue = game.pearls - gachaManager.selectedBox.cost;

        // attempt to buy box
        gachaManager.buyBox();

        Assert.AreEqual(game.pearls, expectedValue);

    }
}
