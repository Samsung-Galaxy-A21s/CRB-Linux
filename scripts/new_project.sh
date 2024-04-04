#!/bin/bash

# This script is used to create a new project in the Projects directory
read -p "Enter Project Name: " project_name

if [ -e "./../Projects/$project_name" ]; then
    echo "   "
    echo "[Error 1] $project_name already exists!"
    exit 0
fi

# Create directories for the new project
mkdir -p ./Projects/$project_name
mkdir -p ./Projects/$project_name/Input
mkdir -p ./Projects/$project_name/Output
mkdir -p ./Projects/$project_name/Build

# Check the project was created successfully
if [ -e "./Projects/$project_name" ]; then
    echo "  "
    echo "New Project Created Successfully!"
else
    echo "  "
    echo "[Error 1] Something went wrong and the project was not created!"
    exit 0
fi
