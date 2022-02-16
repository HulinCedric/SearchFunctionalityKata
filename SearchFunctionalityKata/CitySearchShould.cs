using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace SearchFunctionalityKata;

public class CitySearchShould
{
    private static readonly string[] Cities =
    {
        "Paris",
        "Budapest",
        "Skopje",
        "Rotterdam",
        "Valencia",
        "Vancouver",
        "Amsterdam",
        "Vienna",
        "Sydney",
        "New York City",
        "London",
        "Bangkok",
        "Hong Kong",
        "Dubai",
        "Rome",
        "Istanbul"
    };

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("P")]
    [InlineData("V")]
    public void Return_no_results_when_search_text_is_fewer_than_2_characters(string searchText)
        => Search(searchText)
            .Should()
            .BeEmpty();

    [Theory]
    [InlineData("Pa", new[] { "Paris" })]
    [InlineData("Va", new[] { "Valencia", "Vancouver" })]
    public void Return_cities_starting_with_the_exact_search_text(
        string searchText,
        string[] expectedResult)
        => Search(searchText)
            .Should()
            .BeEquivalentTo(expectedResult);

    [Theory]
    [InlineData("pa", new[] { "Paris" })]
    [InlineData("va", new[] { "Valencia", "Vancouver" })]
    public void Return_cities_starting_with_the_search_text_without_take_care_of_case(
        string searchText,
        string[] expectedResult)
        => Search(searchText)
            .Should()
            .BeEquivalentTo(expectedResult);

    [Theory]
    [InlineData("ape", new[] { "Budapest" })]
    [InlineData("on", new[] { "London", "Hong Kong" })]
    public void Return_cities_containing_the_search_text(
        string searchText,
        string[] expectedResult)
        => Search(searchText)
            .Should()
            .BeEquivalentTo(expectedResult);

    [Fact]
    public void Return_all_cities_when_search_text_is_an_asterisk()
        => Search("*")
            .Should()
            .BeEquivalentTo(Cities);

    private static string[] Search(string searchText)
    {
        if (searchText == "*")
            return Cities;

        if (searchText is null ||
            searchText.Length < 2)
            return Array.Empty<string>();

        return Cities
            .Where(
                city => city
                    .Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }
}