#!/bin/bash

if [ -e ./Projects/$PROJECT/Build/system/system ]; then

    export SYSTEM=./Projects/$PROJECT/Build/system/system
    export VENDOR=./Projects/$PROJECT/Build/vendor

    echo ""
    echo "Debloating project $PROJECT now..."
    echo ""

    sudo rsync -av ./tools/debloat-physwizz/system/ $SYSTEM
    sudo rsync -av ./tools/debloat-physwizz/vendor/ $VENDOR

    echo ""
    echo "Cleaning up..."

    echo ""
    echo "Done"
    sleep 3


else
    echo ""
    echo -e "${BOLD_RED}[Error 1] System folder Data not found!"
    echo -e "Check you have unpacked a super.img first!"
    echo -e "Check the partition is mounted!${RESET}"
    sleep 2
    echo ""
fi