#!/bin/bash

# Usage:
#   chmod +x -R scripts (only required initially, to make scripts executable)
#   ./scripts/setup-hooks.sh (execute script)

# Exit on error (e), undefined variable (u), or failed pipeline command (cmd1 | cmd2 | cmd3)
set -euo pipefail

# Enable a specific Git hook by copying its sample file
enable_hook() {
	local hooks_dir="$1"
	local hook_name="$2"
	local target_hook="$hooks_dir/$hook_name"
	local template_file="$hooks_dir/$hook_name.sample"

	if [[ -f "$target_hook" ]]; then
		echo "[INFO] $hook_name hook is already enabled. ($target_hook)"
	elif [[ -f "$template_file" ]]; then
		echo "[INFO] Enabling $hook_name hook..."
		mv "$template_file" "$target_hook"
		echo "[SUCCESS] $hook_name hook enabled at $target_hook."
	else
		echo "[WARNING] Template for $hook_name hook not found. Skipping..."
	fi
}

# Get the root directory of the Git repository
get_root_path() {
	git rev-parse --show-toplevel 2>/dev/null || { echo "[ERROR] Not a Git repository."; exit 1; }
}

# Get the path to package.json, if it exists
get_package_json_path() {
	local root_path
	root_path=$(get_root_path)
	local package_json_path="$root_path/package.json"

	if [[ -f "$package_json_path" ]]; then
		echo "$package_json_path"
	else
		echo ""
	fi
}

# Get the Git hooks directory path
get_hooks_path() {
	git rev-parse --git-path hooks 2>/dev/null || { echo "[ERROR] Failed to locate Git hooks directory."; exit 1; }
}

# Check if a command exists in the system
command_exists() {
	command -v "$1" &>/dev/null
}

# Main function
main() {
	# Ensure `pre-commit` is installed
	if ! command_exists pre-commit; then
		echo "[ERROR] pre-commit is not installed. Please install it first: https://pre-commit.com/#install"
		exit 1
	fi

	# Check for package.json and npm
	local package_json_path
	package_json_path=$(get_package_json_path) || {
		echo "[WARNING] Cannot find package.json. Skipping npm dependency installation."
		package_json_path=""
	}

	if [[ -n "$package_json_path" ]] && ! command_exists npm; then
		echo "[ERROR] npm is required to install dependencies but is not installed."
		exit 1
	fi

	# Install pre-commit hooks
	echo "============================"
	echo "Installing pre-commit hooks"
	echo "============================"
	local pre_commit_hooks=("commit-msg" "prepare-commit-msg" "pre-merge-commit" "pre-push")
	for hook_type in "${pre_commit_hooks[@]}"; do
		echo "[INFO] Installing $hook_type hook..."
		pre-commit install --hook-type "$hook_type"
		echo "[SUCCESS] $hook_type hook installed."
	done

	# Enable additional Git hooks
	echo "============================"
	echo "Enabling additional Git hooks"
	echo "============================"
	local hooks_dir
	hooks_dir=$(get_hooks_path)
	enable_hook "$hooks_dir" "pre-rebase"

	# Install npm dependencies if package.json exists
	if [[ -n "$package_json_path" ]]; then
		echo "============================"
		echo "Installing npm dependencies"
		echo "============================"
		npm install
		echo "[SUCCESS] npm dependencies installed."
	fi

	echo "============================"
	echo "[SUCCESS] Setup completed."
	echo "============================"
}

# Execute the main function
main "$@"
