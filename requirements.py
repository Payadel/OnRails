#!/usr/bin/env python3
import os.path
import shutil
import subprocess
import sys
from typing import Optional

script_name = os.path.basename(sys.argv[0])


def get_shell_return_code(command: str) -> int:
    return subprocess.run(command, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL, shell=True,
                          check=False).returncode


def run_shell(command: str) -> subprocess.CompletedProcess:
    return subprocess.run(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE, shell=True, check=True)


def generate_message(text: str) -> str:
    return f"{script_name}: {text}"


def find_pip_name() -> Optional[str]:
    if get_shell_return_code("pip --version") == 0:
        return "pip"
    if get_shell_return_code("pip3 --version") == 0:
        return "pip3"
    return None


def get_hooks_path():
    if get_shell_return_code("git rev-parse --show-toplevel") != 0:
        return None
    git_root = run_shell("git rev-parse --show-toplevel").stdout.decode("utf-8").strip()
    hooks_path = run_shell("git rev-parse --git-path hooks").stdout.decode("utf-8").strip()
    default_hooks_path = ".git/hooks"
    is_default_path = hooks_path == default_hooks_path
    return {
        "hooks_path": os.path.join(git_root, hooks_path),
        "default_path": default_hooks_path,
        "is_default_path": is_default_path
    }


def find_template_hook(hook_name, hooks_path) -> Optional[str]:
    template_name = hook_name + ".sample"
    default_path = os.path.join(hooks_path['default_path'], template_name)
    possible_path = os.path.join(hooks_path['hooks_path'], template_name)

    if os.path.isfile(default_path):
        return default_path
    if os.path.isfile(possible_path):
        return possible_path
    return None


def enable_hook(hooks_path, target_hook_name):
    target_hook = os.path.join(hooks_path['hooks_path'], target_hook_name)
    if os.path.isfile(target_hook):
        print(generate_message(f"The {target_hook_name} hook was enabled."))
    else:
        print(generate_message(f"{target_hook} not found. Try use template file..."))
        template_file = find_template_hook(target_hook_name, hooks_path)
        if template_file:
            shutil.move(template_file, target_hook)
            print(generate_message(f"The template hook was copied."))
        else:
            print(generate_message(f"Can not find {target_hook_name} template file."))


def main():
    # Install pre-commit
    pip_name = find_pip_name()
    if pip_name:
        print(generate_message(f"The {pip_name} tool found. Install pre-commit..."))
        run_shell(f"{pip_name} install pre-commit")
        run_shell("pre-commit install")
    else:
        print(generate_message("Can not install pre-commit."))

    # Enable pre-commit hooks
    if get_shell_return_code("pre-commit --version") == 0:
        print(generate_message("Enable pre-commit hooks..."))
        run_shell("pre-commit install --hook-type commit-msg")
        run_shell("pre-commit install --hook-type prepare-commit-msg")
        run_shell("pre-commit install --hook-type pre-merge-commit")
        run_shell("pre-commit install --hook-type pre-push")
    else:
        print(generate_message("Can not enable pre-commit."))

    # Enable template hooks
    hooks_path = get_hooks_path()
    if hooks_path:
        enable_hook(hooks_path, "pre-rebase")
    else:
        print(generate_message(f"Can not enable pre-rebase git hook. Can not find git hooks directory."))

    # Install npm packages
    if get_shell_return_code("npm --version") == 0:
        print(generate_message("Install npm packages..."))
        run_shell("npm install")
    else:
        print(generate_message("Can not install npm packages."))


if __name__ == '__main__':
    main()
