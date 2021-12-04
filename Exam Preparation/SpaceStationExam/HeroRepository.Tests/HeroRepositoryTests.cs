using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository HeroRepository;

    [SetUp]
    [Test]
    public void Setup()
    {
        HeroRepository = new HeroRepository();
    }

    [Test]
    public void CtorTest()
    {
        Assert.IsNotNull(HeroRepository.Heroes);
    }

    [Test]
    public void Create()
    {
        hero = new Hero("Pesho", 10);
        HeroRepository.Create(hero);
        Assert.That(HeroRepository.Heroes.Count, Is.EqualTo(1));
    }

    [Test]
    public void CreateMessageTest()
    {
        hero = new Hero("Pesho", 10);
        string message = HeroRepository.Create(hero);
        Assert.AreEqual(message, "Successfully added hero Pesho with level 10");
    }

    [Test]
    public void CreateNullThrowsExeption()
    {
        hero = null;
        Assert.That(() => HeroRepository.Create(hero), Throws.ArgumentNullException);
    }

    [Test]
    public void CreateSameNameThrowsExeption()
    {
        hero = new Hero("Pesho", 10);
        HeroRepository.Create(hero);
        Assert.That(() => HeroRepository.Create(hero), Throws.InvalidOperationException);
    }

    [Test]
    public void RemoveHero()
    {
        hero = new Hero("Pesho", 10);
        HeroRepository.Create(hero);
        Assert.That(HeroRepository.Remove("Pesho"), Is.EqualTo(true));
    }

    [Test]
    public void RemoveThrowsExeptionForEmtyName()
    {
        hero = new Hero("Pesho", 10);
        HeroRepository.Create(hero);
        Assert.Throws<ArgumentNullException>(() => HeroRepository.Remove(" "));
    }

    [Test]
    public void GetHighesLevelHero()
    {
        hero = new Hero("Pesho", 10);
        HeroRepository.Create(hero);
        Assert.AreEqual(HeroRepository.GetHeroWithHighestLevel(), hero);
    }

    [Test]
    public void GetHero()
    {
        hero = new Hero("Pesho", 10);
        HeroRepository.Create(hero);
        Assert.AreEqual(HeroRepository.GetHero("Pesho"), hero);
    }
}