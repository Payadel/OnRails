#!/bin/bash
set -e

# Usage:
#   chmod +x -R scripts (only first time, make scripts executable)
#   ./scripts/setup-hooks.sh (execute script)

# Function to enable a specific Git hook by copying its sample file
enable_hook() {
	local hooks_dir="$1"
	local hook_name="$2"
	local target_hook="$hooks_dir/$hook_name"
	local template_file="$hooks_dir/$hook_name.sample"

	if [[ -f "$target_hook" ]]; then
		echo "The $hook_name hook is already enabled. ($target_hook)"
	elif [[ -f "$template_file" ]]; then
		echo "Enabling $hook_name hook..."
		mv "$template_file" "$target_hook"
		echo "Template hook copied to $target_hook."
	else
		echo "Template for $hook_name hook not found."
	fi
}

# Function to get the Git hooks path
get_hooks_path() {
	local git_root
	git_root=$(git rev-parse --show-toplevel 2>/dev/null)
	local hooks_path
	hooks_path=$(git rev-parse --git-path hooks 2>/dev/null)

	if [[ -n "$git_root" && -n "$hooks_path" ]]; then
		echo "$git_root/$hooks_path"
	else
		echo ""
	fi
}

command_exists() {
    if command -v "$1" &> /dev/null; then
        #echo "Command '$1' exists."
        return 0
    else
        #echo "Command '$1' does not exist."
        return 1
    fi
}

# Check if pre-commit is installed
if ! command_exists pre-commit; then
	echo "Error: pre-commit is not installed. Please install it first."
	exit 1
fi

if ! command_exists npm && [ -f package.json ]; then
	echo "Error: npm is not installed. Please install it first."
	exit 1
fi

# Install pre-commit hooks
pre_commit_hooks=("commit-msg" "prepare-commit-msg" "pre-merge-commit" "pre-push")
for hook_type in "${pre_commit_hooks[@]}"; do
	pre-commit install --hook-type "$hook_type"
done

# Enable additional Git hooks if hook path exists
hooks_dir=$(get_hooks_path)
if [[ -n "$hooks_dir" ]]; then
	enable_hook "$hooks_dir" "pre-rebase"
else
	echo "Git hooks directory not found."
fi

if [ -f package.json ]; then
    npm install
fi
