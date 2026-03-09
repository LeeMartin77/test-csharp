#!/bin/bash
echo "Running TEST_003 validation tests..."
dotnet test TechTest.Tests/TechTest.Tests.csproj --filter "FullyQualifiedName~TechTest.Tests.Test003"
