#!/bin/bash

# This script is used to create a new project in the Projects directory

if [ -e "./Projects/$project_name" ]; then
    echo "   "
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
    # Ik this message is the last thing the user wants to see, but I DON'T CARE
    echo "[Error 1] Something went wrong and the project was not created!"
    exit 0
fi

sleep 0.5