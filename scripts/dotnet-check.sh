#!/bin/bash

# Variables
SRC_DIR=$1

# Ensure src directory is provided
if [[ -z "$SRC_DIR" ]]; then
  echo "Error: Source directory not provided."
  echo "Usage: $(basename "$0") <src-directory>"
  exit 1
fi

# Check if the src directory exists
if [[ ! -d "$SRC_DIR" ]]; then
  echo "Error: Source directory '$SRC_DIR' does not exist."
  exit 1
fi

# Get changed files in git
CHANGED_FILES=$(git diff --name-only HEAD)

# Check if any changed file is in the src directory
if ! echo "$CHANGED_FILES" | grep -q "^$SRC_DIR/"; then
  echo "No changes detected in the source directory: $SRC_DIR"
  exit 0
fi

echo "Detected changes in the source directory: $SRC_DIR"

# Build the dotnet project
echo "Building the dotnet project..."
if ! dotnet build "$SRC_DIR"; then
  echo "Error: Build failed."
  exit 1
fi

# Run tests
echo "Running tests..."
if ! dotnet test "$SRC_DIR" --no-build; then
  echo "Error: Tests failed."
  exit 1
fi

# Format and lint codes
echo "Formatting and linting codes..."
if ! dotnet format "$SRC_DIR" --verify-no-changes; then
  echo "Error: Code formatting failed."
  exit 1
fi

echo "All tasks completed successfully."
exit 0
