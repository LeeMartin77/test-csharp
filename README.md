# Tech Test API

A simple ASP.NET Core HTTP API for basic mathematical operations.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (8 or later)
- bash (for running the validation scripts)

## How to Run

```bash
dotnet run --project TechTest.Api
```

The server will start on port 8080 (see `TechTest.Api/Properties/launchSettings.json`).

## API Endpoints

### Ping
Check if the server is running:
```bash
curl http://localhost:8080/ping
```
Returns: `pong`

### Addition
Add two numbers together:
```bash
curl "http://localhost:8080/add?a=10&b=5"
```
Returns: `15.00`

### Subtraction
Subtract b from a:
```bash
curl "http://localhost:8080/sub?a=10&b=3"
```
Returns: `7.00`

## Example Usage

```bash
# Start the server
dotnet run --project TechTest.Api

# Test addition
curl "http://localhost:8080/add?a=15&b=25"
# Returns: 40.00

# Test subtraction
curl "http://localhost:8080/sub?a=20&b=8"
# Returns: 12.00

# Test with decimals
curl "http://localhost:8080/add?a=3.5&b=2.1"
# Returns: 5.60
```

## Running Tests

Run all tests:
```bash
dotnet test
```

Run a specific test suite using the provided scripts:
```bash
bash TEST_CORE.sh          # core endpoint tests
bash TEST_001.VALIDATE.sh  # TEST_001 validation
bash TEST_002.VALIDATE.sh  # TEST_002 validation
bash TEST_003.VALIDATE.sh  # TEST_003 validation
```
