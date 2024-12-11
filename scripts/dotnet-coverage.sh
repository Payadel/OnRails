#!/bin/bash

set -e

# Create a temporary folder
temp_folder=$(mktemp -d)

# Ensure the folder is deleted when the script exits (even if there's an error)
trap 'rm -rf "$temp_folder"' EXIT

#=================================================
# Function to display usage information
usage() {
  echo "Usage: $(basename "$0") -l|--line <number> [-b|--branch <number>] [-s|--src /path/to/src]"
  exit 1
}

#=================================================
# Initialize variables
line_threshold=""
branch_threshold=""
src_path="."

# Parse arguments
while [[ $# -gt 0 ]]; do
  case "$1" in
    -l|--line)
      if [[ -n "$2" && "$2" =~ ^[0-9]+$ ]]; then
        line_threshold="$2"
        shift 2
      else
        echo "Error: Argument for $1 must be a number."
        usage
      fi
      ;;
    -b|--branch)
      if [[ -n "$2" && "$2" =~ ^[0-9]+$ ]]; then
        branch_threshold="$2"
        shift 2
      else
        echo "Error: Argument for $1 must be a number."
        usage
      fi
      ;;
    -s|--src)
      src_path="$2"
      shift 2
      ;;
    *)
      echo "Error: Invalid argument $1"
      usage
      ;;
  esac
done

# Check if required argument is set
if [[ -z "$line_threshold" ]]; then
  echo "Error: -l|--line argument is required."
  usage
fi

# Get changed files in git
CHANGED_FILES=$(git diff --name-only HEAD)
if ! echo "$CHANGED_FILES" | grep -q "^$src_path/"; then
  echo "No changes detected in the source directory: $src_path"
  exit 0
fi

#=================================================
# Run the tests and collect coverage
echo "Running tests and collecting coverage..."
dotnet test --collect:"XPlat Code Coverage" --results-directory "$temp_folder" "$src_path" > /dev/null 2>&1 || { echo "Tests failed. Exiting."; exit 1; }

# Find the generated coverage file (coverage.cobertura.xml)
coverage_file="$(find "$temp_folder" -name "coverage.cobertura.xml")"

# Check if the coverage file exists
if [[ ! -f $coverage_file ]]; then
    echo "Coverage file not found ($coverage_file). Exiting."
    exit 1
fi

# Extract the line-rate and display the coverage as a percentage
echo "Extracting coverage..."
line_rate=$(xmllint --xpath 'string(/coverage/@line-rate)' "$coverage_file" | awk '{printf "%.0f\n", $1 * 100}')
if [ "$line_rate" -lt "$line_threshold" ]; then
  echo "Line rate error: $line_rate < $line_threshold"
  exit 1
fi

if [ -n "$branch_threshold" ]; then
  branch_rate=$(xmllint --xpath 'string(/coverage/@branch-rate)' "$coverage_file" | awk '{printf "%.0f\n", $1 * 100}')
  if [ "$branch_rate" -lt "$branch_threshold" ]; then
    echo "Branch rate error: $branch_rate < $branch_threshold"
    exit 1
  fi
fi

echo -e "Line\tBranch"
echo -e "$line_rate\t$branch_rate"
