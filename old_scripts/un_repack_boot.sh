#!/bin/bash
# Script to un/repack a boot.img file

if [ -e ./tools/check_dir ]; then
    :
else
    echo "You are not in the correct director!"
    echo "Stopping program now!"
    exit 0
fi

echo "Projects: "
echo "          "
_all_projects=$(ls ./Projects)
echo "$_all_projects"

echo "      "
echo "Select a Project from the following above,"
read -p "*WARNING* It is CASE sensitive: " project_option
echo "$project_option has been selected"
echo "               "

read -p "Do you want to Unpack[U] or Repack[R] boot.img? [U/R]:  " un_re_choice
if [[ $un_re_choice == [uU] ]]; then

    echo "Specify path to where the boot img is located"
    read -p "PATH: " boot_img_path
    echo ""

    if [ -e "$boot_img_path/boot.img" ]; then
        echo "boot.img located!"
        echo "Copying to CRB..."

        mkdir -p ./Projects/$project_option/Build/boot/
        cp -f ./tools/AIK-Linux/* -r ./Projects/$project_option/Build/boot/
        cp -f $boot_img_path/boot.img ./Projects/$project_option/Build/boot/
        ./Projects/$project_option/Build/boot/unpackimg.sh ./Projects/$project_option/Build/boot/boot.img

        echo ""
        echo "Done!"
    else
        echo "Incorrect path specified!"
        echo "Check a boot.img is present in the directory!"
        echo "Check you didn't include a '/' at the end!"
        exit 0
    fi
fi

if [[ $un_re_choice == [rR] ]]; then

    echo "Searching for boot.img at default location..."
    if [ -e "./Projects/$project_option/Build/boot/boot.img" ]; then
        echo "Boot.img Found!"
    fi
    echo ""

    ./Projects/$project_option/Build/boot/repackimg.sh
    echo "Copying new boot image to Output folder..."
    cp -f ./Projects/$project_option/Build/boot/image-new.img ./Projects/$project_option/Output/boot.img
    echo "Check Output folder"
    echo ""
    echo "Done!"
fi
