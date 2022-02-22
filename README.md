# Fizz Buzz Solver

## What is the Fizz Buzz Solver?

The Fizz Buzz Solver is a web API that solves the classic FizzBuzz code challenge.

This specific implementation is written in C# and it uses the ASP.NET Core framework for the web API feature.

## Getting Started Using the API

The quickest way to get the Fizz Buzz Solver up and running is to run the API locally.

Once you have an instance of the API running, you can navigate to `/swagger/index.html` to start manually making requests against the `/api/solve` endpoint.

Example Requests and Responses are listed below.

## Example Requests and Responses

The API has one endpoint `/api/solve` and the endpoint takes in a JSON body.

This JSON body consists of 2 properties:

- `maxNumber`: Indicates how many numbers the current FizzBuzz request should solve for (Example: 100 in the classic FizzBuzz case)
- `divisors`: This is a dynamically sized collection of type `Divisor`, that has 2 properties, a `number` and a `printableOutput`. (Example: 3-Fizz and 5-Buzz for the classic FizzBuzz case)

The `Divisor` type allows you to customize each divisor's numeric value and the printable output value.

### Example Input JSON Body 1 (Classic Case)

```json
{
  "maxNumber": 15,
  "divisors": [
    {
      "divisorNumericValue": 3,
      "printableOutput": "Fizz"
    },
    {
      "divisorNumericValue": 5,
      "printableOutput": "Buzz"
    }
  ]
}
```

### Example Output 1

The output for this given input is:

```shell
1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
```

### Example Input 2

Here is one more example with 3 divisors:

```json
{
  "maxNumber": 12,
  "divisors": [
    {
      "divisorNumericValue": 2,
      "printableOutput": "Fizz"
    },
    {
      "divisorNumericValue": 3,
      "printableOutput": "Buzz"
    },
    {
      "divisorNumericValue": 4,
      "printableOutput": "Foo"
    }
  ]
}
```

### Example Output 2

```console
1
Fizz
Buzz
FizzFoo
5
FizzBuzz
7
FizzFoo
Buzz
Fizz
11
FizzBuzzFoo
```

## Future State
### Database Design for Logging Requests and Responses

In a future feature implementation, I will be adding a database that records requests, errors, and responses.

If you want to see more detail outside of the diagram listed below, please view the [SQL Script for the purposed database](https://github.com/BrendanSluke/FizzBuzzSolver/blob/main/FizzBuzzSolver/Database/DatabaseCreationScript.sql).

Here is a database diagram for the future SQL database:
![SQL Database Design](https://github.com/BrendanSluke/FizzBuzzSolver/blob/main/FizzBuzzSolver/Database/SqlDatabaseDesignDiagram.JPG?raw=true "SQL Database Design")
