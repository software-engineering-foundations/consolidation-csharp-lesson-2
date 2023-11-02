using FluentAssertions;
using Lesson2.Enums;

namespace Lesson2.Test;

public class TestChallenges
{
    [Theory]
    [InlineData(
        "dog",
        "Spot",
        "Unbelievable! We have your ideal pet. This dog over here is called Spot."
    )]
    [InlineData(
        "cat",
        "Fluffy",
        "Unbelievable! We have your ideal pet. This cat over here is called Fluffy."
    )]
    public void MagicPetShop_Called_OutputsExpectedResponse(
        string animalType,
        string animalName,
        string expectedOutput
    )
    {
        // Arrange
        var stringReader = new StringReader($"{animalType}\n{animalName}\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);

        // Act
        Challenges.MagicPetShop();

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        outputLines.Length.Should().Be(3);
        outputLines[2].Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("0", "0", "Thank you, that will be 0.00.")]
    [InlineData("3", "4", "Thank you, that will be 25.65.")]
    [InlineData("2", "10", "Thank you, that will be 42.40.")]
    public void PlaceSundriesOrder_Called_OutputsExpectedResponse(
        string riceBowlCount,
        string naanBreadCount,
        string expectedOutput
    )
    {
        // Arrange
        var stringReader = new StringReader($"{riceBowlCount}\n{naanBreadCount}\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);

        // Act
        Challenges.PlaceSundriesOrder();

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        outputLines.Length.Should().Be(3);
        outputLines[2].Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("20", "No need for a coat, go as you are.")]
    [InlineData("15", "No need for a coat, go as you are.")]
    [InlineData("-1", "You should take a coat with you when you go out.")]
    public void ShouldTakeCoat_Called_OutputsExpectedResponse(
        string temperature,
        string expectedOutput
    )
    {
        // Arrange
        var stringReader = new StringReader($"{temperature}\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);

        // Act
        Challenges.ShouldTakeCoat();

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        outputLines.Length.Should().Be(2);
        outputLines[1].Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("yes", "city", "You should take an umbrella with you when you go out.")]
    [InlineData("yes", "countryside", "You should take a coat with you when you go out.")]
    [InlineData(
        "yes",
        "suburbs",
        "I'm not sure whether you should take an umbrella or a coat with you."
    )]
    [InlineData("no", null, "No need for an umbrella or a coat, go as you are.")]
    [InlineData("maybe", null, "Sorry, I didn't understand your response.")]
    public void ShouldTakeUmbrellaOrCoat_Called_OutputsExpectedResponse(
        string isRainingResponse,
        string? cityOrCountrysideResponse,
        string expectedOutput
    )
    {
        // Arrange
        var stringReader = new StringReader($"{isRainingResponse}\n{cityOrCountrysideResponse}\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);

        // Act
        Challenges.ShouldTakeUmbrellaOrCoat();

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (isRainingResponse == "yes")
        {
            outputLines.Length.Should().Be(3);
            outputLines[2].Should().Be(expectedOutput);
        }
        else
        {
            outputLines.Length.Should().Be(2);
            outputLines[1].Should().Be(expectedOutput);
        }
    }

    [Theory]
    [InlineData(32.0, 0.0)]
    [InlineData(0.0, -160.0 / 9.0)]
    [InlineData(86.0, 30.0)]
    public void FahrenheitToCelsius_CalledWithFahrenheitTemperature_ReturnsExpectedCelsiusTemperature(
        double fahrenheitTemperature,
        double expectedCelsiusTemperature
    )
    {
        // Act
        var celsiusTemperature = Challenges.FahrenheitToCelsius(fahrenheitTemperature);

        // Assert
        celsiusTemperature.Should().BeApproximately(expectedCelsiusTemperature, double.Epsilon);
    }

    [Theory]
    [InlineData(2, 120)]
    [InlineData(3, 160)]
    [InlineData(5, 280)]
    [InlineData(7, 370)]
    [InlineData(8, 430)]
    public void CalculateCarHireCost_CalledWithDayCount_ReturnsExpectedCost(
        int dayCount,
        int expectedCost
    )
    {
        // Act
        var cost = Challenges.CalculateCarHireCost(dayCount);

        // Assert
        cost.Should().Be(expectedCost);
    }

    [Theory]
    [InlineData(0, 0, 0, 0)]
    [InlineData(2, 10, 38, 7838000)]
    [InlineData(6, 21, 55, 22915000)]
    public void CalculateMilliseconds(int hours, int minutes, int seconds, int expectedMilliseconds)
    {
        // Act
        var milliseconds = Challenges.CalculateMilliseconds(hours, minutes, seconds);

        // Assert
        milliseconds.Should().Be(expectedMilliseconds);
    }

    [Theory]
    [InlineData(RockPaperScissorsMove.Rock, RockPaperScissorsMove.Rock, "It's a draw.")]
    [InlineData(RockPaperScissorsMove.Rock, RockPaperScissorsMove.Paper, "Player 2 wins!")]
    [InlineData(RockPaperScissorsMove.Rock, RockPaperScissorsMove.Scissors, "Player 1 wins!")]
    [InlineData(RockPaperScissorsMove.Paper, RockPaperScissorsMove.Rock, "Player 1 wins!")]
    [InlineData(RockPaperScissorsMove.Paper, RockPaperScissorsMove.Paper, "It's a draw.")]
    [InlineData(RockPaperScissorsMove.Paper, RockPaperScissorsMove.Scissors, "Player 2 wins!")]
    [InlineData(RockPaperScissorsMove.Scissors, RockPaperScissorsMove.Rock, "Player 2 wins!")]
    [InlineData(RockPaperScissorsMove.Scissors, RockPaperScissorsMove.Paper, "Player 1 wins!")]
    [InlineData(RockPaperScissorsMove.Scissors, RockPaperScissorsMove.Scissors, "It's a draw.")]
    public void FindRockPaperScissorsWinner_CalledWithPlayerMoves_OutputsExpectedResponse(
        RockPaperScissorsMove player1Move,
        RockPaperScissorsMove player2Move,
        string expectedOutput
    )
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Challenges.FindRockPaperScissorsWinner(player1Move, player2Move);

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        outputLines.Length.Should().Be(1);
        outputLines[0].Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData(new int[] { }, null)]
    [InlineData(new[] { 70 }, CourseGrade.C)]
    [InlineData(new[] { 41, 68 }, CourseGrade.E)]
    [InlineData(new[] { 10, 40, 60 }, CourseGrade.F)]
    [InlineData(new[] { 99, 82, 91, 93 }, CourseGrade.A)]
    [InlineData(new[] { 51, 47, 72, 70, 65 }, CourseGrade.D)]
    [InlineData(new[] { 90, 94, 67, 68, 85, 81 }, CourseGrade.B)]
    public void CalculateCourseGrade_CalledWithAssignmentScores_ReturnsExpectedCourseGrade(
        int[] assignmentScores,
        CourseGrade? expectedCourseGrade
    )
    {
        // Act
        var courseGrade = Challenges.CalculateCourseGrade(assignmentScores);

        // Assert
        courseGrade.Should().Be(expectedCourseGrade);
    }

    public static readonly IEnumerable<object[]> RegisterAndPassingStudentData = new List<object[]>
    {
        new object[]
        {
            Array.Empty<(string name, decimal attendance, decimal averageScore)>(),
            new[] { "No students have passed the course." },
        },
        new object[]
        {
            new[] { (name: "Person 1", attendance: 40m, averageScore: 50m) },
            new[] { "No students have passed the course." },
        },
        new object[]
        {
            new[] { (name: "Person 1", attendance: 40m, averageScore: 72m) },
            new[] { "No students have passed the course." },
        },
        new object[]
        {
            new[] { (name: "Person 1", attendance: 80m, averageScore: 50m) },
            new[] { "No students have passed the course." },
        },
        new object[]
        {
            new[] { (name: "Person 1", attendance: 70m, averageScore: 72m) },
            new[] { "Person 1 has passed the course." },
        },
        new object[]
        {
            new[] { (name: "Person 1", attendance: 80m, averageScore: 70m) },
            new[] { "Person 1 has passed the course." },
        },
        new object[]
        {
            new[] { (name: "Person 1", attendance: 80m, averageScore: 72m) },
            new[] { "Person 1 has passed the course." },
        },
        new object[]
        {
            new[]
            {
                (name: "Person 1", attendance: 40m, averageScore: 50m),
                (name: "Person 2", attendance: 60m, averageScore: 70m),
                (name: "Person 3", attendance: 80m, averageScore: 65m),
            },
            new[] { "No students have passed the course." },
        },
        new object[]
        {
            new[]
            {
                (name: "Person 1", attendance: 80m, averageScore: 72m),
                (name: "Person 2", attendance: 60m, averageScore: 70m),
                (name: "Person 3", attendance: 80m, averageScore: 75m),
            },
            new[] { "Person 1 has passed the course.", "Person 3 has passed the course." },
        },
        new object[]
        {
            new[]
            {
                (name: "Person 1", attendance: 80m, averageScore: 72m),
                (name: "Person 2", attendance: 90m, averageScore: 70m),
                (name: "Person 3", attendance: 80m, averageScore: 75m),
            },
            new[]
            {
                "Person 1 has passed the course.",
                "Person 2 has passed the course.",
                "Person 3 has passed the course.",
            },
        },
    };

    [Theory]
    [MemberData(nameof(RegisterAndPassingStudentData))]
    public void ListPassingStudents_CalledWithRegister_OutputsExpectedList(
        (string name, decimal attendance, decimal averageScore)[] register,
        string[] expectedOutputList
    )
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Challenges.ListPassingStudents(register);

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        outputLines.Length.Should().Be(expectedOutputList.Length);
        outputLines.Should().BeEquivalentTo(expectedOutputList);
    }
}
