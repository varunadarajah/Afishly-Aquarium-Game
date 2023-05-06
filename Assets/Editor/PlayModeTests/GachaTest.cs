using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class GachaTest
{
    private Game game;
    private GachaManager gachaManager;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/HomeScreen.unity", LoadSceneMode.Single);
        Scene s = SceneManager.GetActiveScene();

        GameObject[] objList = s.GetRootGameObjects();

        foreach(GameObject obj in objList)
        {
            Debug.Log(obj.name);
            if(obj.name == "GameEngine")
            {
                game = obj.GetComponent<Game>();
            }

            if(obj.name == "Gacha")
            {
                gachaManager = obj.GetComponent<GachaManager>();
            }
        }
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator GachaTestSimplePasses()
    {
        yield return new WaitForSeconds(2f);
        // set pearls to 10
        game.pearls = 10;

        int expectedValue = game.pearls - gachaManager.selectedBox.cost;

        // attempt to buy box
        gachaManager.buyBox();

        Assert.Equals(game.pearls, expectedValue);
    }
}
