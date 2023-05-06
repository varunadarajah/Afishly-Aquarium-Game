using NUnit.Framework;
using UnityEngine;

public class LevelUpClamScriptTests
{
    private LevelUpClamScript levelUpClamScript;
    private Game game;
    private Clam clamUpgrade;

    [SetUp]
    public void Setup()
    {
        // Create a new instance of LevelUpClamScript, Game and Clam for each test
        levelUpClamScript = new GameObject().AddComponent<LevelUpClamScript>();
        game = new GameObject().AddComponent<Game>();
        clamUpgrade = new GameObject().AddComponent<Clam>();

        // Set game and clamUpgrade for levelUpClamScript
        levelUpClamScript.game = game;
        levelUpClamScript.clamUpgrade = clamUpgrade;

        // Set initial values
        levelUpClamScript.currentLevel = 1;
        levelUpClamScript.accessLevel2 = true;
        levelUpClamScript.accessLevel3 = true;
        levelUpClamScript.accessLevel4 = true;
        levelUpClamScript.clamLevelText = new GameObject().AddComponent<TMPro.TMP_Text>();
        levelUpClamScript.clamLevelDescription = new GameObject().AddComponent<TMPro.TMP_Text>();
        levelUpClamScript.clamUpgradeValue = new GameObject().AddComponent<TMPro.TMP_Text>();
    }

    [Test]
    public void IncreaseLevel_IncreasesCurrentLevelByOne()
    {
        // Arrange
        int expectedLevel = levelUpClamScript.currentLevel + 1;

        // Act
        levelUpClamScript.IncreaseLevel();

        // Assert
        Assert.AreEqual(expectedLevel, levelUpClamScript.currentLevel);
    }

    [Test]
    public void PurchaseLevel2_ReturnsFalse_WhenNotEnoughPearls()
    {
        // Arrange
        int initialPearls = 0;
        game.pearls = initialPearls;
        levelUpClamScript.currentLevel = 1;

        // Act
        bool result = levelUpClamScript.purchaseLevel2();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void PurchaseLevel3_ReturnsFalse_WhenNotEnoughPearls()
    {
        // Arrange
        int initialPearls = 0;
        game.pearls = initialPearls;
        levelUpClamScript.currentLevel = 2;

        // Act
        bool result = levelUpClamScript.purchaseLevel3();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void PurchaseLevel4_ReturnsFalse_WhenNotEnoughPearls()
    {
        // Arrange
        int initialPearls = 0;
        game.pearls = initialPearls;
        levelUpClamScript.currentLevel = 3;

        // Act
        bool result = levelUpClamScript.purchaseLevel4();

        // Assert
        Assert.IsFalse(result);
    }

}