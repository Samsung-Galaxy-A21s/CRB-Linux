#!/bin/bash

# Script to delete all projects
BOLD_GREEN='\033[1;32m'
BOLD_RED='\033[1;31m'
BOLD_RED='\033[1;31m'
BOLD='\033[1m'

# List projects to delete from
echo -e "${BOLD}Projects:${RESET}"
ls -d Projects/* | grep -v "/$PROJECT" | cut -d '/' -f 2
if [ $PROJECT == "None" ]; then
    :
else
    echo -e "${BOLD_GREEN}$PROJECT << Current Project${RESET}"
fi
echo -e "${BOLD_RED}ALL << Delete All Projects${RESET}"

read -p "CHOICE: " choice

if [ "$choice" == "ALL" ]; then
    echo "Deleting..."
    sudo rm -rf Projects/*
    > tools/project
else
    echo "Deleting..."
    sudo rm -rf "Projects/$choice"
fi

if [ $PROJECT == $choice ]; then
    > tools/project
fi

sleep 0.75
