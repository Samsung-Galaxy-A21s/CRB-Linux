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

    # Un mount mounted partitions
    sudo umount Projects/*/Build/system > /dev/null 2>&1
    sudo umount Projects/*/Build/product > /dev/null 2>&1
    sudo umount Projects/*/Build/vendor > /dev/null 2>&1
    sudo umount Projects/*/Build/odm > /dev/null 2>&1
    sudo umount Projects/*/Build/prism > /dev/null 2>&1
    sudo umount Projects/*/Build/optics > /dev/null 2>&1

    sudo rm -rf Projects/*
    > tools/project
else
    echo "Deleting..."

    # Un mount mounted partitions
    sudo umount Projects/$choice/Build/system > /dev/null 2>&1
    sudo umount Projects/$choice/Build/product > /dev/null 2>&1
    sudo umount Projects/$choice/Build/vendor > /dev/null 2>&1
    sudo umount Projects/$choice/Build/odm > /dev/null 2>&1
    sudo umount Projects/$choice/Build/prism > /dev/null 2>&1
    sudo umount Projects/$choice/Build/optics > /dev/null 2>&1

    sudo rm -rf "Projects/$choice"
fi

if [ $PROJECT == $choice ]; then
    > tools/project
fi

sleep 0.75
