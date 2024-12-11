#!/usr/bin/env pwsh

<#
.SYNOPSIS
    Setup Git hooks and npm dependencies for the repository.

.DESCRIPTION
    This script installs pre-commit hooks, enables additional Git hooks, 
    and optionally installs npm dependencies if package.json exists.

    Usage:
        ./setup-hooks.ps1
#>

# Enable strict mode to catch errors and undefined variables
Set-StrictMode -Version Latest

# Enable a specific Git hook by renaming its sample file
function Enable-Hook {
    param (
        [string]$HooksDir,
        [string]$HookName
    )

    $TargetHook = Join-Path -Path $HooksDir -ChildPath $HookName
    $TemplateFile = Join-Path -Path $HooksDir -ChildPath "$HookName.sample"

    if (Test-Path $TargetHook) {
        Write-Host "[INFO] $HookName hook is already enabled. ($TargetHook)"
    } elseif (Test-Path $TemplateFile) {
        Write-Host "[INFO] Enabling $HookName hook..."
        Move-Item -Path $TemplateFile -Destination $TargetHook -Force
        Write-Host "[SUCCESS] $HookName hook enabled at $TargetHook."
    } else {
        Write-Host "[WARNING] Template for $HookName hook not found. Skipping..."
    }
}

# Get the root directory of the Git repository
function Get-RootPath {
    $RootPath = git rev-parse --show-toplevel 2>$null
    if (-not $RootPath) {
        Write-Host "[ERROR] Not a Git repository."
        exit 1
    }
    return $RootPath
}

# Get the path to package.json, if it exists
function Get-PackageJsonPath {
    $RootPath = Get-RootPath
    $PackageJsonPath = Join-Path -Path $RootPath -ChildPath "package.json"
    if (Test-Path $PackageJsonPath) {
        return $PackageJsonPath
    } else {
        return $null
    }
}

# Get the Git hooks directory path
function Get-HooksPath {
    $HooksPath = git rev-parse --git-path hooks 2>$null
    if (-not $HooksPath) {
        Write-Host "[ERROR] Failed to locate Git hooks directory."
        exit 1
    }
    return $HooksPath
}

# Check if a command exists in the system
function Command-Exists {
    param (
        [string]$Command
    )

    Get-Command $Command -ErrorAction SilentlyContinue | Out-Null
    return $?
}

# Main function
function Main {
    # Ensure `pre-commit` is installed
    if (-not (Command-Exists "pre-commit")) {
        Write-Host "[ERROR] pre-commit is not installed. Please install it first: https://pre-commit.com/#install"
        exit 1
    }

    # Check for package.json and npm
    $PackageJsonPath = Get-PackageJsonPath
    if ($PackageJsonPath -and -not (Command-Exists "npm")) {
        Write-Host "[ERROR] npm is required to install dependencies but is not installed."
        exit 1
    }

    # Install pre-commit hooks
    Write-Host "============================"
    Write-Host "Installing pre-commit hooks"
    Write-Host "============================"
    $PreCommitHooks = @("commit-msg", "prepare-commit-msg", "pre-merge-commit", "pre-push")
    foreach ($HookType in $PreCommitHooks) {
        Write-Host "[INFO] Installing $HookType hook..."
        pre-commit install --hook-type $HookType
        Write-Host "[SUCCESS] $HookType hook installed."
    }

    # Enable additional Git hooks
    Write-Host "============================"
    Write-Host "Enabling additional Git hooks"
    Write-Host "============================"
    $HooksDir = Get-HooksPath
    Enable-Hook -HooksDir $HooksDir -HookName "pre-rebase"

    # Install npm dependencies if package.json exists
    if ($PackageJsonPath) {
        Write-Host "============================"
        Write-Host "Installing npm dependencies"
        Write-Host "============================"
        npm install
        Write-Host "[SUCCESS] npm dependencies installed."
    }

    Write-Host "============================"
    Write-Host "[SUCCESS] Setup completed."
    Write-Host "============================"
}

# Execute the main function
Main
