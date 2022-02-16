using System;
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

    [Fact]
    public void fixme()
    {
        true.Should().BeFalse();
    }

    private static string[] Search(string searchText)
    {
        throw new NotImplementedException();
    }
}