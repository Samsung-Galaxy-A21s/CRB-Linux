#!/bin/bash
# Script to un/repack a boot.img file

echo ""
echo "Specify path to where the boot img is located"
read -p "PATH: " boot_img_path
echo ""

if [ -e "$boot_img_path/boot.img" ]; then

    if [ -e ./Projects/$PROJECT/Build/boot/ ]; then
        sudo rm -rf ./Projects/$PROJECT/Build/boot/
    fi

	echo "Copying to CRB..."

    mkdir -p ./Projects/$PROJECT/Build/boot/
    cp -f ./tools/AIK-Linux/* -r ./Projects/$PROJECT/Build/boot/
    cp -f $boot_img_path/boot.img ./Projects/$PROJECT/Build/boot/boot.img
    ./Projects/$PROJECT/Build/boot/unpackimg.sh ./Projects/$PROJECT/Build/boot/boot.img

	echo ""
    echo "Make any changes you want at: Projects/$PROJECT/Build/boot/"
	echo "Then run the repack option to rebuild image"
    sleep 1.5

else

    echo "Incorrect path specified!"
    echo "Check a boot.img is present in the directory!"
    echo "Check you didn't include a '/' at the end!"
    sleep 2
    exit 0

fi

sleep 1