#!/bin/bash

docker_name="${1:-console-sharp}"

clear

docker rmi "$docker_name" -f
docker compose up --abort-on-container-exit