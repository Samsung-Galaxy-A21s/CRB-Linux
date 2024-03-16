#!/bin/bash
# Script to unpack a super.img file

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

echo "Specify path to where the super img is located"
read -p "PATH: " super_img_path
echo ""

if [ -e "$super_img_path/super.img" ]; then
    echo "Super.img located!"
    echo "Copying to CRB..."
    cp -f $super_img_path/super.img ./Projects/$project_option/Input/

    echo ""
    echo "Extracting Dynamic Partitions..."
    cd Projects/$project_option/Input/
    simg2img super.img super.img.raw
    echo "Extracting system image..."
    ./../../../tools/super_to_raw/lpunpack --partition=system super.img.raw
    echo "Extracting product image..."
    ./../../../tools/super_to_raw/lpunpack --partition=product super.img.raw
    echo "Extracting vendor image..."
    ./../../../tools/super_to_raw/lpunpack --partition=vendor super.img.raw
    echo "Extracting odm image..."
    ./../../../tools/super_to_raw/lpunpack --partition=odm super.img.raw
    echo ""
    echo "Done!"
else
    echo "Incorrect path specified!"
    echo "Check a super.img is present in the directory!"
    echo "Check you didn't include a '/' at the end!"
    exit 0
fi

echo ""
