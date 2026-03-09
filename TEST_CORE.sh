#!/bin/bash
echo "Running core validation tests..."
dotnet test TechTest.Tests/TechTest.Tests.csproj --filter "FullyQualifiedName~TechTest.Tests.Core"
