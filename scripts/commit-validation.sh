#!/bin/bash

# List of folder names to check (can be adjusted as needed)
folder_names=("MethodGenerator" "OnRailsTest")

# Get the list of changed files against HEAD
changed_files=$(git diff --name-only HEAD)

# Check if all changed files are in the listed folders
for file in $changed_files; do
  matched=false
  for folder in "${folder_names[@]}"; do
    if [[ $file =~ ^.*$folder/ ]]; then
      matched=true
      break
    fi
  done

  if [[ $matched == false ]]; then
    echo "Info: Some changes are outside the specified folders."
    exit 0
  fi
done

# Get the commit message (the first commit message line)
commit_message=$(git log --format=%s -n 1)

# Check if the commit message starts with 'fix' or 'feat'
if [[ $commit_message =~ ^(fix|feat) ]]; then
  echo "Error: Commit message starts with 'fix' or 'feat' for invalid project."
  exit 1
fi

# If all checks pass
echo "Pre-commit checks passed."
exit 0
