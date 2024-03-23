#!/bin/bash

BLACK='\033[0;30m'
BOLD_BLACK='\033[1;30m'
RED='\033[0;31m'
BOLD_RED='\033[1;31m'
GREEN='\033[0;32m'
BOLD_GREEN='\033[1;32m'
YELLOW='\033[0;33m'
BOLD_YELLOW='\033[1;33m'
BLUE='\033[0;34m'
BOLD_BLUE='\033[1;34m'
MAGENTA='\033[0;35m'
BOLD_MAGENTA='\033[1;35m'
CYAN='\033[0;36m'
BOLD_CYAN='\033[1;36m'
WHITE='\033[0;37m'
BOLD_WHITE='\033[1;37m'
RESET='\033[0m' # Reset color
BOLD='\033[1m'
PINK='\033[38;5;206m'

UNDERLINE='\033[4m'
CURRENT_PROJECT=$(cat tools/project)

if [ -e ./tools/checker ]; then
    :
else
    echo "[Error 1] You are not in the correct directory!"
    echo "Stopping program now!"
    exit 0
fi

if [ ! -s "tools/project" ]; then
	CURRENT_PROJECT="None"
fi

export PROJECT=$CURRENT_PROJECT

PRINT()
{
	echo -e "                                                 ${BOLD_BLUE}${UNDERLINE}Welcome To CRB-Linux Kitchen - By RiskyGUY22${RESET}${RESET}"
    echo -e "${BOLD_RED}**PROJECT MANAGEMENT**${RESET}                                    ${BOLD}${PINK}${UNDERLINE}Selected Project: $CURRENT_PROJECT${RESET}${RESET}${RESET}"
    echo -e "1)  New Project"
	echo -e "2)  Select Project"
    echo -e "3)  Delete Projects"
	echo -e ""

    echo -e "${BOLD_GREEN}**UNPACK IMAGE**${RESET}"
    echo -e "4)  Unpack super.img"
    echo -e "5)  Unpack boot.img"
	echo -e ""

    echo -e "${BOLD_YELLOW}**REPACK IMAGE**${RESET}"
    echo -e "6)  Repack system.img"
    echo -e "7)  Repack product.img"
    echo -e "8)  Repack vendor.img"
    echo -e "9)  Repack odm.img"
    echo -e "10) Repack super.img"
    echo -e "11) Repack boot.img"
	echo -e ""

	echo -e "${BOLD_MAGENTA}**MISC**${RESET}"
    echo -e "12) Exit this menu"
	echo -e ""
}

MAIN()
{

	read -p "Option: " option

	case $option in
		1)
			bash scripts/new_project.sh
			;;
		2)
			bash scripts/select_project.sh
			;;
		3)
			bash scripts/cleanup.sh
			;;
		4)
			bash scripts/unpack_super.sh
			;;
		12)
			echo "Exiting..."
			exit
			;;
		*)
			echo "[Error 1] Invalid option!"
			;;

	esac



}

PRINT
MAIN
