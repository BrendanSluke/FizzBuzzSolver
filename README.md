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
- `divisors`: This is a dynamically sized collection of key-value pairs that allows you to customize the total number of divisors along with each divisor's numeric value and the output string value. (Example: 3-Fizz and 5-Buzz for the classic FizzBuzz case)

### Example Input JSON Body 1 (Classic Case)

```json
{
  "maxNumber": 15,
  "divisors": [
    {
      "key": 3,
      "value": "Fizz"
    },
    {
      "key": 5,
      "value": "Buzz"
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
      "key": 2,
      "value": "Fizz"
    },
    {
      "key": 3,
      "value": "Buzz"
    },
    {
      "key": 4,
      "value": "Foo"
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
