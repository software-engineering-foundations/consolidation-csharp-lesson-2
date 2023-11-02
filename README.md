# Lesson 2 Challenges

Before starting the challenges, make sure you have CSharpier and Husky installed:

```
dotnet tool install --global csharpier
dotnet tool install --global husky
```

Finally, run `husky install` at the root of the repository.

## Challenge 1: `MagicPetShop` (4 points)

Write a method that asks the user for two responses: firstly, what type of animal their ideal pet would be, and secondly, what they would call their ideal pet. Once you have these, output the following exact text, replacing the first `___` with their pet type response and the second `___` with their pet name response:

```
Unbelievable! We have your ideal pet. This ___ over here is called ___.
```

## Challenge 2: `PlaceSundriesOrder` (6 points)

Write a method that asks the user for two responses: firstly, how many bowls of rice their party would like, and secondly, how many naan breads their party would like. Once you have these, output the following exact text, replacing the `___` with the cost of their order, given that each bowl of rice costs 3.95 currency and each naan bread costs 3.45 currency:

```
Thank you, that will be ___.
```

The cost of their order should be formatted to exactly two decimal places.

## Challenge 3: `ShouldTakeCoat` (6 points)

Write a method that asks the user for a single response: the current temperature in degrees Celsius. If their response is below 15, output the following exact text:

```
You should take a coat with you when you go out.
```

Otherwise, output the following exact text instead:

```
No need for a coat, go as you are.
```

You do not need to handle the case where the user enters an invalid response, though you may if you wish.

## Challenge 4: `ShouldTakeUmbrellaOrCoat` (10 points)

Write a method that firstly asks the user for a single response: whether it is currently raining. If their response is the exact word `yes`, ask them a further question: whether they are going to the city or the countryside. If their response is the exact word `city`, output the following exact text:

```
You should take an umbrella with you when you go out.
```

Otherwise, if their response is the exact word `countryside`, output the following exact text instead:

```
You should take a coat with you when you go out.
```

Otherwise, if their response matches neither word, output the following exact text:

```
I'm not sure whether you should take an umbrella or a coat with you.
```

Back to the original question, if their response to whether it is currently raining is the exact word `no`, output the following exact text:

```
No need for an umbrella or a coat, go as you are.
```

Finally, if their response was neither `yes` nor `no`, output the following exact text:

```
Sorry, I didn't understand your response.
```

## Challenge 5: `FahrenheitToCelsius` (6 points)

Write a method that takes a temperature in degrees Fahrenheit and returns the equivalent temperature in degrees Celsius. You should find the formula for the conversion online and implement it carefully.

## Challenge 6: `CalculateCarHireCost` (10 points)

Write a method that takes a number of days and returns the total cost of hiring a car for that number of days. Each day costs 60 currency. There are two special offers: if the number of days is at least 3, a discount of 20 currency is applied, or if the number of days is at least 7, a discount of 50 currency is applied. Only one offer can be applied at a time, with the second offer taking precedence over the first.

## Challenge 7: `CalculateMilliseconds` (6 points)

Write a method that takes a number of hours, minutes and seconds in a duration, then calculates and returns the total number of milliseconds across that duration.

## Challenge 8: `FindRockPaperScissorsWinner` (18 points)

Write a method that takes a move for each of two players and outputs one of the following exact text snippets, depending on the situation:

```
Player 1 wins!
```

```
Player 2 wins!
```

```
It's a draw.
```

The values passed in will members of the `RockPaperScissorsMove` enum. You should find the rules of Rock-Paper-Scissors online if you don't already know them, and implement them carefully.

## Challenge 9: `CalculateCourseGrade` (14 points)

Write a method that takes an array containing the scores obtained by a student on each assignment from the course (all equally weighted) and returns the letter grade from the `CourseGrade` enum that corresponds to the average score. The grade thresholds are as follows:

```
A   90 or above
B   80 or above
C   70 or above
D   60 or above
E   50 or above
F   Below 50
```

If the student hasn't submitted any assignments yet, return `null` instead of a letter grade.

## Challenge 10: `ListPassingStudents` (20 points)

Write a method that takes a register of student data (including each student's name, attendance percentage and average score) and outputs a line in the following exact format for each student who has passed the course, replacing `___` with the student's name:

```
___ has passed the course.
```

The criteria for passing the course are having an attendance percentage of at least 70 and having an average score of at least 70.

In the event that no student on the register has passed the course, output the following exact text instead:

```
No students have passed the course.
```

## Bonus challenge: `CalculateSumOfMultiplesLessThanLimit`

Find the sum of all the numbers from 1 up to (but not including) the specified limit that are a multiple of any number in the given array.

You should start by thinking of some of your own test cases (which you don't have to write actual tests for unless you're feeling particularly ambitious).
