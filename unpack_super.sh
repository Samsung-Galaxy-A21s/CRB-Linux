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

    cd ..
    mkdir -p ./Build/system/
    mkdir -p ./Build/product/
    mkdir -p ./Build/vendor/
    mkdir -p ./Build/odm/

    mkdir -p ./Build/.tmp_system/
    mkdir -p ./Build/.tmp_product/
    mkdir -p ./Build/.tmp_vendor/
    mkdir -p ./Build/.tmp_odm/


    echo "Extracting system filesystem..."
    sudo mount -t ext4 -o loop Input/system.img Build/.tmp_system/
    sudo mv Build/.tmp_system/* Build/system/
    sudo umount Build/.tmp_system/
    sudo rm -rf Build/.tmp_system/
    echo "Extracting product filesystem..."
    sudo mount -t ext4 -o loop Input/product.img Build/.tmp_product/
    sudo mv Build/.tmp_product/* Build/product/
    sudo umount Build/.tmp_product/
    sudo rm -rf Build/.tmp_product/
    echo "Extracting vendor filesystem..."
    sudo mount -t ext4 -o loop Input/vendor.img Build/.tmp_vendor/
    sudo mv Build/.tmp_vendor/* Build/vendor/
    sudo umount Build/.tmp_vendor/
    sudo rm -rf Build/.tmp_vendor/
    echo "Extracting odm filesystem..."
    sudo mount -t ext4 -o loop Input/odm.img Build/.tmp_odm/
    sudo mv Build/.tmp_odm/* Build/odm/
    sudo umount Build/.tmp_odm/
    sudo rm -rf Build/.tmp_odm/

    echo ""
    echo "Done!"
else
    echo "Incorrect path specified!"
    echo "Check a super.img is present in the directory!"
    echo "Check you didn't include a '/' at the end!"
    exit 0
fi

echo ""
