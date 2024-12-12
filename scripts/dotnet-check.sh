#!/bin/bash

# Variables
SRC_DIR=$1

# Function to check changes in the specific folder
check_changes_in_target_folder() {
  local target_folder="$1"

  # Read the pre-push hook input and process
  while read -r _ local_sha _ remote_sha; do
    # Determine the range of commits
    local range
    if [ "$remote_sha" = "0000000000000000000000000000000000000000" ]; then
      range="$local_sha" # New branch being pushed
    else
      range="$remote_sha..$local_sha"
    fi

    # Check for changes in the specified folder
    local changes
    changes=$(git diff --name-only "$range" | grep "^$target_folder/")

    if [ -n "$changes" ]; then
      # echo "Detected changes in $target_folder folder:"
      # echo "$changes"
      return 0
    fi
  done

  return 1
}

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

# Check if any changed file is in the src directory
if ! check_changes_in_target_folder "$SRC_DIR"; then
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
