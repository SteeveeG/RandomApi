using NUnit.Framework.Constraints;
using RandomApi.ApiCalls;
using RandomApi.Models;

namespace RandomApiUnitTest;

public class Api
{
    private ApiCalls ApiCalls { get; set; }

    [SetUp]
    public void Setup()
    {
        ApiCalls = new ApiCalls();
        ApiCalls.Init();
    }

    [Test]
    public async Task GoogleBooksApiCall_ReturnWithRandomBook()
    {
        //Act 
        var response = await ApiCalls.GoogleBooks();

        //Assert
        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task CatFactsCall_ReturnWithRandomCatFact()
    {
        //Act 
        var response = await ApiCalls.CatFacts();

        //Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.Empty);
    }

    [Test]
    public async Task AnimeQuotesCall_ReturnWithRandomAnimeQuote()
    {
        //Act 
        var response = await ApiCalls.AnimeQuote();

        //Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response.data.content, Is.Not.Empty);
    }


    [Test]
    public async Task AnimeRecommendationCall_ReturnWithRandomAnimeRecommendation()
    {
        //Act 
        var response = await ApiCalls.AnimeRecommendation();

        //Assert
        Assert.That(response, Is.Not.Null);
    }


    [Test]
    public async Task RandomDukCall_ReturnWithRandomDukImg()
    {
        //Act 
        var response = await ApiCalls.RandomDuk();

        //Assert
        Assert.That(response, Is.Not.Null);
    }


    [Test]
    public async Task RandomFoxCall_ReturnWithRandomFoxImg()
    {
        //Act 
        var response = await ApiCalls.RandomFox();

        //Assert
        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task RandomNoiseColor_ReturnWithRandomNoiseColorImg()
    {
        //Act 
        var response = await ApiCalls.RandomNoiseColor();

        //Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.Empty);
    }

    [Test]
    public async Task WaifuPics_ReturnWithRandomWaifuPicsImg()
    {
        //Act 
        var response = await ApiCalls.WaifuPics();

        //Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.Not.Empty);
    }

    [Test]
    public async Task RandomArtWork_ReturnsWithRandomArtworkImg()
    {
        //Act 
        var response = await ApiCalls.RandomArtWork();

        //Assert
        Assert.That(response, Is.Not.Null);
    }
}