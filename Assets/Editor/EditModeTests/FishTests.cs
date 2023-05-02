using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class FishTest
{

    private Fish fish;

    [SetUp]
    public void Setup()
    {
        GameObject fishGameObject = new GameObject();
        fish = fishGameObject.AddComponent<Fish>();
    }

    [Test]
    public void setDateTest()
    {
        // Arrange
        var fish = new Fish();

        // Act
        fish.setDate();

        // Assert
        var expectedDate = System.DateTime.UtcNow.ToLocalTime().ToString("MM/dd/yy");
        Assert.AreEqual(expectedDate, fish.dateObtained);
    }

    [Test]
    public void SetFishPos_FishIsRandomlyPositioned()
    {
        fish.setFishPos();
        Vector3 pos = fish.transform.position;
        Assert.That(pos.x, Is.EqualTo(-1).Or.EqualTo(1));
        Assert.That(pos.y, Is.GreaterThanOrEqualTo(-1).And.LessThanOrEqualTo(1));
    }

}