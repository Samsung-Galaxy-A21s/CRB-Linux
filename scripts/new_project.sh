#!/bin/bash

read -p "Create a new Project? [Y] (Y/N): " project_confirm
if [[ $project_confirm == [yY] || $project_confirm == [yY][eE][sS] || -z "$project_confirm" ]]; then
    read -p "Enter Project Name: " project_name

    if [ -e "./../Projects/$project_name" ]; then
        echo "   "
        echo "This name has already been taken please try again!"
        exit 0
    fi

    if [ -e "./Projects" ]; then
         mkdir -p ./Projects/$project_name
         mkdir -p ./Projects/$project_name/Input
         mkdir -p ./Projects/$project_name/Output
         mkdir -p ./Projects/$project_name/Build
    fi

    if [ -e "./Projects/$project_name" ]; then
        echo "  "
        echo "New Project Created Successfully!"
    else
        echo "  "
        echo "Project NOT Created!"
        echo "Check the Script has been run from the correct location!"
        exit 0
    fi
 
else
    exit 0
fi
