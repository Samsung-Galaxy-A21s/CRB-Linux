#!/bin/bash

# Script which selects a project

CURRENT_PROJECT=$(cat tools/project)

# Define colors
BOLD_GREEN='\033[1;32m'
RESET='\033[0m'

echo ""
echo "Available Projects:"
echo ""

# Using ls command with color and formatting
for project in $(ls -d Projects/* | cut -d '/' -f 2); do
    echo -e "${BOLD_GREEN}${project}${RESET}"
done

echo ""
read -p "Choice: " project_choice
if [ -e "./Projects/$project_choice" ]; then
	# Clear the current project and set the new one
	> tools/project
	echo "$project_choice" > tools/project
	echo ""
	echo -e "Project ${BOLD_GREEN}'$project_choice'${RESET} selected!"
else
	echo ""
	echo "[Error 1] Invalid Project name specified!"
	sleep 2
	exit 0
fi

sleep 0.5
