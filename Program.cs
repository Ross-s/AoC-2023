var secret = new Settings().Get("SECRET_COOKIE");

// Day 1 Part A
var dayOnePartA = new Day1.PartA(secret, new DailyInput(secret));
Console.WriteLine($"Day 1, Part A: {dayOnePartA.Solve()}");

// Day 1 Part B
var dayOnePartB = new Day1.PartB(secret, new DailyInput(secret));
Console.WriteLine($"Day 1, Part B: {dayOnePartB.Solve()}");

// Day 2 Part A
var dayTwoPartA = new Day2.PartA(secret, new DailyInput(secret));
Console.WriteLine($"Day 2, Part A: {dayTwoPartA.Solve()}");

// Day 2 Part B
var dayTwoPartB = new Day2.PartB(secret, new DailyInput(secret));
Console.WriteLine($"Day 2, Part B: {dayTwoPartB.Solve()}");

// Day 3 Part A
var dayThreePartA = new Day3.PartA(secret, new DailyInput(secret));
Console.WriteLine($"Day 3, Part A: {dayThreePartA.Solve()}");

// Day 3 Part B
var dayThreePartB = new Day3.PartB(secret, new DailyInput(secret));
Console.WriteLine($"Day 3, Part B: {dayThreePartB.Solve()}");

// Day 4 Part A
var dayFourPartA = new Day4.PartA(secret, new DailyInput(secret));
Console.WriteLine($"Day 4, Part A: {dayFourPartA.Solve()}");

// Day 4 Part B
var dayFourPartB = new Day4.PartB(secret, new DailyInput(secret));
Console.WriteLine($"Day 4, Part B: {dayFourPartB.Solve()}");

// Day 5 Part A
var dayFivePartA = new Day5.PartA(secret, new DailyInput(secret));
Console.WriteLine($"Day 5, Part A: {dayFivePartA.Solve()}");

// Day 5 Part B - Warning - see README 
//var dayFivePartB = new Day5.PartB(secret, new DailyInput(secret));
//Console.WriteLine($"Day 5, Part B: {dayFivePartB.Solve()}");