#!/bin/bash
echo "Running TEST_001 validation tests..."
dotnet test TechTest.Tests/TechTest.Tests.csproj --filter "FullyQualifiedName~TechTest.Tests.Test001"
