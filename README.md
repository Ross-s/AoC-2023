# AoC-2023

## Outline
I am taking part in Advent Of Code 2023, For this i have decided to use C#.
This repository is setup as one C# project, each days problems are stored is seprate folder names Day-{day number}.
in each folder there is a PartA and a PartB, and a Common File.

The Code will auto download the input data for the challange, to make this work you need to have a local.appsettings.json file
in side of this should be  the following value:
```json
{
    "SECRET_COOKIE": "{my secret cookie}"
}
```

The value you should put there is the cookie that is used to authenticate your self to Adevent of code.
This is because every users input data is diffrent.

You can locate this code by viweing the cookies on Advent of code's website after you have authenticated
![Cookies](/AOC-Cookie.png)


## Warnings
Day 5 - Part B is brute forced and is very expensive. Run at your own risk