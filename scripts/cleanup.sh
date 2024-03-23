#!/bin/bash
# Script to remove contents of the Projects folder

echo "*WARNING* This script will delete all data in the 'Projects' folder!"
read -p "Are you sure you want to continue? (Y) [Y/N]: " confirm
if [[ $confirm == [yY] || $confirm == [yY][eE][sS] ]]; then
    echo ""
    echo "Removing Projects folder..."
    sudo rm -rf ./Projects/*
	> tools/project
    echo ""
    echo "Done!"
else
    echo ""
    echo "Cleanup Aborted!"
fi
