#!/bin/bash
# Script to remove contents of the Projects folder

if [ -e "./tools/check_dir" ]; then
    :
else
    echo "You are not in the correct director!"
    echo "Stopping program now!"
    exit 0
fi

echo "*WARNING* This script will delete all data in the 'Projects' folder!"
read -p "Are you sure you want to continue? (Y) [Y/N]: " confirm
if [[ $confirm == [yY] || $confirm == [yY][eE][sS] ]]; then
    echo "Removing Projects folder..."
    rm -rf ./Projects/*
else
    echo ""
    echo "Cleanup Aborted!"
fi
