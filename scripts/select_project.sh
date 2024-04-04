#!/bin/bash

# Script which selects a project

CURRENT_PROJECT=$(cat tools/project)

echo "Available Projects:"
ls -d Projects/* | cut -d '/' -f 2

if [ -e "./Projects/$project_choice" ]; then
	# Clear the current project and set the new one
	> tools/project
	echo "$project_choice" > tools/project
fi

sleep 1