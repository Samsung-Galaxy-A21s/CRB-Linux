#!/bin/bash

# Script which selects a project

CURRENT_PROJECT=$(cat tools/project)

if [ ! -s tools/project ]; then 

	echo "No project currently selected!"
else
	echo "The current project is: $CURRENT_PROJECT"

fi

read -p "Would you like to select a NEW project? (Y) [Y/N]: " choice

if [[ $choice == [yY] || $choice == [yY][eE][sS] ]]; then

	ls -d Projects/* | cut -d '/' -f 2

	read -p "Project: " project_choice
	if [ -e "./Projects/$project_choice" ]; then
		> tools/project
		
		echo "$project_choice" > tools/project
	fi

fi
